FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
RUN git clone https://github.com/EmanueleRossi/ISSCFG.git
WORKDIR /ISSCFG
RUN dotnet restore
RUN dotnet publish -c Production -o out
WORKDIR /ISSCFG/out
EXPOSE 8080 22
RUN useradd -p $(openssl passwd -1 password) erossi
RUN usermod -aG sudo erossi  
RUN apt-get update -y
RUN apt install openssh-server -y
RUN sed -i 's/#Port 22/Port 8080/g' /etc/ssh/sshd_config
RUN sed -i 's/#ListenAddress/ListenAddress/g' /etc/ssh/sshd_config
RUN /etc/init.d/ssh start
ENV ASPNETCORE_URLS http://*:8081
ENV ASPNETCORE_ENVIRONMENT Production
ENTRYPOINT ["dotnet", "ISSCFG.dll"]