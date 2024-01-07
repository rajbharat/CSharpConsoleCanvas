FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ConsoleCanvas.csproj .
RUN dotnet restore "ConsoleCanvas.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "ConsoleCanvas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsoleCanvas.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./ConsoleCanvas"]
