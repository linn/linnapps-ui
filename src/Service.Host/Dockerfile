﻿FROM microsoft/dotnet:2.1-aspnetcore-runtime
ARG gitBranch=unspecified

EXPOSE 5050

COPY bin/release/netcoreapp2.1/publish/ /app/bin/
     
ENV APP_PATH /app/
ENV GIT_BRANCH $gitBranch

WORKDIR /app/bin
CMD dotnet Linn.LinnappsUi.Service.Host.dll