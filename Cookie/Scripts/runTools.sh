containerName="sql_server"
docker kill $containerName
docker rm $containerName

docker run -d -p 1433:1433 --name $containerName \
    -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Qwerty123' \
    -v sqlvolume:/var/opt/mssql \
    mcr.microsoft.com/mssql/server:2019-latest

# sqlcmd -U SA -S localhost -P Qwerty123 -i ./CreateTables.sql