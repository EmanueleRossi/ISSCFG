FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
RUN git clone https://github.com/EmanueleRossi/ISSCFG.git
WORKDIR /ISSCFG
RUN dotnet restore
RUN dotnet publish -c Production -o out
WORKDIR /ISSCFG/out
EXPOSE 8080 5433 5432
ENV ASPNETCORE_URLS http://*:8080
ENV ASPNETCORE_ENVIRONMENT Production
ENTRYPOINT ["dotnet", "ISSCFG.dll"]