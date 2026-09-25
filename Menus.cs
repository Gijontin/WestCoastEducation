namespace WestCoastEducation;

public class Menus {
    private const string arrow = "--> ";
    private void HeaderPrint() {
        Console.Clear();
        Console.WriteLine("Welcome to WestCoast Education - The WestCoast's Leading IT-Education Platform\n\n");
    }
    //GÖR EN TUPLE ARRAY MED FUNKTIONER SOM GÅR ATT AKTIVERA VIA SWITCH-CASE MENU - LISTA UT ETT SÄTT ATT BLOCKERA ÅTKOMST
    //BEROENDE PÅ KONTOTYP (STUDENT == MINST ÅTKOMST...)

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

        HeaderPrint();
        Console.WriteLine("1. Logga in som Student.");
        Console.WriteLine("2. Logga in som Lärare.");
        Console.WriteLine("3. Logga in som StudentHandledare.");
        Console.WriteLine("4. Logga in som Admin.");

        GenUtils.PressToContinue();
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
