#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ATOCalc/ATOCalc.csproj", "ATOCalc/"]
RUN dotnet restore "ATOCalc/ATOCalc.csproj"
COPY . .
WORKDIR "/src/ATOCalc"
RUN dotnet build "ATOCalc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ATOCalc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ATOCalc.dll"]