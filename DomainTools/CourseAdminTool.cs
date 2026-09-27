namespace WestCoastEducation;

public class CourseAdminTool(IAdminRights AdminID) : Tools {
    public void ViewCourses() {

    //Pinfärskt uppdaterad från "DataBasen"
        jsonIO.LoadCourseListFromDisk();

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
    public void CreateCourse() {
        Course course = FillInFields();
            course.CourseID = CreateCourseID();

        //kalla funktion som fyller i template
        //sedan add till allmäna listan, alternativt något mer komplext med return (men är nog bara drygt)

        //KAN NOG GÖRA EN TRYADD IF-CHECK HÄR SOM BARA TRIGGAR SPARNINGEN OM LISTAN FÅR ETT NYTT KURSOBJEKT INSATT I SIG...
        DataBase.AllCourses.Add(course);
        //jsonIO.SaveCourseListToDisk(); //fakking ggez access till funktionen genom Tools föräldern, woop!
        jsonIO.UpdateCourseListData();
        SystemLogs.SysLog(AdminID.AdminID);
    }
        private CourseID CreateCourseID() {
            CourseID temp = new();

                Console.WriteLine("\nSkriv in kursnamnet, tryck sedan 'Enter'.");
                temp.TitleName = Console.ReadLine() ?? ""; //janky sätt, blir tomt om man failar på ReadLine (vet inte hur man skulle lyckas men men...)
                Console.WriteLine("\nVälj Undervisningsform, tryck sedan 'Enter'.");
                temp.DeliveryType = TypeFetchers.GetEnumType<LearningFormat>();
            return temp;
        }
        private Course FillInFields() {
            Course temp = new();
                //temp.D
            return temp;
        }

    public void RemoveCourse() {
        //något sätt att select:a för att sedan bara köra .Remove
        SystemLogs.SysLog(AdminID.AdminID);
    }
    public void UpdateCourse() {
        //ändra en kurs på databas(disk) nivå
        SystemLogs.SysLog(AdminID.AdminID);
    }
}
