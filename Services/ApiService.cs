using System.Net.Http.Json;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Data>> GetDataAsync()
    {
        try
        {
            var apiUrl = "https://nocodebackend.azurewebsites.net/api/v1/dataset/6426cf2fda79fc544c8e1409/611ed902fd5915f2ae005dbb?apiKey=6426ce03da79fc544c8e1406";
            var rootObject = await _httpClient.GetFromJsonAsync<RootObject>(apiUrl);
            return rootObject.Data;
        }
        catch
        {
            return null;
        }
    }

    public async Task<HttpResponseMessage> CreateDataAsync(Data data)
    {
        var apiUrl = "https://nocodebackend.azurewebsites.net/api/v1/dataset/6426cf2fda79fc544c8e1409/611ed902fd5915f2ae005dbb?apiKey=6426ce03da79fc544c8e1406";
        
        var json = JsonConvert.SerializeObject(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(apiUrl, content);

        return response;
    }



    public async Task<HttpResponseMessage> DeleteDataAsync(string id)
    {
        var endpoint = $"https://nocodebackend.azurewebsites.net/api/v1/dataset/6426cf2fda79fc544c8e1409/611ed902fd5915f2ae005dbb/{id}?apiKey=6426ce03da79fc544c8e1406";

        var response = await _httpClient.DeleteAsync(endpoint);

        return response;
    }
}
