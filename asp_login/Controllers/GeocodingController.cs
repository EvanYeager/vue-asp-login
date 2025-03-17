using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class GeocodingController: ControllerBase
{

    private readonly HttpClient httpClient;

    public GeocodingController(HttpClient httpClient) : base()
    {
        this.httpClient = httpClient;
    }

    [HttpGet()]
    public async Task<IActionResult> Geocode([FromQuery] string address)
    {
        try
        {
            // create url
            string encodedAddress = Uri.EscapeDataString(address);
            string url = $"https://geocoding.geo.census.gov/geocoder/locations/onelineaddress?benchmark=4&address={encodedAddress}&format=json";
            // print url
            Console.WriteLine($"Geocoding request URL: {url}");

            // make geocode request
            HttpResponseMessage response = await httpClient.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return Content(content, "application/json");
            }
            else
            {
                return StatusCode((int)response.StatusCode, $"Error from geocoding service: {response.ReasonPhrase}");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}