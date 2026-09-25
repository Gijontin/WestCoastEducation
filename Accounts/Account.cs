namespace WestCoastEducation;

public abstract class Account {
    public required Address Address { get; set; }
    public DateTime TimeOfCreationDate { get; set; }
    //abstract (över virtual) enum här för att account behöver bara känna till och readonly sina childs ..och det tvingar childs att sätta sin accounttype
    public abstract AccountType AccountType { get; } //muckat riktigt jävla mycket med LLM om det här, fuck C#'s enums....
}
