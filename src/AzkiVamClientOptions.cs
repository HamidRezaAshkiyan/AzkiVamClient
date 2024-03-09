namespace AzkiVamClient;

public class AzkiVamClientOptions
{
    public Uri BaseUrl { get; init; } = new("https://api.azkiloan.com/");
    public string MerchantId { get; init; } = "980213";
    public string ApiKey { get; init; } = "2c4cdba5aab44ba5fe2e0d931d1565d25839e2b9862565e86afbeef78c0846ca";
}
