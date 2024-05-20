#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Finance.B4.Api/Finance.B4.Api.csproj", "Finance.B4.Api/"]
COPY ["Finance.B4.Application/Finance.B4.Application.csproj", "Finance.B4.Application/"]
COPY ["Finance.B4.Domain/Finance.B4.Domain.csproj", "Finance.B4.Domain/"]
COPY ["Finance.B4.Infra/Finance.B4.Infra.csproj", "Finance.B4.Infra/"]

RUN dotnet restore "Finance.B4.Api/Finance.B4.Api.csproj"
COPY . .
WORKDIR "/src/Finance.B4.Api"
RUN dotnet build "Finance.B4.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Finance.B4.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Finance.B4.Api.dll"]