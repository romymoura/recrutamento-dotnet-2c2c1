@ECHO OFF

CALL npm install -g newman
CALL newman run "Dotnet2C2C1.postman_collection.json" -e LOCALHOST.postman_environment.json -d DATA.postman_data.json
