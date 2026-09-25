using System.Drawing;
using System.Runtime.InteropServices.Marshalling;

namespace WestCoastEducation;

public static class GenUtils {
    public static List<Address>? AddressLista;
    public static Address AdressGenerator(
    string first, string last, string? pref,
    string phone, string email, string pnr,
    string street, string region, string zip, string city) {
        return new Address {
            FirstName = first,
            LastName = last,
            PreferredName = pref,
            PhoneNumber = phone,
            Email = email,
            PersonNumber = pnr,
            StreetAddress = street,
            Region = region,
            PostalCode = zip,
            City = city
        };
}
    public static List<Address> GenerateSix() {
        return new List<Address> {
            AdressGenerator("Anna",   "Lindström", "Annie", "070-1234567", "anna@example.com",   "19900115-1234", "Sveavägen 12",        "Stockholms län",       "11157", "Stockholm"),
            AdressGenerator("Johan",  "Berg",       null,   "073-9876543", "johan@example.com",  "19850622-5678", "Storgatan 5",         "Västra Götalands län", "41124", "Göteborg"),
            AdressGenerator("Elin",   "Sundqvist", "Elli",  "072-5554433", "elin@example.com",   "19970303-3344", "Kungsgatan 44",       "Uppsala län",          "75318", "Uppsala"),
            AdressGenerator("Marcus", "Holm",       null,   "076-1122334", "marcus@example.com", "19921112-9988", "Östra Larmgatan 2",   "Västra Götalands län", "41107", "Göteborg"),
            AdressGenerator("Sara",   "Nyberg",    "Sara",  "070-7788990", "sara@example.com",   "19981230-5566", "Norrlandsgatan 18",   "Stockholms län",       "11143", "Stockholm"),
            AdressGenerator("Oskar",  "Viklund",    null,   "073-2211445", "oskar@example.com",  "19890319-1122", "Rådhusesplanaden 10", "Västerbottens län",    "90328", "Umeå")
        };
    }
    public static void PressToContinue() {
        Console.WriteLine("Press 'Enter' To Continue...");
        Console.ReadLine();
    }
    public static void WriteColourLine(string str, ConsoleColor colour) {
        Console.ForegroundColor = colour;
        Console.WriteLine(str);
        Console.ResetColor();
    }
/*
FirstName: Anna, LastName: Lindström, PreferredName: Annie, PhoneNumber: 070-1234567, Email: anna.lindstrom@example.com, PersonNumber: 19900115-1234, StreetAddress: Sveavägen 12, Region: Stockholms län, PostalCode: 11157, City: Stockholm

FirstName: Johan, LastName: Berg, PreferredName: (saknas), PhoneNumber: 073-9876543, Email: johan.berg@example.com, PersonNumber: 19850622-5678, StreetAddress: Storgatan 5, Region: Västra Götalands län, PostalCode: 41124, City: Göteborg

FirstName: Elin, LastName: Sundqvist, PreferredName: Elli, PhoneNumber: 072-5554433, Email: elin.sundqvist@example.com, PersonNumber: 19970303-3344, StreetAddress: Kungsgatan 44, Region: Uppsala län, PostalCode: 75318, City: Uppsala

FirstName: Marcus, LastName: Holm, PreferredName: (saknas), PhoneNumber: 076-1122334, Email: marcus.holm@example.com, PersonNumber: 19921112-9988, StreetAddress: Östra Larmgatan 2, Region: Västra Götalands län, PostalCode: 41107, City: Göteborg

FirstName: Sara, LastName: Nyberg, PreferredName: Sare, PhoneNumber: 070-7788990, Email: sara.nyberg@example.com, PersonNumber: 19981230-5566, StreetAddress: Norrlandsgatan 18, Region: Stockholms län, PostalCode: 11143, City: Stockholm

FirstName: Oskar, LastName: Viklund, PreferredName: (saknas), PhoneNumber: 073-2211445, Email: oskar.viklund@example.com, PersonNumber: 19890319-1122, StreetAddress: Rådhusesplanaden 10, Region: Västerbottens län, PostalCode: 90328, City: Umeå

*/
}
