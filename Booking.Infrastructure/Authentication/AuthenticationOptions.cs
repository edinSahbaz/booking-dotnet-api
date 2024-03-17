namespace Booking.Infrastructure.Authentication;

public sealed class AuthenticationOptions
{
    public string Audience { get; init; } = string.Empty;
    
    public string MetadataUrl { get; init; } = string.Empty;

    public bool RequireHttpsMetadata { get; init; }

    public string Issuer { get; init; } = string.Empty;
}