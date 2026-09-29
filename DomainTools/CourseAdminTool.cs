using System.Net.WebSockets;

namespace WestCoastEducation;

public class CourseAdminTool(IAdminRights AdminID) : Tools {
/* 

    NOTE: FLYTTAD TILL PublicTools.cs


    public void ViewCourses() {
        //bara printa ut hela listan med enskilda kursutbudet, får spåna på hur mycket detaljer som behövs OCH CLI-format...
        if (DataBase.AllCourses == null || DataBase.AllCourses.Count < 1) {
            Console.WriteLine("Antal kurser: " + (DataBase.AllCourses?.Count ?? -1)); GenUtils.PressToContinue();
            return;
        }
        
        Console.WriteLine(); //lite skiljerum för UI visiblity
        foreach (Course kurs in DataBase.AllCourses) {
            Console.WriteLine(kurs.ToString());
        }
        GenUtils.PressToContinue();
    }
*/
    public void CreateCourse() {
        //kalla funktion som fyller i template
        //sedan add till allmäna listan, alternativt något mer komplext med return (men är nog bara drygt)

        //fixa ett progressande snapshot(output preview) på pågående ifyllningsformuläret...
        Course course = new();
            course.CourseID = CreateCourseID();
            FillStartDateAndWeekLength(course); //tar in course som parameter istället, insåg att return:a från ett nytt objekt skriver ju över null värdena också (och inte bara kompletterar...)

            //skapa resterande kompletterande funktioner och slå sedan samman dem till ett totalt ifyllnadsformulär...

        //KAN NOG GÖRA EN TRYADD IF-CHECK HÄR SOM BARA TRIGGAR SPARNINGEN OM LISTAN FÅR ETT NYTT KURSOBJEKT INSATT I SIG... (om jag refactor till en dictionary dvs)
        DataBase.AllCourses.Add(course);
        //jsonIO.SaveCourseListToDisk(); //fakking ggez access till funktionen genom Tools föräldern, woop!
        jsonIO.UpdateCourseListData();
        SystemLogs.SysLog(AdminID.AdminID);
    }
        private CourseID CreateCourseID() {
            CourseID temp = new();

                Console.WriteLine("\nSkriv in kursnamnet, tryck sedan 'Enter'.");
                temp.TitleName = Console.ReadLine() ?? ""; //janky sätt, blir tomt om man failar på ReadLine (vet inte hur man skulle lyckas men men...)
                Console.WriteLine("\nVälj Undervisningsform Genom Att Växla med Höger- och Vänsterpil eller 'A' och 'D', tryck sedan 'Enter'.");
                temp.DeliveryType = TypeFetchers.GetEnumType<LearningFormat>();
            return temp;
        }
        private void FillStartDateAndWeekLength(Course temp) {
            //Course temp = new();
                //utveckla en mer manuell datumväljarfunktion...
                temp.StartDate = DateTime.Now;

                //gör detta bättre med möjlighet att avbryta
                while (true) {
                    Console.WriteLine("\nAnge kurslängd i veckor, tryck sedan 'Enter':");
                    if (int.TryParse(Console.ReadLine(), out int weeks)) {
                        temp.TimePeriodInWeeks = weeks;
                        break;
                    }
                }
                temp.EndDate = temp.StartDate.AddDays(7 * temp.TimePeriodInWeeks);

            //return temp;
        }

    public void RemoveCourse() {
        GenUtils.WriteColourLine("\nFunktion under konstruktion.", ConsoleColor.Cyan);
        GenUtils.PressToContinue();
        //något sätt att select:a för att sedan bara köra .Remove
        SystemLogs.SysLog(AdminID.AdminID);
    }
    public void UpdateCourse() {
        GenUtils.WriteColourLine("\nFunktion under konstruktion.", ConsoleColor.Cyan);
        GenUtils.PressToContinue();
        //ändra en kurs på databas(disk) nivå
        SystemLogs.SysLog(AdminID.AdminID);
    }
}
