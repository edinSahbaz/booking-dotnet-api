FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Booking.Api/Booking.Api.csproj", "Booking.Api/"]
RUN dotnet restore "Booking.Api/Booking.Api.csproj"
COPY . .
WORKDIR "/src/Booking.Api"
RUN dotnet build "Booking.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Booking.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Booking.Api.dll"]
