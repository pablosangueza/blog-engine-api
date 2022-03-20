# Blog Engine API



## Prerequisites

Install dotnet core 3.1

## Run Application with dotnet from command line
Go inside directory -> blog-engine-api\BlogEngine.API

Run the following command line:
```bash
dotnet "run" "--project" "BlogEngine.API.csproj"
```
Open Browser on : https://localhost:5001/index.html

Swagger Should be loaded.

![alt text](https://github.com//pablosangueza/blog-engine-api/main/SwaggerAPI.png?raw=true)

## Run Application with Docker


```bash
docker build -t blogengineapi .
```

```bash
docker run -it --rm -p 5000:80 --name myapi blogengineapi
```