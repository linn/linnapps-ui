FROM microsoft/dotnet:2.1-runtime

COPY bin/release/netcoreapp2.1/publish/ /app/bin/

WORKDIR /app/bin

CMD dotnet Linn.LinnappsUi.Messaging.Host.dll