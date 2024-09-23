# Use an official .NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

# Use an official .NET Core SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["SocialMedia.csproj", "./"]
RUN dotnet restore "./SocialMedia.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "SocialMedia.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "SocialMedia.csproj" -c Release -o /app/publish

# Final stage: Use the base image with the published app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SocialMedia.dll"]
