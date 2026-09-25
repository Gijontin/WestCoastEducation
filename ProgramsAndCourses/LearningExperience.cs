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
public abstract class LearningExperience { //bästa översättningsalternativet jag hittade för "läroform"
//UTBILDNINGSFORMAT
    //Försöker gå från bredast scope kronologiskt nedstigande till det minsta Module > Program > <Olika former av kurser> etc...

    //public string Program { get; set; }
    
    //ATTRIBUTER FÖR FORMATEN
    
    //kandidat till composition -------
    public required CourseID CourseID { get; set; }
    //---------------------------------

    public FieldOfStudy FieldOfStudy { get; set; } //mer för moduler/program
    public Subject Subject { get; set; } //mer för kurser/lektioner/Seminar/Webinar/Workshop

    public Instructor? AssignedInstructor { get; set; } //dvs lärare, kanske list...

    //amen titta, tjusig aggregation
    public List<Student> StudentList { get; set; } = new();
    
    public bool IsStandalone { get; set; } //Workshop är primärexemplet, men även seminar, webinar, course och lesson kan vara det | !!! INTE !!! module eller program
    public required string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TimePeriodInWeeks { get; set; } // TimeSpan skillnad = StartDate - EndDate; | TimePeriodInWeeks = skillnad.TotalDays / 7;

    public void SignUp() {
        
    }
    //- kommunikation (period-/klass-bunden chat mellan elever OCH lärare)
}
