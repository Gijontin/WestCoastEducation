namespace WestCoastEducation;

class Program
{
    static void Main() {
/*
    TODO: 
        (DONE!) - SKAPA TEST KONTON FÖR VARJE KLASS (student, lärare etc...)
        (DONE!) - FIXA SÅ ATT DE FUNGERAR IHOPA MED Menus.cs och GetMenu.cs....
        
    (DONE!)Skapa pseudo-konton:
            1   st Student
            1   st Lärare
            1   st StudentHandledare (SH)
            1   st Admin

    TODO:
        - Fixa fullständig kontoskapning för SH/Admin
        - Visa Konton kanske ska för-sortera efter kontotyp innan den visar registrationslistan...

        (SEMI-DONE!) - Utveckla CourseAdminTools till att åtminstone kunna skapa en helt proper Course ifrån kallad funktion (och lägga till den i general kurs DataBas)
        - Fixa så att LearningExperience's ToString override:as till att skriva ut CourseID info och lite sådant i en one-liner för att lätt
          kunna användas i en vanlig foreach loop's WriteLine över kursutbud...
        (DONE!) - Sätt nuvarande Account's ToString funktion till en mer elegant "VisaInfo" funktion och behåll ToString i ett simpelt one-line format för List printfs
        
        - Fixa AccountAdminTools till att kunna skapa vilket typ av konto so helst genom bara en funktion (student, lärare, sh, admin, doesn't matter..)

        (DONE!) - Koda en IO disk save/load manager i .json format specifikt för kurser, inget annat ...for now (generella DataBasen med kurser tror jag är bäst, skit i student's list...)

    FRAMTIDA TODO:
        - Kolla in policy-baserad åtkomst via en "policy engine" - istället för att dela upp "tjänster" så är dem fullständiga men restrikterade via tags n shid...
          läste att det är typ så ASP.NET fungerar, antagligen så jag behöver(och vill) göra om jag ska försöka göra en riktig skolplattform i framtiden ...which I do want to do såatteh...
*/      
    
    //Kvick Än Dörty init-and-toss-objekt grej för att ladda in databas(-er), fulare än fuskbygge ...nästan 
        new JsonIO().LoadCourseListFromDisk();

//HARDCODED STUFF FOR INSTANT DEMO -------------------------------------------------------------- (START)
    //lägger in 6 hardcoded adresser i globala listan för ggez hårdkodad kontoskapning
        GenUtils.AddressLista = GenUtils.GenerateSix();

    //TEST STUDENT
        Student newStudent0 = new() {
            Address = GenUtils.AddressLista[0],
            TimeOfCreationDate = DateTime.Now,
        };
        DataBase.AllAccounts.Add(newStudent0);
        Student newStudent1 = new() {
            Address = GenUtils.AddressLista[4],
            TimeOfCreationDate = DateTime.Now,
        };
        DataBase.AllAccounts.Add(newStudent1);
        Student newStudent2 = new() {
            Address = GenUtils.AddressLista[5],
            TimeOfCreationDate = DateTime.Now,
        };
        DataBase.AllAccounts.Add(newStudent2);
    //TEST LÄRARE
        Instructor newInstructor = new() {
            Address = GenUtils.AddressLista[1],
            TimeOfCreationDate = DateTime.Now,
        };
        newInstructor.SubjectAreas.Add(SubjectArea.Cybersecurity);
        newInstructor.SubjectAreas.Add(SubjectArea.SoftwareEngineer);
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

        DataBase.AllCourses[0].AssignedInstructor = newInstructor;
            newInstructor.LearningItemAssignmentsList.Add(DataBase.AllCourses[0]);
        DataBase.AllCourses[2].AssignedInstructor = newInstructor;
            newInstructor.LearningItemAssignmentsList.Add(DataBase.AllCourses[2]);

//----------------------------------------------------------------------------------------------- (END)


    //Måste initieras EFTER accounts (eftersom den inte hanterar en tom AllAccounts lista(?) ...ännu)    
        Menus newMenu = new();

        newMenu.StartMenu();
    }
}
