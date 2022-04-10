FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["../MyBook.Architecture.Infrastructure/MyBook.Architecture.Infrastructure.csproj", "MyBook.Architecture.Infrastructure/"]
RUN dotnet restore "../MyBook.Architecture.Infrastructure/MyBook.Architecture.Infrastructure.csproj"
COPY . .
WORKDIR "/src/MyBook.Architecture.Infrastructure"
RUN dotnet build "MyBook.Architecture.Infrastructure.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyBook.Architecture.Infrastructure.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyBook.Architecture.Infrastructure.dll"]
