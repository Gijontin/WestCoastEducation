using System.Text.Json;
using System.Text.Encodings.Web;

namespace WestCoastEducation;
/*
    TODO:
        - Refactor Save- och Load-ToDisk som massa overload metoder istället, avgörande parametern blir nog de olika typerna av listorn som måste in
          i parametrarna, för de olika premade const string:sen är nog inte tillräckligt för att C# ska kunna urskilja dem.
          + IAdminRights kan nog funka på overloads också för att blocka vissa metoder från att kunna användas av obehöriga konton, unsure...

    MYCKET SENARE TODO:
        - Kolla senare på hur man skulle kalla denna med dependancy-injection/singleton grejs, vilket verkar vara standarden för webappar och sådant, typ ASP.NET Core :
            services.AddSingleton<JsonIO>();
            services.AddTransient<CourseAdminTool>();

*/

public class JsonIO {
    //för att folks system ser olika ut så bygger vi filvägen såhär...
    private string BaseDataPath = Environment.CurrentDirectory;
        private const string CourseList = "\\Data\\CourseList.json";
        private const string AccountList = "\\Data\\AccountList.json";

    //kanske kan använda marker interface igen här för vilka som får spara kurser till "databasen" kontra studenter som bara vill få sin lista sparad för någon form av utskrift eller PDF
    public void SaveCourseListToDisk(/*IAdminRights adminID*/) { //KAN JU GÖRA OVERLOAD METODER SENARE SOM SPARA VAD FAN SOM HELST BASERAT PÅ PARAMETERNA, 300IQ MOMENT... (så i framtiden beöver funktionerna bara heta SaveToDisk eller något)

        //SAFETY CHECK (skit i att spara en .json om listan är tom)
        if (DataBase.AllCourses.Count < 1) {
            Console.WriteLine("Det finns inget att spara.");
            return;
        }
        //så för overload byter jag bara ut namnet till typ "FullDataPath" eller något och om det är admin privilege nivå saker så kan overload-parametern kanske också kräva "IAdminRights" för att låsa bort den från obehöriga konton...?
        string CourseListDataPath = string.Concat(BaseDataPath, CourseList);

        //formatera sträng inför WriteFile
        string jsonFormat = JsonSerializer.Serialize(DataBase.AllCourses, new JsonSerializerOptions {WriteIndented = true});

        //Skapar filen genom: path(inklusive filformat ergo .json) + formatterade strängen
        File.WriteAllText(CourseListDataPath, jsonFormat);

    }
    public void LoadCourseListFromDisk() { //tror jag skippar marker interface här iochmed det tekniskt sett bara är en automatiserad serverprocess att ladda databasen ...till skillnad från att faktiskt spara nya kurser på den...
        //byt till "FullDataPath" när jag refactor:ar dessa till overload metoder istället
        string CourseListDataPath = string.Concat(BaseDataPath, CourseList);
    
    //SAFETY CHECK SÅ ATT LISTAN FINNS
        if (!File.Exists(CourseListDataPath)) {
            Console.WriteLine("Hämtning av Kurslistan misslyckades.");    
            return;
        }

        //använder dessa pre-made settings för en overload variant av Deserialize, vanligtvis bara vilken string man ska deserialize:a men...
        //...med (string, option) bestämmer man lite mer över processen...
        JsonSerializerOptions option = new JsonSerializerOptions() {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        //importera råa textfilen
        string tempStr = File.ReadAllText(CourseListDataPath);

        //deserialize:a den råa textfilen till önskat format (tex en lista med objekt eller bara objekt etc)
        DataBase.AllCourses = JsonSerializer.Deserialize<List<Course>>(tempStr, option) ?? new List<Course>(); //static list så den finns men annars gör "?? new List<Course>();" en ny instans för "AllCourse" om den inte finns
    }
    public void UpdateCourseListData() { //snabb och smutsigt som dä säger i ameri-katt
        SaveCourseListToDisk();
        LoadCourseListFromDisk();
    }
}
