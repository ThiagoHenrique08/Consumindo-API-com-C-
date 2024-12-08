using ConsumindoAPISimples;

var result = new ApiService();



string getUsersPerEnterprise = "http://191.101.18.75:8080/api/Auth/getUsers?entepriseId=2138da84-eb01-430c-a3e4-194490cd35c9";
string getUsersPerId = "http://191.101.18.75:8080/api/Auth/getUserPerId?UserId=45a73be5-75d6-4d0f-8b04-6294b9925f28";


Console.WriteLine("RESULTADO DO ENDPOINT GET USER PER ENTERPRISE");
await result.ConsumirAPI(getUsersPerEnterprise);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("RESULTADO DO ENDPOINT GET USER PER ID");
await result.ConsumirAPI(getUsersPerId);
Console.WriteLine();
Console.WriteLine();