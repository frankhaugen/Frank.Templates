FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Frank.Templates.SemanticKernel/Frank.Templates.SemanticKernel.csproj", "Frank.Templates.SemanticKernel/"]
RUN dotnet restore "Frank.Templates.SemanticKernel/Frank.Templates.SemanticKernel.csproj"
COPY . .
WORKDIR "/src/Frank.Templates.SemanticKernel"
RUN dotnet build "Frank.Templates.SemanticKernel.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Frank.Templates.SemanticKernel.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Frank.Templates.SemanticKernel.dll"]