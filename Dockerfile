# === Build stage ===
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY *.sln .
COPY StudyTracker/*.csproj ./StudyTracker/
RUN dotnet restore

# Copy everything and build
COPY . .
WORKDIR /src/StudyTracker
RUN dotnet publish -c Release -o /app/publish

# === Runtime stage ===
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port (Render will use PORT env var)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "StudyTracker.dll"]
