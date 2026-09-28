using System.Runtime.CompilerServices;

namespace WestCoastEducation;

public class Student : Account {
    public override AccountType AccountType => AccountType.Student;

/*
    - ELEV/KUND/FÖRETAGSKUND -
        - adress
        - pågående utbildning/köpta kurser
*/
    //EGEN LISTA FÖR KÖPTA KURSER
    public List<Course> PurchasedCourses { get; private set; } = new();

    //EGEN LISTA FÖR PÅGÅENDE PROGRAM/KURSER
    public void ViewMyCourses() {
        if (PurchasedCourses != null) {
            foreach (var item in PurchasedCourses) {
                Console.WriteLine(item.CourseID.TitleName);
            }
        }
    }
    //SIGNUP FUNKTIONER FÖR KURSER OCH SÅDANT
    public void FindNewCourses() { //REFACTOR NAMN, SKA EGENTLIGEN VARA NÅGON FORM AV "LÄGG TILL/ANSÖK KURS" SKA MEST TROLIGT EGENTLIGEN INTE ENS VARA PÅ STUDENTKONTOT....
        GenUtils.WriteColourLine("\nFunktion under konstruktion.", ConsoleColor.Cyan);
        GenUtils.PressToContinue();
        
        /*
        if not already purchased
        PurchasedCourses.Add(course);
        */
    }
}
