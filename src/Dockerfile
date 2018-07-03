FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS base
LABEL maintainer="Dariusz.Porowski@microsoft.com"
COPY ./entrypoint.sh /
RUN apk add --no-cache openssh-server \
	&& sed -i s/#PermitRootLogin.*/PermitRootLogin\ yes/ /etc/ssh/sshd_config \
	&& echo "root:Docker!" | chpasswd \
	&& apk update \
	&& apk add --no-cache openrc \
	&& rc-status \
	&& touch /run/openrc/softlevel \
	&& chmod +x /entrypoint.sh \
	&& rm -rf /var/cache/apk/* /tmp/*
WORKDIR /app
EXPOSE 80 2222

FROM microsoft/dotnet:2.1-sdk-alpine AS build
COPY . /src/app/
WORKDIR /src/app
RUN dotnet restore && dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
COPY --from=publish /app .
ENTRYPOINT ["/entrypoint.sh", "dotnet", "docker-hello-world.dll"]