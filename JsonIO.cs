namespace WestCoastEducation;

public class JsonIO {
    //för att folks system ser olika ut så bygger vi filvägen såhär...
    private string BaseDataPath = Environment.CurrentDirectory;
        private string CourseList = "\\Data\\CourseList.json";

    //kanske kan använda marker interface igen här för vilka som får spara kurser till "databasen" kontra studenter som bara vill få sin lista sparad för någon form av utskrift eller PDF
    public void SaveCourseListToDisk(/*filväg och list parameter*/) {

        string CourseListDataPath = string.Concat(BaseDataPath, CourseList);
    }
    public void LoadCourseListFromDisk(/*filväg och list parameter*/) {
        string CourseListDataPath = string.Concat(BaseDataPath, CourseList);
    
    //SAFETY CHECK SÅ ATT LISTAN FINNS
        if (!File.Exists(CourseListDataPath)) {return;}
    }
}
