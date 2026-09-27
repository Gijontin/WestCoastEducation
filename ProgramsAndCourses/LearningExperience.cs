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

    //public string Program { get; set; } //skiter i denna tills vidare för den kolliderar med (main)Program
    
//ATTRIBUTER/FÄLT/TRAMS
    public CourseID CourseID { get; set; } //kandidat till composition (done!) //note: set till "required" senare
    public FieldOfStudy FieldOfStudy { get; set; } //mer för moduler/program
    public Subject Subject { get; set; } //mer för kurser/lektioner/Seminar/Webinar/Workshop
    public string Description { get; set; } //note: set till "required" senare
    public bool IsStandalone { get; set; } //Workshop är primärexemplet, men även seminar, webinar, course och lesson kan vara det | !!! INTE !!! module eller program

    //Personer involverade
    public Instructor? AssignedInstructor { get; set; } //dvs lärare, skiter i list just nu men annars är det smartare för en parent då den täcker större program också (men en Module kanske automatiskt kan hämta vilka lärare som ingår själv, polymorfism?)
    public List<Student> StudentList { get; set; } = new(); //amen titta, tjusig aggregation
  
    //i tid och otid
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TimePeriodInWeeks { get; set; } // TimeSpan skillnad = StartDate - EndDate; | TimePeriodInWeeks = skillnad.TotalDays / 7;

//FUNKTIONER
    public void SignUp(Student student) {
        StudentList.Add(student); //man vill nog ha denna processen i en helt separat lista med signup som gås igenom och behandlas separat, kanske bara en tag för vilken kurs man ansöker
    }
    public void ShowDescription() {
        if (string.IsNullOrEmpty(Description)) 
            {return;}

        Console.WriteLine(Description);
    }
    //- kommunikation (period-/klass-bunden chat mellan elever OCH lärare)
        // - Group Chat / Chat Room
        // - Private Messaging to Teacher
        // - Private Messing between signed up Students
}
