/// <reference types="@types/dom-mediacapture-record" />

import { Component, OnInit } from '@angular/core';
import { SignalRService } from './services/signal-r.service';
import { FileUploader, FileSelectDirective, FileItem } from 'ng2-file-upload';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'signalRStudy-client';
  files: FileList;

  constructor(public signalRService: SignalRService) { }

  ngOnInit() {
    this.signalRService.startConnection();
    //this.signalRService.sendMessage();   
    this.signalRService.receveiveMessage();

    const constraints = {
      video: true,
      audio: false
    };
    
    const video = document.querySelector('video');
    
    navigator.mediaDevices.getUserMedia(constraints).
      then((stream) => {
        //var options = {mimeType: 'video/webm; codecs=vp9'};

        var options;
        if (MediaRecorder.isTypeSupported('video/webm;codecs=vp9')) {
          options = {mimeType: 'video/webm; codecs=vp9'};
        } else if (MediaRecorder.isTypeSupported('video/webm;codecs=vp8')) {
          options = {mimeType: 'video/webm; codecs=vp8'};
        } else {
          // ...
        }
        console.log(options);

        video.srcObject = stream;
        
        
        let recorder = new MediaRecorder(stream, options);

        recorder.ondataavailable = (e) => {
          console.log(e.data);
          
          new Response(e.data).arrayBuffer()
            .then((arrayBuffer) => {
              let buffer = new Int8Array(arrayBuffer as ArrayBuffer);
              console.log(buffer);
              this.signalRService.sendBytes(new Number[] = (buffer))
            });          
        };

        recorder.start(100);
        console.log(recorder.videoBitsPerSecond);
      });
  }

  onSuccess(stream) {

  }

  handleFiles(event) {
    let reader = new FileReader();
    let file = event.target.files[0];
    console.log(file);

    let readed = reader.readAsArrayBuffer(file);

    reader.onload = () => {
      console.log(reader.result);
      let buffer = new Int8Array(reader.result as ArrayBuffer);
      this.signalRService.sendBytes(buffer);
    };

    console.log("handles");
    console.log(readed);
  }

  saveChunks(e) {
    console.log(e);
    console.log(e.data.size);
  }
}
