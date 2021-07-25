# Tmuzik
## Pipeline status
[![CircleCI](https://circleci.com/gh/circleci/circleci-docs.svg?style=shield)](https://app.circleci.com/pipelines/github/Tuanle207/tmuzik-api?branch=master)

The application is hosted at http://tuanle207.tech:3001

Tmuzik is a audio streaming application that gives you the abilities to share and manage you audio content. Of course, you can access to others' audio content as well.

## Features

- Share and manage audio contents
- Live stream/stream audio
- User interaction

## Tech

Tmuzik uses a number of open source projects, development tools and technologies to work properly:

- [.NET] - a developer platform with tools and libraries for building web applications
- [React.js] - an awesome JavaScript library for building user interfaces
- [Redux] - a Predictable State Container for JS Applications
- [Entityframework Core] - a lightweight, extensible, open source and cross-platform version of the popular Entity Framework data access technology
- [PostgreSQL] - the World's Most Advanced Open Source Relational Database
- [Microsoft SignalR] - incredibly simple real-time web for ASP.NET, an implementaion of Websocket protocol
- [CircleCI] - powerful continuous integration and delivery for any platform
- [Nginx] - high performance web server application running on Ubuntu VPS

## Installation

Tmuzik Api requires [.NET] 5  to run

Edit **connection string** in **app setting files** with your own one in **Tmuzik.Api diectory** and update database command:
```sh
git clone https://github.com/Tuanle207/tmuzik-api
cd tmuzik-api/src/Tmuzik.Api
dotnet restore
dotnet ef database update -c AppDbContext -p ../Tmuzik.Data/Tmuzik.Data.csproj
```
Then start the server:
```sh
dotnet run
```

Finally, verify the application start properly by navigating to your server address in
your preferred browser.

```sh
127.0.0.1:5000
```

## Development

Want to contribute? Great!

Just open your favorite Terminal and run these commands:
```sh
git clone https://github.com/Tuanle207/tmuzik-api
cd tmuzik-api/src/Tmuzik.Api
dotnet run
```

To run add-migration command (**from Tmuzik.Api working directory**):
```sh
dotnet ef migrations add <MIGRATION_NAME> -c AppDbContext -p ../Tmuzik.Data/Tmuzik.Data.csproj -o ../Tmuzik.Data/Migrations
```

To run remove-migration command:
```sh
dotnet ef migrations remove -c AppDbContext -p ../Tmuzik.Data/Tmuzik.Data.csproj -o ../Tmuzik.Data/Migrations
```

To run update-database command:
```sh
dotnet ef database update -c AppDbContext -p ../Tmuzik.Data/Tmuzik.Data.csproj
```

To run drop-database command:
```sh
dotnet ef database drop -c AppDbContext -p ../Tmuzik.Data/Tmuzik.Data.csproj
```

#### Building for source

For production release:

```sh
git clone https://github.com/Tuanle207/tmuzik-api
cd tmuzik-api
dotnet publish -c Release -o dist
```

To generate SQL scripts for release:
```sh
git clone https://github.com/Tuanle207/tmuzik-api
cd tmuzik-api/src/Tmuzik.Api
dotnet ef migrations script -i -c AppDbContext -p ../Tmuzik.Data/Tmuzik.Data.csproj -o ../../dist/migrations_script.sql
```
## Author

**Tuanle207**

Got any question? Please feel free to get contact via tuanle2x7@gmail.com

**Thanks for your concern!**


   [.NET]: <https://dotnet.microsoft.com/>
   [React.js]: <https://reactjs.org/>
   [Redux]: <https://redux.js.org/>
   [Entityframework Core]: <https://docs.microsoft.com/en-us/ef/core/>
   [PostgreSQL]: <https://www.postgresql.org/>
   [Microsoft SignalR]: <https://dotnet.microsoft.com/apps/aspnet/signalr>
   [CircleCi]: <https://circleci.com/>
   [Nginx]: <https://www.nginx.com/>
