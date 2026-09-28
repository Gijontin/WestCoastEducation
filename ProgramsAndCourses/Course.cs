namespace WestCoastEducation;

public class Course : LearningExperience {
    public override string ToString() {
    
    //kraschar om jag inte "tillåter" alla variablerna vara null med "?" vid check (guess how I found out... ( ͡° ͜ʖ ͡°)
        string title = CourseID?.TitleName ?? "Name Missing";
        string deliverytype = CourseID?.DeliveryType.ToString() ?? "Okänt";
        string subject = Subject.ToString() ?? "Uknown";
        string instructor = AssignedInstructor?.ToString() ?? "Ej Angiven";
        string weeks = TimePeriodInWeeks.ToString() ?? "";
        string startdate = StartDate.ToShortDateString() ?? "?";
        string enddate = EndDate.ToShortDateString() ?? "?";
        
        //kanske ha ämnesspalten under titel (också med egen färg, fast mindre dominant än titelns) men även om det blir extra najs clarity så börjar det bli lite "chonkigt" om jag har tre rader per kurs, så maybe not...
        GenUtils.WriteColourLine($"{title} | Ämne: {subject}:", ConsoleColor.Yellow);
        return $"Plats: {deliverytype} | Period: {startdate} till {enddate} | Längd: {weeks} Veckor\n"; //skriv om denna till att returnera ALL relevant info för en kurs man är nyfiken på ...i ett format för en CLI miljö då
        //return $"- {title} | {subject}:\n  Plats: {deliverytype} | Period: {startdate} to {enddate} | Längd: {weeks} Veckor\n"; //skriv om denna till att returnera ALL relevant info för en kurs man är nyfiken på ...i ett format för en CLI miljö då
    
    
    //kasserade format
        //return $"- {title} | {subject} | Lärare: {instructor} | Längd: {weeks} Veckor"; //skriv om denna till att returnera ALL relevant info för en kurs man är nyfiken på ...i ett format för en CLI miljö då
        //return $"{CourseID.ID} {Subject} | {CourseID.TitleName} | Lärare: {AssignedInstructor.ToString()} | Längd: {TimePeriodInWeeks} Veckor"; //skriv om denna till att returnera ALL relevant info för en kurs man är nyfiken på ...i ett format för en CLI miljö då
    }
}
