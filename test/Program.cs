using System.Net.Http.Json;
using test;

class Program
{
    static void Main()
    {
        MyProduct temp = new MyProduct(){id = 1, name = "Chai1"};
        HttpClient client = new HttpClient( );
        client.BaseAddress = new Uri("http://localhost:5092");
        Task<HttpResponseMessage> request =  client.PutAsJsonAsync(
            $"api/product/", temp);
        Task<Stream> stream1 = request.Result.Content.ReadAsStreamAsync();
        StreamReader sr1 = new StreamReader(stream1.Result);
        string data1 = sr1.ReadToEnd();
        //Thread.Sleep(200);
        Console.Write(data1);
    }
}