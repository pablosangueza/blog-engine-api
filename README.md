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

![alt text](https://github.com/pablosangueza/blog-engine-api/blob/main/ExternalResources/SwaggerAPI.png)

## Run Application with Docker

```bash
docker build -t blogengineapi .
```

```bash
docker run -it --rm -p 5000:80 --name myapi blogengineapi
```

## Data Users and Passwords

For time pruposes the the data, users and passwords are hardcoded on Repository component on a static class 
[HardCodeData.cs](https://github.com/pablosangueza/blog-engine-api/blob/main/BlogEngine.Repository/HardCodeData.cs)

```c#
            Users.Add(new User()
            {
                Name = "Pablo Sangueza",
                Username = "psangueza",
                Password = "Password1",
                Role = UserRole.Writer
            });
             Users.Add(new User()
            {
                Name = "John MacArthur",
                Username = "jmacarthur",
                Password = "Password3",
                Role = UserRole.Writer
            });
            Users.Add(new User()
            {
                Name = "Luis Sangueza",
                Username = "lsangueza",
                Password = "Password2",
                Role = UserRole.Editor
            });
            Users.Add(new User()
            {
                Name = "John Calvin",
                Username = "jcalvin",
                Password = "Password3",
                Role = UserRole.Public
            });
```
