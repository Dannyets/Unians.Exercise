FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Exercise.Api/Exercise.Api.csproj", "Exercise.Api/"]
COPY ["Exercise.Api.Models/Exercise.Api.Models.csproj", "Exercise.Api.Models/"]
RUN dotnet restore "Exercise.Api/Exercise.Api.csproj"
COPY . .
WORKDIR "/src/Exercise.Api"
RUN dotnet build "Exercise.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Exercise.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Exercise.Api.dll"]