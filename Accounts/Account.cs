namespace WestCoastEducation;

public abstract class Account {
    public required Address Address { get; set; }
    public DateTime TimeOfCreationDate { get; set; }
    //abstract (över virtual) enum här för att account behöver bara känna till och readonly sina childs ..och det tvingar childs att sätta sin accounttype
    public abstract AccountType AccountType { get; } //muckat riktigt jävla mycket med LLM om det här, fuck C#'s enums....

    /*
    - ADMIN - (mest för att sköta det tekniska "under the hood" på plattformen)
        - adress? (kanske inte faktiskt)
        - Godmode access (toolkits för att skapa diverse)
        - Hur separerar jag kontotypen säkert ifrån resterande, bara enums?...?

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

    - LÄRARE -
        - adress
        - "kunskapsområde" (ex: språklärare, natur, historia, samhälle, bild, IT, Svampbruksmentor)
        - assigned kurser, dvs kurser läraren är knuten/ansvarar/håller i (hyfsat dynamiskt ändrade, dock static för köpte on-demand kurserna)


    - ELEV/KUND/FÖRETAGSKUND -
        - adress
        - pågående utbildning/köpta kurser
    */
}
