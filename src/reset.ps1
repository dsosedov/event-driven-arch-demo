if (Test-Path Toons.sqlite3) {
	rm Toons.sqlite3
}

if (Test-Path Jedis.sqlite3) {
	rm Jedis.sqlite3
}

if (Test-Path Siths.sqlite3) {
	rm Siths.sqlite3
}

dotnet ef database update --project SwWebServiceRabbit\SwWebServiceRabbit.Web\
dotnet ef database update --project JediWebService\JediWebService.Web\
dotnet ef database update --project SithWebService\SithWebService.Web\
