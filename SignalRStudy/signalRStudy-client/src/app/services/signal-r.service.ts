import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection: signalR.HubConnection;
  count = 0;
  readyVideo = false;

  constructor() { }

  public startConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:5001/chatHub')
      .build();

    this.hubConnection
      .start()
      .then(() => {
        console.log('Connection started');
        this.sendMessage();

        let x = new Int8Array();
        let y = Array.from(x);
        this.sendBytes(y);
      })
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  public receveiveMessage() {
    this.hubConnection.on('ReceiveMessage', (user, message) => {
      console.log(`received message: ${user}`);
      console.log(message);
    });
  }

  public sendMessage() {
    this.hubConnection
      .invoke('SendMessage', "MyUser", "MyMessage")
      .then(() => console.log("Message Sended"))
      .catch(err => console.log('Error while send message: ' + err))
  }

  public sendBytes(bytes: any) {
    this.hubConnection
      .send('SendBytes', "MyUser", bytes)
      .then(() => console.log("Message Sended"))
      .catch(err => console.log('Error while send message: ' + err))
  }

  public receiveBytes(sourceBuffer: SourceBuffer, queue, mediaSource, video) {
    this.hubConnection.on('ReceiveBytes', (bytes) => {
      let data = new Uint8Array(bytes);
    
      console.log(`Video state is ${video.readyState}`);
      if (this.count !== 0 && (sourceBuffer.updating || mediaSource.readyState != "open" || !this.readyVideo || queue.length > 0)) {
        queue.push(data.buffer);
      } else {
        console.log("Addede to source buffer");
        sourceBuffer.appendBuffer(data.buffer);
      }

      if (this.count === 0) {
        this.count++;
        let promise = video.play();
        console.log(promise);
        if (promise !== undefined) {
          promise.then(_ => {
            console.error("is played");
            this.readyVideo = true;
          }).catch(error => {
            console.error("Error in promise");
            console.error(error);
          });
        }
      }
    })
  }
}
