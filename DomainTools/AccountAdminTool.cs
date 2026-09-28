namespace WestCoastEducation;

public class AccountAdminTool(IAdminRights AdminID) : Tools {
    /*
    VIKTIGT:
        - BARA StudentTutors och Admins får tillgång till dessa funktioner
        - Lärare har bara möjlighet till studentöversikt via sina kurser/program via en SEPARAT FUNKTION
    */
    
    public void ViewAccounts() {

        //Note: snabbaccess listan, i framtiden ska det väl gå att select:a kontot och trycka ut mer detaljerad information
        //      men denna borde vara duglig för att snabbt hitta...

        //Osäker om StudentTutors ska få se Admin konton också ...men definitivt studenter och lärare...
        Console.WriteLine();
        foreach (Account konto in DataBase.AllAccounts) {
            Console.WriteLine(konto.ToString());
        }
        GenUtils.PressToContinue();
    }
    public void CreateAccount() {
    //syfte:
        GenUtils.WriteColourLine("\nFunktion under konstruktion.", ConsoleColor.Cyan);
        GenUtils.PressToContinue();
        //student-accounts bör kunna skapas själva på plattformen genom reg. process ...med tanke på att plattformen även ska fungera som typ Udemy(?)

        //lärar accounts skapas manuellt av StudentTutor OCH/ELLER Admin...
        //StudentTutor accounts skapas manuellt av bara Admin...
        //...och i särfall när det varit klydd för kunder/studenter
    }
    public void RemoveAccount() {
        GenUtils.WriteColourLine("\nFunktion under konstruktion.", ConsoleColor.Cyan);
        GenUtils.PressToContinue();
    }
    public void UpdateAccount() {
        GenUtils.WriteColourLine("\nFunktion under konstruktion.", ConsoleColor.Cyan);
        GenUtils.PressToContinue();
    }
}
