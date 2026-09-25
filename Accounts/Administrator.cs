namespace WestCoastEducation;

public class Administrator : Account, IAdminRights {
/*
    - ADMIN - (mest för att sköta det tekniska "under the hood" på plattformen)
        - adress? (kanske inte faktiskt)
        - Godmode access (toolkits för att skapa diverse)
        - Hur separerar jag kontotypen säkert ifrån resterande, bara enums?...?
*/
    //INTERFACE REQ. FUNGERAR SOM NYCKEL TILL ATT KOMMA ÅT ADMIN-PRIV KLASSER SOM HAR FUNKTIONER/TOOLS FÖR UNDER-THE-HOOD STUFF PÅ PLATTFORMEN
        //(om jag förstår det rätt så:) Att kontot ens har fältet agerar som nyckel (funkar utan värde assigned, in theory ..utöver att interface kräver dess existens)
        //värde fungerar ej som nyckel utan bara som ID för vilket Admin-konto som gjort vad
    public string AdminID => $"ADMIN-{Address.FirstName}.{Address.LastName}";
    public override AccountType AccountType => AccountType.Admin;

    public AccountAdminTool AccountAdminTool { get; }

    //CONSTRUCTOR
    Administrator() {
        AccountAdminTool = new AccountAdminTool(this); 
        //du injicerar hela f0kin Admin-kontot med all dess ID info in i tool-objektet
        //...med syftet att du INUTI tool-objekt då skrivit logik om vilket konto gör vad med admin tools...
        //Ex: ADMIN-Bengt.Burk removed StudentAccount "Mulle Meck", reason: luktade äckligt
        //...sånna grejer
    }
}
