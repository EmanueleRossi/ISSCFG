FROM mcr.microsoft.com/dotnet/core/3.1-alpine3.11 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
WORKDIR /app
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/core/3.1-alpine3.11 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "ISSCFG.dll"]