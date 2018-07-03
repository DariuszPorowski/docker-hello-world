FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS base
LABEL maintainer="Dariusz Porowski <Dariusz.Porowski@microsoft.com>"
COPY sshd_config /etc/ssh/
COPY init_container.sh /bin/
RUN apk add --no-cache openssh-server \
	&& echo "root:Docker!" | chpasswd \
	&& apk update \
	&& apk add --no-cache openrc \
	&& rc-status \
	&& touch /run/openrc/softlevel \
	&& chmod +x /bin/init_container.sh \
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
ENTRYPOINT ["/bin/init_container.sh", "dotnet", "docker-hello-world.dll"]