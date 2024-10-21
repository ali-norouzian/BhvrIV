FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY src/Api/BhvrIV.Api/BhvrIV.Api.csproj src/Api/BhvrIV.Api/
COPY src/Core/BhvrIV.Application/BhvrIV.Application.csproj src/Core/BhvrIV.Application/
COPY src/Core/BhvrIV.Domain/BhvrIV.Domain.csproj src/Core/BhvrIV.Domain/
COPY src/Infrastructure/BhvrIV.Persistence.Ef/BhvrIV.Persistence.Ef.csproj src/Infrastructure/BhvrIV.Persistence.Ef/
COPY src/Infrastructure/BhvrIV.Persistence.Sql/BhvrIV.Persistence.Sql.csproj src/Infrastructure/BhvrIV.Persistence.Sql/

RUN dotnet restore src/Api/BhvrIV.Api/BhvrIV.Api.csproj

COPY . .
WORKDIR ./src/Api/BhvrIV.Api
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "BhvrIV.Api.dll"]
