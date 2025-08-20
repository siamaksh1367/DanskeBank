using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

public class HttpRequestBuilder
{
    private HttpRequestMessage _httpRequestMessage;
    private Uri _url;
    private readonly HttpClient _httpClient;
    public HttpRequestBuilder(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Project");
        _httpRequestMessage = new HttpRequestMessage();
    }
    internal HttpRequestBuilder SetJsonContent<T>(T content)
    {
        var json = JsonSerializer.Serialize(content);
        _httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");
        return this;
    }
    public async Task<T> ExecuteAsync<T>()
    {
        HttpResponseMessage result;

        try
        {
            result = await _httpClient.SendAsync(_httpRequestMessage);
        }
        catch (Exception ex)
        {
            throw new Exception("Connection failed: " + ex.Message, ex);
        }

        switch (result.StatusCode)
        {
            case System.Net.HttpStatusCode.OK:
                break;

            case System.Net.HttpStatusCode.Unauthorized:
                throw new Exception("You are not authorized to access this resource.");

            case System.Net.HttpStatusCode.Forbidden:
                throw new Exception("You do not have permission to access this resource.");

            case System.Net.HttpStatusCode.NotFound:
                throw new Exception("The requested resource was not found.");

            case System.Net.HttpStatusCode.BadRequest:
                throw new Exception("The request was invalid. Please check your input.");

            case System.Net.HttpStatusCode.InternalServerError:
                throw new Exception("An internal server error occurred. Please try again later.");

            default:
                throw new Exception($"An unexpected error occurred. Status code: {result.StatusCode} - {result.ReasonPhrase}");
        }

        var responseObject = await result.Content.ReadFromJsonAsync<T>();

        _httpRequestMessage = new HttpRequestMessage
        {
            RequestUri = _url
        };

        return responseObject;
    }

    public HttpRequestBuilder AddUserAgent(string userAgent)
    {
        _httpRequestMessage.Headers.UserAgent.ParseAdd(userAgent);
        return this;
    }
    internal HttpRequestBuilder AssignEndpoint(string endPoint)
    {
        var url = new Uri(_httpClient.BaseAddress, endPoint);
        _httpRequestMessage.RequestUri = url;
        _url = url;
        return this;
    }
    internal HttpRequestBuilder AppendEndpoint(string appendix)
    {
        appendix = appendix.TrimStart('/');
        var baseUri = _httpRequestMessage.RequestUri ?? _httpClient.BaseAddress;
        var newUri = new Uri(baseUri, appendix);
        _httpRequestMessage.RequestUri = newUri;
        return this;
    }

    internal HttpRequestBuilder SetMethod(HttpMethod method)
    {
        _httpRequestMessage.Method = method;
        return this;
    }
    internal HttpRequestBuilder SetMethod(string method)
    {
        _httpRequestMessage.Method = new HttpMethod(method);
        return this;
    }
    internal HttpRequestBuilder AddHeader(string name, string value)
    {
        _httpRequestMessage.Headers.Add(name, value);
        return this;
    }
    internal HttpRequestBuilder AddBearerToken(string token)
    {
        _httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return this;
    }
    internal HttpRequestBuilder SetStringContent(string content, string mediaType = "text/plain")
    {
        _httpRequestMessage.Content = new StringContent(content, Encoding.UTF8, mediaType);
        return this;
    }
    internal HttpRequestBuilder AddQueryParameter(string name, string value)
    {
        name = name.Trim().ToLower();
        value = value.Trim().ToLower();

        if (_httpRequestMessage.RequestUri == null || !_httpRequestMessage.RequestUri.IsAbsoluteUri)
        {
            throw new InvalidOperationException("The RequestUri must be an absolute URI before adding query parameters.");
        }

        var uriBuilder = new UriBuilder(_httpRequestMessage.RequestUri);
        var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
        query[name] = value;
        uriBuilder.Query = query.ToString();
        _httpRequestMessage.RequestUri = uriBuilder.Uri;
        return this;
    }

    internal HttpRequestBuilder AddQueryParameters(params (string name, string value)[] parameters)
    {
        foreach (var (name, value) in parameters)
        {
            AddQueryParameter(name, value);
        }
        return this;
    }

}