namespace WestCoastEducation;

public class AccountAdminTool(IAdminRights AdminID) {
    /*
    VIKTIGT:
        - BARA StudentTutors och Admins får tillgång till dessa funktioner
        - Lärare har bara möjlighet till studentöversikt via sina kurser/program via en SEPARAT FUNKTION
    */
    public void ViewAccounts() {
        //Osäker om StudentTutors ska få se Admin konton också ...men definitivt studenter och lärare...
    }
    public void CreateAccount() {
    //syfte:
        //lärar account skapas manuellt av StudentTutor OCH/ELLER Admin...
        //StudentTutor accounts skapas manuellt av bara Admin...
        //...och i särfall när det varit klydd för kunder/studenter
    }
    public void RemoveAccount() {
        
    }
    public void UpdateAccount() {
        
    }
}
