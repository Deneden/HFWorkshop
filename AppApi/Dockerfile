FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AppApi/AppApi.csproj", "AppApi/"]
RUN dotnet restore "AppApi/AppApi.csproj"
COPY . .
WORKDIR "/src/AppApi"
RUN dotnet build "AppApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppApi.dll"]
