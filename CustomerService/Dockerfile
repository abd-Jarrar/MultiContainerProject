FROM mcr.microsoft.com/dotnet/sdk:10.0 as build
WORKDIR /src
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c release -o output
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /src/output .
ENV ASPNETCORE_HTTP_PORTS=5164
EXPOSE 5164
ENTRYPOINT ["dotnet","CustomerService.dll"]
