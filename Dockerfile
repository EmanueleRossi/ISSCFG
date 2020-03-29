FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
RUN git clone https://github.com/EmanueleRossi/ISSCFG.git
WORKDIR /ISSCFG
RUN dotnet restore
RUN dotnet publish -c Release -o out
WORKDIR /ISSCFG/out
ENV ASPNETCORE_URLS http://*:$PORT
ENTRYPOINT ["dotnet", "ISSCFG.dll", "--environment", "Production", "--port", "$PORT"]