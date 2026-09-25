namespace WestCoastEducation;

public class Menus {
    private const string arrow = "--> ";
    private void HeaderPrint() {
        Console.Clear();
        Console.WriteLine("Welcome to WestCoast Education - The WestCoast's Leading IT-Education Platform\n\n");
    }
    //GÖR EN TUPLE ARRAY MED FUNKTIONER SOM GÅR ATT AKTIVERA VIA SWITCH-CASE MENU - LISTA UT ETT SÄTT ATT BLOCKERA ÅTKOMST
    //BEROENDE PÅ KONTOTYP (STUDENT == MINST ÅTKOMST...)
    public (string label, string placeholder)[] StartMenuListan = {
        ("Logga in som Student", "str"),
        ("Logga in som Lärare", "str"),
        ("Logga in som StudentHandledare", "str"),
        ("Logga in som Admininstratör", "str")
    };
        /*
            Jag skapar en plattform-global lista som håller kurser - låter SH/Admin skapa kurser och lägga i listan som sparas
            i .json och laddas in vid programstart...

            SH och Admin ska ha tillgång till att kalla metoder i CourseAdminTool.cs
            SH och Admin ska modulärt kunna lägga till och ta bort lärare ifrån en kurs

            Studenter ska kunna bläddra listan och se kursinfo 
            Studenter ska kunna spara(cache) kurser i sin egna profils kurslista (kanske tom disk-spara)

            Lärare ska kunna se kursinfo över de kurs de håller i, samt en studentlista över studenter som är anmälda till klassen
        */
    //login/accountcreate screen
    public void StartMenu() {
        int menuIndex = 0;

        do {
            try {
            //GUI
                HeaderPrint();

                for (int i = 0; i < 4; i++) {
                    if (menuIndex == i) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(arrow);
                        Console.WriteLine($"{i +1}. {StartMenuListan[i].label}");
                        Console.ResetColor();
                    } else {
                        Console.WriteLine($"{i +1}. {StartMenuListan[i].label}");
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
                            menuIndex = StartMenuListan.Length - 1;     
                        } 
                    }
                    break;
                //DOWN
                    case ConsoleKey.S or ConsoleKey.DownArrow: {
                        if (menuIndex < StartMenuListan.Length - 1) {
                                menuIndex++;
                        } else if (menuIndex >= StartMenuListan.Length - 1) {
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
                    case ConsoleKey.Enter: {}
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
    
/*
    KundAccountMenu:
        - Egna personuppgifter
        - Kolla kursutbud:
            - Välja Kurser att lägga-till/ta-bort kurser i kundens egna lista

        - Spara ens lista på valda kurser på disk (.json)
        - ladda in ens lista på valda kurser från disk (.json)
    
    LärarAcconutMenu:
        - Egna personuppgifter
        - kolla kurser man leder
            - kolla vilka elever som är "subscribed" till kurs

    Utbildningslärare:
        - Egna personuppgifter
        - Kolla Studenter och Lärares uppgifter (VIKTIGT: även Lärares anställningsperioder)
            - lägga till/skapa kurser (och program)
                - lägga till lärare till kurser (tror admin ansvarar för att faktiskt ge lärare konton och sådant...)
                - KANSKE lägga till elever till större program och sådant också, men ett system bör annars nog fixa de flesta köpe-kurser etc

*/
}
