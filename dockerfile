# Use the .NET SDK to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project file and restore dependencies
COPY BolsaDeValores.csproj ./
RUN dotnet restore BolsaDeValores.csproj

# Copy the rest of the files and build the app
COPY . ./
RUN dotnet publish BolsaDeValores.csproj -c Release -o /app/out

# Use the smaller runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0

# Set working directory for runtime
WORKDIR /app

# Copy built application from previous stage
COPY --from=build /app/out .

# Run the console application
ENTRYPOINT ["dotnet", "BolsaDeValores.dll"]
