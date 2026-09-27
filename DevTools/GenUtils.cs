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
        Console.WriteLine("\nPress 'Enter' To Continue...");
        Console.ReadLine();
    }
    public static void WriteColour(string str, ConsoleColor colour) {
        Console.ForegroundColor = colour;
        Console.Write(str);
        Console.ResetColor();
    }
    public static void WriteColourLine(string str, ConsoleColor colour) { //"Colour" FÖRE "Line" så dyker den lättare upp i intellsense's auto-correct när man ska åt den...
        Console.ForegroundColor = colour;
        Console.WriteLine(str);
        Console.ResetColor();
    }

    /*
        TODO:
            FÖRSÖK HITTA PÅ FLERTAL OVERLOAD METODER FÖR MENYER SÅ JAG SLIPPER GÖRA SWITCH CASE SKITEN FÖR VARJE LITEN SELECT-STUFF FUNKTION
            SOM JAG SKAPAR... (premade menu templates som bara matar in parametrar och sköter all up/ned/Enter logik automatiskt...)
    */
}
