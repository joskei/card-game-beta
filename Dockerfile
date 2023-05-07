# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
WORKDIR /src
COPY src/cardGameApp.csproj ./src/cardGameApp.csproj
COPY src .
WORKDIR /tests
COPY tests/cardGameApp.Tests.csproj ./tests/cardGameApp.Tests.csproj
COPY tests .
RUN dotnet restore

#Copy everything else
COPY . ./

#Run tests and publish
FROM build-env as test
CMD ["dotnet","test","tests"]

#RUN dotnet test tests -c Release
RUN dotnet publish src -c Release -o /publish

FROM test as runtime
WORKDIR /publish
COPY --from=test /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "cardGameApp.dll"]