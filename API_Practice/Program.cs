using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;



class Program
{
    static readonly HttpClient client = new HttpClient();
    static readonly string baseUrl = "https://jsonplaceholder.typicode.com/posts";

    static async Task GetPost(int id)
    {
        Console.WriteLine("\nGET Post:");
        HttpResponseMessage response = await client.GetAsync($"{baseUrl}/{id}");
        response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();
        Post post = JsonSerializer.Deserialize<Post>(json);

        Console.WriteLine($"Title: {post.Title}");
        Console.WriteLine($"Body: {post.Body}");
    }




    static async Task Main()
    {
        await GetPost(1);
    }
        
}






public class Post
{
    
    [JsonPropertyName("userId")]
    public int UserId {get; set;}

    [JsonPropertyName("id")]
    public int Id {get; set;}
    
    [JsonPropertyName("title")]
    public string Title {get; set;}

    [JsonPropertyName("body")]
    public string Body {get; set;}
    
}
