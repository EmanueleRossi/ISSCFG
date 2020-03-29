FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
RUN git clone https://github.com/EmanueleRossi/ISSCFG.git
WORKDIR /ISSCFG
RUN dotnet restore
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /ISSCFG/out ./
EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000
ENTRYPOINT ["dotnet", "ISSCFG.dll"]