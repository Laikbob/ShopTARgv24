using Newtonsoft.Json;
using ShopTARgv24.Core.Domain;
public class ChuckNorrisJokeService
{
    private readonly HttpClient _httpClient;

    public ChuckNorrisJokeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetRandomJokeAsync()
    {
        string url = "https://api.chucknorris.io/jokes/random";

        var response = await _httpClient.GetStringAsync(url);
        var joke = JsonConvert.DeserializeObject<ChuckNorrisJoke>(response);

        return joke.Value; 
    }
}