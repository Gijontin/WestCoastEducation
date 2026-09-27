namespace WestCoastEducation;

public class CourseAdminTool(IAdminRights AdminID) : Tools {
    public void ViewCourses() {
        //bara printa ut hela listan med enskilda kursutbudet, får spåna på hur mycket detaljer som behövs OCH CLI-format...
    }
    public void CreateCourse() {
        //kalla funktion som fyller i template
        //sedan add till allmäna listan, alternativt något mer komplext med return (men är nog bara drygt)

        //KAN NOG GÖRA EN TRYADD IF-CHECK HÄR SOM BARA TRIGGAR SPARNINGEN OM LISTAN FÅR ETT NYTT KURSOBJEKT INSATT I SIG...
        jsonIO.SaveCourseListToDisk(); //fakking ggez access till funktionen genom Tools föräldern, woop!

        SystemLogs.SysLog(AdminID.AdminID);
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
