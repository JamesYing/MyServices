FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["JCSoft.MyServices/JCSoft.MyServices.csproj", "JCSoft.MyServices/"]
COPY ["JCSoft.MyServices.WebCore/JCSoft.MyServices.WebCore.csproj", "JCSoft.MyServices.WebCore/"]
RUN dotnet restore "./JCSoft.MyServices/JCSoft.MyServices.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "JCSoft.MyServices/JCSoft.MyServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JCSoft.MyServices/JCSoft.MyServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JCSoft.MyServices.dll"]