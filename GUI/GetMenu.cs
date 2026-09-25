namespace WestCoastEducation;
/*
    PLACEHOLDER CLASS FÖR JAG HAR INGEN BACKEND ÄNDÅ.

    ...ANNARS HAR MAN SÅKLART INTE DENNA SKITEN I CLIENT...
*/
public class GetMenu { //BYGG OCH INITERA FUNKTIONER/MENYN GENOM KONSTRUKTORN SÅ ATT DET BARA BLIR ETT ONE-LINE-CALL I "Menus.cs"
    private const string arrow = "--> ";
    public  List<MenuItem> MyMenu { get; private set;}
    public List<MenuItem> BuildMenu(Account account) {
        List<MenuItem> menu = new();

        /*
            EGENTLIGEN BÖR MARKER INTERFACE OCKSÅ DIKTERA VAD KONTO-TYPERNA FÅR TILLGÅNG TILL...
        */
        switch (account) {
            case Student: {
                //menu.Add(new MenuItem("Lista Kursutbud", () => ));
                //lägg till kurs på konto
            }
            break;

            case Instructor: {
                //lista kurser du ansvarar för > se studenter anmälda till kursen
                    
            }
            break;

            case StudentTutor: {
                //Kunna lägga till nya kurser
                //Kunna lägga till nya lärare
                //Kunna lägga till nya studerande
                //Kunna lägga till nya handledare
                //Kunna lista kurser
                //Kunna lista studenter
            }
            break;

            case Administrator: {
                //Kunna lägga till nya kurser
                //Kunna lägga till nya lärare
                //Kunna lägga till nya studerande
                //Kunna lägga till nya handledare
                //Kunna lägga till nya administratörer
                //Kunna lista kurser
                //Kunna lista studenter
            }
            break;
            
            default:
                break;
        }

    //TODO: feeet överkurs men ett "go back" option hade varit coolt
        menu.Add(new MenuItem("Back (Placeholder, this will also 'Exit' for now...)", () => Environment.Exit(0))); //PLACEHOLDER FUNKTION!!!

    //avslutar alltid med exit
        menu.Add(new MenuItem("Exit", () => Environment.Exit(0)));

        return menu;
    }
    private void RunMenu() {
        int menuIndex = 0;

        do {
            try {
            //GUI
                Console.Clear(); //ERSÄTT MED EN HEADER (som har inbyggd clear...)
                for (int i = 0; i < MyMenu.Count; i++) {
                    if (menuIndex == i) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(arrow);
                        Console.WriteLine($"{i +1}. {MyMenu[i].Label}");
                        Console.ResetColor();
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
        } while (true);


    }
    public GetMenu(Account account) {
        MyMenu = BuildMenu(account);
        RunMenu();
    }
}
