namespace WestCoastEducation;

public record Address {
    public required string FirstName { get; set; } //kom ihåg att auto-simplifiera apostrofer(`´) och sådant till det där simpla hacket (')
    public required string LastName { get; set; }
    public string? PreferredName { get; set; } //OPTIONAL(resort:ar till FirstName annars): efter ifyllnad kör man en regex-check om det matchar någon form i FirstName...
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string PersonNumber { get; set; }
    public required string StreetAddress { get; set; }
    public required string Region { get; set; }
    public required string PostalCode { get; set; }
    public required string City { get; set; }
}
