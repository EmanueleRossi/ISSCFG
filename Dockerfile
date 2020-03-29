FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
RUN git clone https://github.com/EmanueleRossi/ISSCFG.git
WORKDIR /ISSCFG
RUN dotnet restore
RUN dotnet publish -c Release -o out
WORKDIR /ISSCFG/out
EXPOSE 8080/tcp
ENV ASPNETCORE_URLS http://*:8080
ENV ASPNETCORE_ENVIRONMENT Production
ENTRYPOINT ["dotnet", "ISSCFG.dll"]