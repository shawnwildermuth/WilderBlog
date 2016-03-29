FROM microsoft/aspnet

COPY . /app
WORKDIR /app/WilderBlog
RUN ["dnu", "restore"]

EXPOSE 5000/tcp
ENTRYPOINT ["dnx", "web"]
