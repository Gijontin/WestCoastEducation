namespace WestCoastEducation;

public class Instructor : Account {

/*
    - LÄRARE -
        - adress
        - "kunskapsområde" (ex: språklärare, natur, historia, samhälle, bild, IT, Svampbruksmentor)
        - assigned kurser, dvs kurser läraren är knuten/ansvarar/håller i (hyfsat dynamiskt ändrade, dock static för köpte on-demand kurserna)

*/  
    //strings och sådant är nog lättare men skitsamma, vi kör en hashset-lista (dvs kan ej innehålla dubletter) för enum values inom kunskapsområdes enumen vid namn "SubjectArea"
    public HashSet<SubjectArea> SubjectAreas { get; set; } = new();
    //LIST OF ASSIGNED-TO/LED COURSES
    public List<LearningExperience> LearningItemAssignmentsList { get; set; } = [];

    public DateTime EmploymentStartDate { get; set; }

    public override AccountType AccountType => AccountType.Instructor;
    public override string ToString() { //behöver inga safety checks här ännu eftersom Address är required...
        
        //för att concat-grejja baseline override:n från Account
        string getbase = base.ToString();

        //git dem enums till sträng
        string subjectareas = string.Join(", ", SubjectAreas);

        //klämcheck
        if (string.IsNullOrEmpty(subjectareas)) {
            subjectareas = "Saknas uppgifter.";
        }

        getbase += $" | Kunskapsområden: {subjectareas}";

        return getbase;
    }

    public void ViewHeldCourses() {
        if (LearningItemAssignmentsList == null || LearningItemAssignmentsList.Count < 1) {
            GenUtils.WriteColourLine("\nDu leder inga aktiva kurser/program just nu.", ConsoleColor.Yellow);
            GenUtils.PressToContinue();   
            return;
        }

        foreach (LearningExperience kurs in LearningItemAssignmentsList) {
            //bara "Course" subklassen som har en override .ToString() än sålänge...
            Console.WriteLine(kurs.ToString());
        }
    }
    public void ShowAttendingStudents() {
        //ska egentligen vara en funktion man kommer åt med lärare privilegier (eller högre)
        //inne på själva LearningExperience-objektets funktioner ...tror jag är bäst
        GenUtils.WriteColourLine("\nFunktion under konstruktion.", ConsoleColor.Cyan);
        GenUtils.PressToContinue();
    }
}
