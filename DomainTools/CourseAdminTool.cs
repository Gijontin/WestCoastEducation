namespace WestCoastEducation;

public class CourseAdminTool(IAdminRights ID) {
    public void ViewCourses() {
        //bara printa ut hela listan med enskilda kursutbudet, får spåna på hur mycket detaljer som behövs OCH CLI-format...
    }
    public void CreateCourse() {
        //kalla funktion som fyller i template
        //sedan add till allmäna listan, alternativt något mer komplext med return (men är nog bara drygt)
        SystemLogs.SysLog(ID.AdminID);
    }
    public void RemoveCourse() {
        //något sätt att select:a för att sedan bara köra .Remove
        SystemLogs.SysLog(ID.AdminID);
    }
    public void UpdateCourse() {
        //ändra en kurs på databas(disk) nivå
        SystemLogs.SysLog(ID.AdminID);
    }
}
