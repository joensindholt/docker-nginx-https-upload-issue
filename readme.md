# Upload issue with .Net Core, Nginx and Docker

This is a setup for showing a potential bug when uploading large files to a dockerized nginx proxy with a .net core backend.

The issue is only occuring when using Docker For Windows.

## Get started

- Install .NET Core 1.1 from [here](https://www.microsoft.com/net/core)
- Clone the repo
- Run `docker-compose up`. This will build and run an Nginx proxy and the .NET Core api
- Go into `./client`
- Execute `dotnet restore`

You need some file to test with. I did the test with a 1GB file downloaded from [https://www.thinkbroadband.com/download](https://www.thinkbroadband.com/download) or you can generate a file yourself.

Now run the client using `dotnet run -- {file_to_upload} {server} {loopCount}` where:

```
fileToUpload - Path to the test file

server - One of:
  "https://localhost:4443": Test using SSL and Nginx
  "https://localhost:4080": Test using regular http and Nginx
  "https://localhost:5000": Test using regular http and directly to the .NET Core Api

loopCount - The number of times to upload the file. For a 1GB file once seems to be enough to make the issue appear
```