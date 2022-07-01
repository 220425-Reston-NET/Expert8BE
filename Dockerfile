
from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

workdir /app

#copy the publish folder

copy /publish ./


entrypoint ["dotnet", "Expert8Api.dll"]

#expose to port 80
expose 5000

env ASPNETCORE_URLS=http://+:5000