# === Build stage ===
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project file
COPY StudyTracker.sln .
COPY StudyTracker.csproj ./

# Restore dependencies
RUN dotnet restore

# Copy the rest of the source
COPY . .

# Publish app
RUN dotnet publish -c Release -o /app/publish

# === Runtime stage ===
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Render expects apps to listen on port 8080
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "StudyTracker.dll"]
