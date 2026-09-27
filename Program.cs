namespace WestCoastEducation;

class Program
{
    static void Main() {
    JsonIO jsonIO = new();
/*
    TODO: (DONE!)
        - SKAPA TEST KONTON FÖR VARJE KLASS (student, lärare etc...)
        - FIXA SÅ ATT DE FUNGERAR IHOPA MED Menus.cs och GetMenu.cs....
        
        Skapa pseudo-konton:
            1   st Student
            2-3 st Lärare
            1   st StudentHandledare (SH)
            1   st Admin

    TODO:
        - Utveckla CourseAdminTools till att åtminstone kunna skapa en helt proper Course ifrån kallad funktion (och lägga till den i general kurs DataBas)
        - Fixa så att LearningExperience's ToString override:as till att skriva ut CourseID info och lite sådant i en one-liner för att lätt
          kunna användas i en vanlig foreach loop's WriteLine över kursutbud...
        - Sätt nuvarande Account's ToString funktion till en mer elegant "VisaInfo" funktion och behåll ToString i ett simpelt one-line format för List printfs
        
        - Fixa AccountAdminTools till att kunna skapa vilket typ av konto so helst genom bara en funktion (student, lärare, sh, admin, doesn't matter..)

        - Koda en IO disk save/load manager i .json format specifikt för kurser, inget annat ...for now (generella DataBasen med kurser tror jag är bäst, skit i student's list...)
*/      

        GenUtils.AddressLista = GenUtils.GenerateSix();

    //TEST STUDENT
        Student newStudent = new() {
            Address = GenUtils.AddressLista[0],
            TimeOfCreationDate = DateTime.Now,
        };
        DataBase.AllAccounts.Add(newStudent);
    //TEST LÄRARE
        Instructor newInstructor = new() {
            Address = GenUtils.AddressLista[1],
            TimeOfCreationDate = DateTime.Now,
        };
        DataBase.AllAccounts.Add(newInstructor);
    //TEST STUDENTHANDLEDARE
        StudentTutor newStudentTutor = new() {
            Address = GenUtils.AddressLista[2],
            TimeOfCreationDate = DateTime.Now,
        };
        DataBase.AllAccounts.Add(newStudentTutor);
    //TEST ADMIN
        Administrator newAdmin = new() {
            Address = GenUtils.AddressLista[3],
            TimeOfCreationDate = DateTime.Now,
        };
        DataBase.AllAccounts.Add(newAdmin);

    //Måste initieras EFTER accounts (eftersom den inte hanterar en tom AllAccounts lista(?) ...ännu)    
        Menus newMenu = new();

        newMenu.StartMenu();
    }
}
