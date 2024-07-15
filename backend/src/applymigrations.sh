#!/bin/sh

echo "started executing inner async script"

/app/waitforit.sh "db" "3306" "root" "qweasdzxc"

find /app/Database/Schema -type f -name "*.sql" -exec dos2unix {} \;
find /app/Database/PostDeploymentScripts -type f -name "*.sql" -exec dos2unix {} \;

for sql_file in /app/Database/Schema/*.sql; do
  echo "Executing $sql_file.................."
  mysql -h "db" -u "root" -p"qweasdzxc" -P "3306" < "$sql_file"
done

for sql_file in /app/Database/PostDeploymentScripts/*.sql; do
  echo "Executing $sql_file.................."
  mysql -h "db" -u "root" -p"qweasdzxc" -P "3306" < "$sql_file"
done

export PATH="$PATH:/root/.dotnet/tools"

/root/.dotnet/tools/dotnet-ef database update --project "/app/Modules/UserAccess/Infrastructure/AutoHub.Modules.UserAccess.Infrastructure.csproj" --startup-project "/app/Modules/UserAccess/Infrastructure/AutoHub.Modules.UserAccess.Infrastructure.csproj" --configuration Debug
/root/.dotnet/tools/dotnet-ef database update --project "/app/Modules/UserRegistrations/Infrastructure/AutoHub.Modules.UserRegistrations.Infrastructure.csproj" --startup-project "/app/Modules/UserRegistrations/Infrastructure/AutoHub.Modules.UserRegistrations.Infrastructure.csproj" --configuration Debug
/root/.dotnet/tools/dotnet-ef database update --project "/app/Modules/Adverts/Infrastructure/AutoHub.Modules.Adverts.Infrastructure.csproj" --startup-project "/app/Modules/Adverts/Infrastructure/AutoHub.Modules.Adverts.Infrastructure.csproj" --configuration Debug

dotnet /app/publish/AutoHub.API.dll