#Instructions to build the Blog Engine API into a Docker container
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS devBase
WORKDIR /src

FROM devBase as build
COPY . .
RUN dotnet build "BlogEngine.API.sln" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BlogEngine.API/BlogEngine.API.csproj" -c Release -o /app

FROM base as final
RUN sed 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/' /etc/ssl/openssl.cnf > /etc/ssl/openssl.cnf.changed && mv /etc/ssl/openssl.cnf.changed /etc/ssl/openssl.cnf
WORKDIR /app

COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BlogEngine.API.dll"]