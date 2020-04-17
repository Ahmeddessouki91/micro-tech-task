# Pctask

## Development server

### FrontEnd

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`.

### Backend

#### Visual Studio code

RUN `dotnet ef database update -s ./PCTASK.API -p ./PCTASK.Data`
Run `dotnet run -p ./PCTASK.API` for a dev server. Navigate to `http://localhost:5001/`.

#### Visual Studio

Run `Update database` in Package console manager
then run API project

## Docker

Create new file .env contains
DB_PASSWORD=YourdbPassword
Run `docker-compose up --build -d` and you will have 3 containers Sql Server:1433, Frontend:8080 and API:80
