using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumindoAPISimples
{

    public class ApiService
    {
        

        public async Task ConsumirAPI(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Fazendo a requisição GET
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Verificando o status da resposta
                    if (response.IsSuccessStatusCode)
                    {
                        // Lendo o conteúdo da resposta como string
                        string content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Resposta da API:");
                        Console.WriteLine(content);


                        /*Parse de JSON com JToken: Usamos JToken.Parse(content) para analisar o JSON e criar um JToken que pode representar tanto um objeto quanto uma lista.

                        Verificação do tipo de JToken: Usamos token.Type para verificar o tipo do JSON:

                        Se o tipo for JTokenType.Array, significa que o JSON é uma lista.
                        Se o tipo for JTokenType.Object, significa que o JSON é um objeto.*/

                        JToken token = JToken.Parse(content);

                        if (token.Type == JTokenType.Array)//VERIFICA SE O RETORNO É UMA LISTA
                        {
                            // Deserializando a resposta JSON para uma lista de usuários
                            List<User> users = JsonConvert.DeserializeObject<List<User>>(content)!;

                            Console.WriteLine();
                            Console.WriteLine("Retorno JSON DESCERIALIZADO");
                            foreach (var user in users)
                            {
                                Console.WriteLine($"ID: {user.userId},\nNome: {user.nameCompleted},\nEmail: {user.email},\nFunction: {user.function},\nPhone: {user.phoneNumber}");
                            }

                        }
                        else if (token.Type == JTokenType.Object)//VERIFICA SE O RETORNO É UM OBJETO
                        {
                            // O JSON é um objeto
                            Console.WriteLine("Retorno JSON DESCERIALIZADO");
                            // Deserializa como um único usuário
                            var user = JsonConvert.DeserializeObject<User>(content);
                            Console.WriteLine($"ID: {user.userId},\nNome: {user.nameCompleted},\nEmail: {user.email},\nFunction: {user.function},\nPhone: {user.phoneNumber}");
                        }

                        }
                    else
                    {
                        Console.WriteLine($"Erro: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao consumir a API: {ex.Message}");
                }
            }
        }

    }




}
