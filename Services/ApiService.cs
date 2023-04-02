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

    public async Task<List<Data>?> GetDataAsync()
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

    public async Task<Data> GetDataByIdAsync(string id)
    {
        var response = await _httpClient.GetAsync($"https://nocodebackend.azurewebsites.net/api/v1/dataset/6428c0b146374be4567806ce/611ed902fd5915f2ae005dbb/{id}?apiKey=6426ce03da79fc544c8e1406 ");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Data>();
        }
        else
        {
            throw new Exception($"Failed to get data with id {id}: {response.ReasonPhrase}");
        }
    }

    public async Task<HttpResponseMessage> CreateDataAsync(DataPost dataPost)
    {
        var apiUrl = "https://nocodebackend.azurewebsites.net/api/v1/dataset/6428c0b146374be4567806ce/611ed902fd5915f2ae005dbb?apiKey=6426ce03da79fc544c8e1406";
        
        var json = JsonConvert.SerializeObject(dataPost);
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

    public async Task<HttpResponseMessage> UpdateDataAsync(string id, DataUpdate dataUpdate)
    {
        var endpoint = $"https://nocodebackend.azurewebsites.net/api/v1/dataset/6428c0b146374be4567806ce/611ed902fd5915f2ae005dbb/{id}?apiKey=6426ce03da79fc544c8e1406";

        var payload = new StringContent(JsonConvert.SerializeObject(dataUpdate),  Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(endpoint, payload);

        return response;
    }

}
