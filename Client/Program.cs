// Создаем HttpClient
// Создаем HttpClient
var client = new HttpClient();

// Устанавливаем базовый адрес для всех запросов
client.BaseAddress = new Uri("http://localhost:80");

// Выполняем GET запрос
await GetExample(client);

// Выполняем HEAD запрос
await HeadExample(client);

static async Task GetExample(HttpClient client)
{
    Console.WriteLine("//////////////////////////////////////////");
    var response = await client.GetAsync("/index.html");
    var content = await response.Content.ReadAsStringAsync();
    Console.WriteLine($"GET Response:\n{content}");
    var headers = response.Headers;
    var statusCode = response.StatusCode;
    

    Console.WriteLine($"HEAD Response:");
    Console.WriteLine($"Status Code: {statusCode}");
    Console.WriteLine($"Connection: {headers.Connection}");
}

static async Task HeadExample(HttpClient client)
{
    Console.WriteLine("//////////////////////////////////////////");
    var request = new HttpRequestMessage(HttpMethod.Head, "/index.html");
    var response = await client.SendAsync(request);
    var headers = response.Headers;
    var statusCode = response.StatusCode;
    

    Console.WriteLine($"HEAD Response:");
    Console.WriteLine($"Status Code: {statusCode}");
    Console.WriteLine($"Connection: {headers.Connection}");
   
}