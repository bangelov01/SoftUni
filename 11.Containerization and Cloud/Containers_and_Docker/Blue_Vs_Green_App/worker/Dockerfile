FROM mcr.microsoft.com/dotnet/aspnet:3.1 as base

# Create a working directory
WORKDIR /app

# Copy the .csproj file and restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
WORKDIR /src
COPY ["src/Worker/Worker.csproj", "Worker/"]
RUN dotnet restore "Worker/Worker.csproj"

# Copy source files to the image
COPY src/Worker .

# Build the project
RUN dotnet build "Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Worker.csproj" -c Release -o /app/publish

# Specify app image
FROM base AS final

# Specify working directory for this stage
WORKDIR /app

# Copy the /app directory from the build stage into the runtime image
COPY --from=publish /app/publish .

# Tell Docker what command to run when our image is executed inside a container
ENTRYPOINT ["dotnet", "Worker.dll"]