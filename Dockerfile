FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
RUN git clone https://github.com/EmanueleRossi/ISSCFG.git
WORKDIR /ISSCFG
RUN dotnet restore
RUN dotnet publish -c Production -o out
WORKDIR /ISSCFG/out
EXPOSE 8080 22
RUN useradd -p $(openssl passwd -1 password) erossi
RUN usermod -aG sudo erossi  
RUN apt-get update
RUN apt install openssh-server
RUN /etc/init.d/ssh start
ENV ASPNETCORE_URLS http://*:8080
ENV ASPNETCORE_ENVIRONMENT Production
ENTRYPOINT ["dotnet", "ISSCFG.dll"]