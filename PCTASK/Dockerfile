FROM mcr.microsoft.com/dotnet/core/sdk:3.1  AS build-env
WORKDIR /app
# Copy everything else and build
COPY . ./
Run dotnet restore
RUN dotnet publish PCTASK.API -c Release -o /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
# RUN apt-get update && apt-get install libunwind8 libunwind8-dev -y
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PCTASK.API.dll", "--environment='Production'"]