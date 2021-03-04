FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM wilderminds/net5-npm:15.0 AS build
WORKDIR /src
COPY ["WilderBlog/WilderBlog.csproj", "WilderBlog/"]
COPY ["WilderBlog.Data/WilderBlog.Data.csproj", "WilderBlog.Data/"]
RUN dotnet restore "WilderBlog/WilderBlog.csproj"
COPY . .
WORKDIR "/src/WilderBlog"
RUN npm ci
RUN npm run purge

RUN dotnet build "WilderBlog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WilderBlog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WilderBlog.dll"]