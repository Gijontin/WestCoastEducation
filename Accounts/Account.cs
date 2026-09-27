namespace WestCoastEducation;

public abstract class Account {
    public required Address Address { get; set; }
    public DateTime TimeOfCreationDate { get; set; }
    //abstract (över virtual) enum här för att account behöver bara känna till och readonly sina childs ..och det tvingar childs att sätta sin accounttype
    public abstract AccountType AccountType { get; } //muckat riktigt jävla mycket med LLM om det här, fuck C#'s enums....
    
    //tror uppgiften poängtera att man skulle göra en fullständig sådanhär
    public override string ToString() {

    //Snabb liten pref. check
        string PrefName = !string.IsNullOrWhiteSpace(Address.PreferredName) ? Address.PreferredName : Address.FirstName;

    //Gör det till en sträng först för lättare översiktlighet innan return:
    //GetType är polymorfism grejen med att parenten vet om vad zeh child iz... (tex student-, lärare-, admin-konto etc)
        string PrintInfo = 
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
========================================";
        return PrintInfo ?? "Något blev fel.";
    }
}
