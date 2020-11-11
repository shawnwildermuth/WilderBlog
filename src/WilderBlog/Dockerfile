FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster AS build
RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs
WORKDIR /src
COPY ["WilderBlog/WilderBlog.csproj", "WilderBlog/"]
COPY ["WilderBlog.Data/WilderBlog.Data.csproj", "WilderBlog.Data/"]
RUN dotnet restore "WilderBlog/WilderBlog.csproj"
COPY . .
WORKDIR "/src/WilderBlog"
RUN dotnet build "WilderBlog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WilderBlog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WilderBlog.dll"]