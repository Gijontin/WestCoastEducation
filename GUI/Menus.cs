namespace WestCoastEducation;

public class Menus {
    private const string arrow = "--> ";
    private void HeaderPrint() {
        Console.Clear();
        Console.WriteLine("Welcome to WestCoast Education - The WestCoast's Leading IT-Education Platform\n\n");
    }

    /*
        TODO:
            - ERSÄTT "string account" (med "Account account") I TUPLE-ARRAYN MED CORRESPONDING ACCOUNT KLASSER (SOM JAG DÅ INITIERAT I MAIN PROGRAM TILLS VIDARE ...FÖR TESTING)
            - ANVÄND RÄTT ELEMENT's ACCOUNT NÄR DU TRYCKER ENTER SOM DÅ KALLAR (Konto specifika) GetMenu FUNKTIONEN SOM DYNAMISKT SKAPAR EN LISTA AV OPTIONS BASERAT PÅ VAD ETT
              KONTO HAR TILLGÅNG TILL FÖR FUNKTIONER, TEX STUDENT KAN KOLLA KURSUTBUD MEDANS EN ADMIN/STUDENTTUTOR KAN SKAPA KURSER M.M...

            - SÅ, I ENTER TRYCKER I SWITCH CASET SKA ETT FUNGERANDE new GetMenu(StartMenuListan[menuIndex].account); GÖRAS...
    
    */
    public (string label, Account account)[] StartMenuListan = {
        ("Logga in som Student", DataBase.AllAccounts[0]),
        ("Logga in som Lärare", DataBase.AllAccounts[3]),
        ("Logga in som StudentHandledare", DataBase.AllAccounts[4]),
        ("Logga in som Admininstratör", DataBase.AllAccounts[5])
    };

    //login/accountcreate screen
    public void StartMenu() {
        int menuIndex = 0;
        do {
            try {
            //GUI
                HeaderPrint();

                for (int i = 0; i < 4; i++) {
                    if (menuIndex == i) {
                        GenUtils.WriteColour(arrow, ConsoleColor.Green);
                        GenUtils.WriteColourLine($"{i +1}. {StartMenuListan[i].label}", ConsoleColor.Green);
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

                //LEFT > BACK
                    case ConsoleKey.A or ConsoleKey.LeftArrow: {}
                    break;

            //"RIGHT" DRIP-FILTER IN MED SAMMA FUNKTION SOM 'ENTER' TRYCK ...FOR NOW
                //RIGHT > FORWARD
                    case ConsoleKey.D or ConsoleKey.RightArrow:
                //ACTIVATE/USE
                    case ConsoleKey.Enter: {
                        new GetMenu(StartMenuListan[menuIndex].account);
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
    
}
