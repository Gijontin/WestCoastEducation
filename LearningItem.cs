namespace WestCoastEducation;
/*
    PLATTFORMEN SKA TA HÄNSYN TILL EN MIX AV ETT TRADITIONELLA ANSÖKNINGS PROGRAM MEN ÄVEN UDEMY-STYLE BUY2(PERMA)ACCESS KURSER ELLER
    SUBSCRIPTION-BASED FÖR FULL ACCESS UNDER SUBSCRIPTION PERIODEN...

    EN CLASS KAN BARA ÄRVA EN "ABSTRACT" MEN DEN KAN VISST IMPLEMENTERA HUR MÅNGA INTERFACE(REGLER) SOM HELST
    ...ÄR NOG BRA ATT ANVÄNDA INTERFACE FÖR ATT KLASSA KURSER SOM KÖPBARA MED PRISSÄTTNING OCH TILLGÄNGLIHET (TYP AVSTÄNGAD FÖR KÖP I PERIODER ETC...)

    ---------------------
    EX: 
    
    Course : LearningItem, InterfaceItem {
    
        public string Skibbidi { get; } //från InterfaceItem - alla fält InterfaceItem har måste ärvas, det går INTE att plocka vad man vill...

    }
    ---------------------
*/
public abstract class LearningItem { //tänkte först bara "Education" men bollplankade lite med LLM och kom fram till att detta var ett ännu mer neutralare och abstraktare begrepp
//känns som LearningItem kräver för mycket flexibilitet för att bli en Interface...
//UTBILDNINGSFORMAT
    //Försöker gå från bredast scope kronologiskt nedstigande till det minsta Module > Program > <Olika former av kurser> etc...
    public string Module { get; set; } //jävligt abstrakt, kan vara både en del av ett program/kurser eller ett-program/en-kurs kanske bestå av moduler...
    public string Program { get; set; }
    public string Workshop { get; set; } //mer praktisk (än seminar) kort kurs och ofta på-plats, mest riktad till företag och sådant, tex Team Building grejs...
    public string Seminar { get; set; } //föreläsning på plats
    public string Webinar { get; set; } //föreläsning online
    public string Course { get; set; }
    //lesson är bra material för visnings ex/demo för kunder, man kan ta lite små snippets från diverse lektioner av en hel kurs och/eller program...
    public string Lesson { get; set; } //minsta byggstenen, i princip, eller ja en lektion kan bestå av små övningar också men...
    
    //ATTRIBUTER FÖR FORMATEN
    
    //kandidat till composition -------
    public string ID { get; set; }
    public string TitleName { get; set; }
    public DeliveryType DeliveryType { get; set; } //distans, klassrum, hybrid, etc...
    //---------------------------------

    public FieldOfStudy FieldOfStudy { get; set; }
    public Subject Subject { get; set; }
    public Instructor AssignedInstructor { get; set; }
    public List<Student> StudentList { get; set; }
    public bool IsStandalone { get; set; } //Workshop är primärexemplet, men även seminar, webinar, course och lesson kan vara det | !!! INTE !!! module eller program
    public string Description { get; set; }
    /*
    - Kurs-ID //bör följa ett mönster precis som "SYSÄ26M"...
    - Program/Kurs namn/titel
    - assigned lärare
    - enlisted student
    - innehåll/description
    - period/tidslängd(start/slut)
        - längd i veckor
    - kommunikation (period-/klass-bunden chat mellan elever OCH lärare)
    - område (för tags, ex: IT, BYGG, HISTORIA, DESIGN, MATEMATIK etc etc...)
        FAST OM JAG FAKTISKT LÄSER UPPGIFTEN SÅ STÅR DET KLART OCH TYDLIGT ATT WC Education SPECIALISERAT SIG PÅ TEKNISKA UTBILDNINGAR FRÄMST INOM SYS.DEV FÖR WEB OCH MOBILwmalronwlrai...
    - klassrum/distans
    - video
    */
}
