namespace WestCoastEducation;
/*
    PLATTFORMEN SKA TA HÄNSYN TILL EN MIX AV ETT TRADITIONELLA ANSÖKNINGS PROGRAM MEN ÄVEN UDEMY-STYLE BUY2(PERMA)ACCESS KURSER ELLER
    SUBSCRIPTION-BASED FÖR FULL ACCESS UNDER SUBSCRIPTION PERIODEN...
*/
public class LearningItem { //tänkte först bara "Education" men bollplankade lite med LLM och kom fram till att detta var ett ännu mer neutralare och abstraktare begrepp

//Försöker gå från bredast scope kronologiskt nedstigande till det minsta Module > Program > <Olika former av kurser> etc...
    public string Module { get; set; } //jävligt abstrakt, kan vara både en del av ett program/kurser eller ett-program/en-kurs kanske bestå av moduler...
    public string Program { get; set; }
    public string Workshop { get; set; } //mer praktisk (än seminar) kort kurs och ofta på-plats, mest riktad till företag och sådant, tex Team Building grejs...
    public string Seminar { get; set; } //föreläsning på plats
    public string Webinar { get; set; } //föreläsning online
    public string Course { get; set; }
    public string Lesson { get; set; } //minsta byggstenen, i princip, eller ja en lektion kan bestå av små övningar också men...
    public bool IsStandalone { get; set; } //Workshop är primärexemplet, men även seminar, webinar, course och lesson kan vara det | !!! INTE !!! module eller program
}
