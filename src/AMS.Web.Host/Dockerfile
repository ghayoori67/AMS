FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/AMS.Web.Host/AMS.Web.Host.csproj", "src/AMS.Web.Host/"]
COPY ["src/AMS.Web.Core/AMS.Web.Core.csproj", "src/AMS.Web.Core/"]
COPY ["src/AMS.Application/AMS.Application.csproj", "src/AMS.Application/"]
COPY ["src/AMS.Core/AMS.Core.csproj", "src/AMS.Core/"]
COPY ["src/AMS.EntityFrameworkCore/AMS.EntityFrameworkCore.csproj", "src/AMS.EntityFrameworkCore/"]
WORKDIR "/src/src/AMS.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/AMS.Web.Host", "src/AMS.Web.Host"]
COPY ["src/AMS.Web.Core", "src/AMS.Web.Core"]
COPY ["src/AMS.Application", "src/AMS.Application"]
COPY ["src/AMS.Core", "src/AMS.Core"]
COPY ["src/AMS.EntityFrameworkCore", "src/AMS.EntityFrameworkCore"]
WORKDIR "/src/src/AMS.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "AMS.Web.Host.dll"]
