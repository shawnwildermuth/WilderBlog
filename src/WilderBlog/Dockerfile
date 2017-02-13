FROM microsoft/aspnetcore

WORKDIR /theapp

ENV ASPNETCORE_ENVIRONMENT Staging

# copy project.json and restore as distinct layers
COPY . .
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "WilderBlog.dll"]