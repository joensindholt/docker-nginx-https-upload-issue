FROM microsoft/dotnet:1.1.2-sdk

COPY . ./app
WORKDIR /app
ENV ASPNETCORE_URLS=http://*:5000

CMD ["./start.sh"]

