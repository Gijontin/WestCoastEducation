namespace WestCoastEducation;
/*
    PLACEHOLDER CLASS FÖR JAG HAR INGEN BACKEND ÄNDÅ.

    ...ANNARS HAR MAN SÅKLART INTE DIREKT-TILLGÅNG TILL SÅDANT HÄR I CLIENT...
*/
public class GetMenu { //BYGG OCH INITERA FUNKTIONER/MENYN GENOM KONSTRUKTORN SÅ ATT DET BARA BLIR ETT ONE-LINE-CALL I "Menus.cs"
    private const string arrow = "--> ";
    private bool IsActive { get; set; } = true;
    public  List<MenuItem> MyMenu { get; private set;}
    public List<MenuItem> BuildMenu(Account account) {
        List<MenuItem> menu = new();

    //Baseline som alla konton har:
        //menu.Add(new MenuItem("Visa Kontoinfo.", () => {Console.WriteLine(account.ToString()); GenUtils.PressToContinue();})); //mer för admin överseende-grejs (hade bara här för att testa)
        menu.Add(new MenuItem("Visa KontoUppgifter.", () => account.ShowAccountInfo()));
        menu.Add(new MenuItem("Visa Kursutbud.", () => account.PublicTools.ViewCourses(account)));
        /*
            EGENTLIGEN BÖR MARKER INTERFACE OCKSÅ DIKTERA VAD KONTO-TYPERNA FÅR TILLGÅNG TILL...
        */

        switch (account) {
            case Student student: {
                menu.Add(new MenuItem("Visa Mina Kurser.", () => student.ViewMyCourses()));
                //menu.Add(new MenuItem("Hitta Nya Kurser.", () => student.FindNewCourses())); //funktionaliteten inbyggd i "Visa Kursutbud" ...for now
                //menu.Add(new MenuItem("Lista Kursutbud", () => ));
                //lägg till kurs på konto
            }
            break;

            case Instructor instructor: {
                //lista kurser du ansvarar för > se studenter anmälda till kursen
                menu.Add(new MenuItem("Visa Mina Kursuppdrag.", () => instructor.ViewHeldCourses()));
                    
            }
            break;
    /*
        TODO:
            LISTA UT NÅGOT SÄTT ATT FÅ VARJE KLASS MED METODER ATT RETURNERA EN KOMPAKT LISTA MED METODER DE INNEHÅLLER
            ISTÄLLET FÖR ATT MANUELLT SKRIVA UT VARJE FUNKTION FÖR VARJE CASE

            Ex: menu.Add(ImportAccountAdminToolKit()); //eller nått... (eller det kanske måste vara en foreach loop med menu.Add([i]) )
    */
            case StudentTutor studentTutor: {
            //ACCOUNT
                menu.Add(new MenuItem("Visa Registrerade Konton.",       () => studentTutor.AccountAdminTool.ViewAccounts()));
                menu.Add(new MenuItem("Skapa Konto.",           () => studentTutor.AccountAdminTool.CreateAccount()));
                menu.Add(new MenuItem("Ta Bort Konto.",         () => studentTutor.AccountAdminTool.RemoveAccount()));
                menu.Add(new MenuItem("Uppdatera/Ändra Konto.", () => studentTutor.AccountAdminTool.UpdateAccount()));
            //COURSE
                //menu.Add(new MenuItem("Visa Kurslista.",        () => studentTutor.PublicTools.ViewCourses())); //generell så den ligger redan adderad innan switch-case:et
                menu.Add(new MenuItem("Skapa Kurs.",            () => studentTutor.CourseAdminTool.CreateCourse()));
                menu.Add(new MenuItem("Ta Bort Kurs.",          () => studentTutor.CourseAdminTool.RemoveCourse()));
                menu.Add(new MenuItem("Uppdatera/Ändra Kurs",  () => studentTutor.CourseAdminTool.UpdateCourse()));
                //Kunna lista kurser
                //Kunna lista studenter
            }
            break;

            case Administrator admin: { //när skiten är så baked in måste man ha en pseudo(?) variabel i case:et som tex "admin" - gör det på resten också bara för consistency (pattern matching handlar det om, inte alltför inuitivt ännu...)
            //ACOUNT   
                menu.Add(new MenuItem("Visa Registrerade Konton.",       () => admin.AccountAdminTool.ViewAccounts()));
                menu.Add(new MenuItem("Skapa Konto.",           () => admin.AccountAdminTool.CreateAccount()));
                menu.Add(new MenuItem("Ta Bort Konto.",         () => admin.AccountAdminTool.RemoveAccount()));
                menu.Add(new MenuItem("Uppdatera/Ändra Konto.", () => admin.AccountAdminTool.UpdateAccount()));
            //COURSE
                //menu.Add(new MenuItem("Visa Kurslista.",        () => admin.PublicTools.ViewCourses())); //generell så den ligger redan adderad innan switch-case:et
                menu.Add(new MenuItem("Skapa Kurs.",            () => admin.CourseAdminTool.CreateCourse()));
                menu.Add(new MenuItem("Ta Bort Kurs.",          () => admin.CourseAdminTool.RemoveCourse()));
                menu.Add(new MenuItem("Uppdatera/Ändra Kurs",  () => admin.CourseAdminTool.UpdateCourse()));
            }
            break;
            
            default:
                //PRINTF DEBUG
                //Console.WriteLine("\nInget case matchade..."); GenUtils.PressToContinue(); 
                break;
        }

    //TODO: feeet överkurs men ett "go back" option hade varit coolt
        //menu.Add(new MenuItem("Back (Placeholder, this will also 'Exit' for now...)", () => {Console.Clear(); Environment.Exit(0);})); //PLACEHOLDER FUNKTION!!!
        menu.Add(new MenuItem("Go Back.", () => GoBack())); //PLACEHOLDER FUNKTION!!!

    //avslutar alltid med exit
        menu.Add(new MenuItem("Exit", () => {Console.Clear(); Environment.Exit(0);}));

        return menu;
    }
    public void GoBack() => IsActive = false; //kunde gjort ett normalt block också men det är kul att kunna använda lambda...
    private void RunMenu() {
        int menuIndex = 0;

        do {
            try {
            //GUI
                Console.Clear(); //ERSÄTT MED EN HEADER (som har inbyggd clear...)
                for (int i = 0; i < MyMenu.Count; i++) {
                    if (menuIndex == i) {
                        GenUtils.WriteColour(arrow, ConsoleColor.Green);
                        GenUtils.WriteColourLine($"{i +1}. {MyMenu[i].Label}", ConsoleColor.Green);
                    } else {
                        Console.WriteLine($"{i +1}. {MyMenu[i].Label}");
                    }
                }


            //MENU LOGIC
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key) {
                //UP
                    case ConsoleKey.W or ConsoleKey.UpArrow: {
                        if (menuIndex > 0) {
                                menuIndex--;
                        } else if (menuIndex <= 0) {
                            menuIndex = MyMenu.Count - 1;     
                        } 
                    }
                    break;
                //DOWN
                    case ConsoleKey.S or ConsoleKey.DownArrow: {
                        if (menuIndex < MyMenu.Count - 1) {
                                menuIndex++;
                        } else if (menuIndex >= MyMenu.Count - 1) {
                            menuIndex = 0;     
                        } 
                    }
                    break;
                //RIGHT > FORWARD
                    case ConsoleKey.D or ConsoleKey.RightArrow: {}
                    break;
                //LEFT > BACK
                    case ConsoleKey.A or ConsoleKey.LeftArrow: {}
                    break;
                //ACTIVATE/USE
                    case ConsoleKey.Enter: {
                        try {
                            MyMenu[menuIndex].Callback(); //kanske kraschar om den inte har något i sig eller blir fel (så kan förhoppningsvis fuska med en try-catch)
                        } catch {
                            //debug log: "GetMenu callback activation on Enter-press krasch" typ något sådant
                        }
                    }
                    break;
                    
                //MISC.
                    default:
                        break;
                }       
            }
            catch {
                    
            }
        } while (IsActive);


    }
    public GetMenu(Account account) {
        MyMenu = BuildMenu(account);
        RunMenu();
    }
}
