namespace WestCoastEducation;

public abstract class Account {
    public int AccountID { get; set; }
    public required Address Address { get; set; }
    public DateTime TimeOfCreationDate { get; set; }
    //abstract (över virtual) enum här för att account behöver bara känna till och readonly sina childs ..och det tvingar childs att sätta sin accounttype
    public abstract AccountType AccountType { get; } //muckat riktigt jävla mycket med LLM om det här, fuck C#'s enums....
    public PublicTools PublicTools { get; }

    //KONSTRUKTOR
    public Account() {
           PublicTools = new();
    }
    
    //tror uppgiften poängtera att man skulle göra en fullständig sådanhär
    public override string ToString() { //behöver inga safety checks här ännu eftersom Address är required...
        string PrintInfo = $"KontoID: {AccountID} | KontoTyp: {GetType().Name} | Namn: {Address.FirstName} {Address.LastName}";
        return PrintInfo ?? "Något blev fel.";
    }
    public void ShowAccountInfo() {

    //Snabb liten pref. check
        string PrefName = !string.IsNullOrWhiteSpace(Address.PreferredName) ? Address.PreferredName : Address.FirstName;

    //Gör det till en sträng först för lättare översiktlighet innan return:
        //GetType är polymorfism grejen med att parenten vet om vad zeh child iz... (tex student-, lärare-, admin-konto etc)
        Console.WriteLine(); //litta extra spejs för clarity

/*
        //.NET 11 verkar få en funktion som kan hantera "raw string literals" såhär, men har 10 så får 
        // utkommentera detta och använda den omständiga lösningen under... (pallar inte skriva kod som städar mellanslag och sådant bara för att det
        ska se normalt ut i källkoden...)
        Console.WriteLine(
        $@"========================================
          KONTOINFORMATION ({GetType().Name.ToUpper()})
        ========================================
          Namn:          {PrefName} ({Address.FirstName} {Address.LastName})
          Personnummer:  {Address.PersonNumber}
        ----------------------------------------
          E-post:        {Address.Email}
          Telefon:       {Address.PhoneNumber}
        ----------------------------------------
          Adress:        {Address.StreetAddress}
          Postort:       {Address.PostalCode} {Address.City}
          Region:        {Address.Region}
        ========================================");
*/
        Console.WriteLine(
            "========================================\n" +
            $"      KONTOINFORMATION ({GetType().Name.ToUpper()})\n" +
            "========================================\n" +
            $"  Namn:          {PrefName} ({Address.FirstName} {Address.LastName})\n" +
            $"  Personnummer:  {Address.PersonNumber}\n" +
            "----------------------------------------\n" +
            $"  E-post:        {Address.Email}\n" +
            $"  Telefon:       {Address.PhoneNumber}\n" +
            "----------------------------------------\n" +
            $"  Adress:        {Address.StreetAddress}\n" +
            $"  Postort:       {Address.PostalCode} {Address.City}\n" +
            $"  Region:        {Address.Region}\n" +
            "========================================");
        GenUtils.PressToContinue();
    }
}
