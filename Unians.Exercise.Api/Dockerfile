FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Unians.Exercise.Api/Unians.Exercise.Api.csproj", "Unians.Exercise.Api/"]
COPY ["Unians.Exercise.Api.Data/Unians.Exercise.Api.Data.csproj", "Unians.Exercise.Api.Data/"]
COPY ["Unians.Exercise.Data/Unians.Exercise.Data.csproj", "Unians.Exercise.Data/"]
RUN dotnet restore "Unians.Exercise.Api/Unians.Exercise.Api.csproj"
COPY . .
WORKDIR "/src/Unians.Exercise.Api"
RUN dotnet build "Unians.Exercise.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Unians.Exercise.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Unians.Exercise.Api.dll"]