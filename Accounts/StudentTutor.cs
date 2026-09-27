namespace WestCoastEducation;

public class StudentTutor : Account, IAdminRights {
/*
    - UTBILDNINGSLEDARE -
        - adress
        - Godmode access (toolkits för att skapa diverse, även mycket statistical overview på allt)
    
    (frågade LLM vad en utbildningsledare gör I don't fucking know the details, paranteserna är mina kommentarer...):
        - Planerar utbildning:
            - Ser till att kursupplägg, schema, moduler och lärandemål hänger ihop (okay, betyder att de behöver kunna bygga 
              program och kurser på plattformen...)

        - Koordinerar Lärare och Föreläsare:
            - Säkerställer att rätt kompetens finns på rätt plats (delvis off-platform work, de behöver bara tillgång till bra överssikt eller nått)
        
        - Kvalitetsäkrar Innehåll:
            - Granskar kursmaterial, uppgifer, prov och pedagogisk struktur (again, behov av översiktstillgång)
        
        - Följer Upp Resultat och Progression:
            - Ser till att studenter når målen och att utbildningen fungerar som tänkt (same och även off-platform shid)

        - Administrerar Utbildningen:
            - Hanterar antagningen, dokumentation, kommunikation och praktiska detaljer (yeah, lite admin nivå stuff igen)

        - Utvecklar Utbildningsutbudet:
            - Identifierar behov, föreslår nya kurser, uppdaterar befintliga (yeah igen, mycket tillgång till statistik och översikt på plattformen...)
*/
    public string AdminID => $"ADMIN-{Address.FirstName}.{Address.LastName}";
    public override AccountType AccountType => AccountType.StudentTutor;
    public CourseAdminTool CourseAdminTool { get; }
    public AccountAdminTool AccountAdminTool { get; }
    //CONSTRUCTOR
    public StudentTutor() {
        CourseAdminTool = new CourseAdminTool(this);
        AccountAdminTool = new AccountAdminTool(this);
        //du injicerar hela f0kin Admin-kontot med all dess ID info in i tool-objektet
        //...med syftet att du INUTI tool-objekt då skrivit logik om vilket konto gör vad med admin tools...
        //Ex: ADMIN-Bengt.Burk removed StudentAccount "Mulle Meck", reason: luktade äckligt
        //...sånna grejer
    }
}
