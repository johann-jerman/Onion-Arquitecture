FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY *.sln ./
COPY Application/*.csproj ./Application/
COPY Configuration/*.csproj ./Configuration/
COPY DataAccess/*.csproj ./DataAccess/
COPY Domain/*.csproj ./Domain/
COPY WebApi/*.csproj ./WebApi/

RUN dotnet restore

COPY . ./
WORKDIR app/WebApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/WebApi/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "WebApi.dll"]