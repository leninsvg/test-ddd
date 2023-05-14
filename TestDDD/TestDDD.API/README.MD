#### Install Database
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Nada1234*' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-CU8-ubuntu

#### Init Migrations
dotnet ef migrations add InitialCreate -c TestDDDContext -s ../TestDDD.API --output-dir Migrations
