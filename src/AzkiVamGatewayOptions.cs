namespace AzkiVamClient;

// for demo purposes these are hard coded
public class AzkiVamGatewayOptions
{
    public const string ConfigurationSection =
        nameof(AzkiVamGatewayOptions);

    public string ApiKey { get; init; } = "2c4cdba5aab44ba5fe2e0d931d1565d25839e2b9862565e86afbeef78c0846ca";
    public long ProviderId { get; init; } = 123456;
    public string MerchantId { get; init; } = "980213";

    public Uri BaseUrl { get; init; } = new("https://api.azkiloan.com/");
    public Uri FallBackUrl { get; init; } = new("https://dev.mrbilit.com/");
    public Uri RedirectUrl { get; init; }

    public Uri ConfirmationUrl { get; init; } = new("https://dev.payment.mrbilit.com/api/billpayment/payment-landing");
    public Uri DirectPaymentConfirmationUrl { get; init; } = new("https://dev.payment.mrbilit.com/api/payment/confirm");
}
