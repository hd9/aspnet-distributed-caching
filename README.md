# aspnet-distributed-caching
Sample repo to demo an ASP.NET Core 3.1 website distributed
caching with Docker, MongoDB, Redis using Docker Compose.

This is a sample application to demo Microservices in .NET
using [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet),
[Docker](https://www.docker.com/),
[Docker Compose](https://docs.docker.com/compose/), 
[MongoDB](https://www.mongodb.com/), [MySQL](https://www.mysql.com/) and
[Redis](https://redis.io/), [Vue.js](https://vuejs.org/).

## Read the Article
To understand how to use this repo, make sure you read this article:
[Distributed caching in ASP.NET Core using Redis, MongoDB and Docker](https://blog.hildenco.com/2020/12/distributed-caching-in-aspnet-core.html)

## Source Code
The source code is available at
[github.com/hd9/aspnet-microservices](https://github.com/hd9/aspnet-distributed-caching).

## Dependencies
* Visual Studio 2019
* Docker Desktop (Windows and Mac) or 
* Docker compose


## Running the project
First, open the solution with Visual Studio and run it as
debug (F5).

Next, run the dependencies by running the below command
from the `src` folder:
```s
docker-compose up
```

To shutdown and remove all services, run
from the `src` project:
```s
docker-compose down -v
```

## License
This project is licensed under
[the MIT License](https://opensource.org/licenses/MIT).

## Final Thoughts
To learn more about this app, ASP.NET Core, Docker, Azure, Kubernetes,
Linux and microservices, check my blog at:
[blog.hildenco.com](https://blog.hildenco.com)

