# === Build stage ===
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project file(s)
COPY *.sln .
COPY *.csproj ./

# Restore dependencies
RUN dotnet restore

# Copy everything else
COPY . .

# Publish app
RUN dotnet publish -c Release -o /app/publish

# === Runtime stage ===
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Render expects apps to listen on 8080
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "StudyTracker.dll"]
