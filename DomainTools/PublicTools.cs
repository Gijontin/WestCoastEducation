using System.Security.Authentication;

namespace WestCoastEducation;
/*
    Vet inte hur omfattande denna blir, kändes som ett naturligare ställe för ViewCourses() iallafall för att i princip alla konton
    ska få tillgång till att se kursutbudet...
*/
public class PublicTools {
    public void ViewCourses(object? account) {
        //bara printa ut hela listan med enskilda kursutbudet, får spåna på hur mycket detaljer som behövs OCH CLI-format...
        if (DataBase.AllCourses == null || DataBase.AllCourses.Count < 1) {
            Console.WriteLine("Antal kurser: " + (DataBase.AllCourses?.Count ?? -1)); GenUtils.PressToContinue();
            return;
        }

        int menuIndex = 0;
        int ci = 0;
        ConsoleKeyInfo key = new();
        //FPS trick, dubbla färgerna i arrayn så de känns långsammare så kan jag sänka thread.sleep timern ytterligare så att den känns mer responsiv men att färgändringarna fortfarande inte blir alltför hetsiga...
        ConsoleColor[] colourshift = {ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, ConsoleColor.Green, ConsoleColor.Green, ConsoleColor.White}; //kör en palette-swapping teknik som proffsen gjorde för att billigt(computational) animera i äldre spel
        const string signup = "Press 'Enter' to Sign Up for the Course!\n";

        do {
            Console.Clear();
        //UI
            int fulingindex = 0;

            if (account?.GetType() == typeof(Student)) {
                GenUtils.WriteColourLine($"\n - Använd Piltangenterna eller 'W' och 'S' för att växla i listan, 'Esc' för att gå tillbaka - \n", ConsoleColor.Cyan);
            } else {Console.WriteLine();}

            foreach (Course kurs in DataBase.AllCourses) {
                
                Console.WriteLine(kurs.ToString());
                

                if (account?.GetType() == typeof(Student)) {
                    if (fulingindex == menuIndex)
                        {GenUtils.WriteColourLine(signup, colourshift[ci]);}
                }
                fulingindex++;
            }

            //EN FULING, FIXAR ETT BÄTTRE SYSTEM SENARE, VILL MER BARA INKLUDERA FEATUREN FÖR SKOLUPPGIFTEN...
            //alternativt:
          //if (student?.GetType() == typeof(Student)) {} //brutalt mer explicit än att bara använda "is"
            if (account is Student student) { //"is" inte samma sak som "==", sjuk C# feature att kunna kolla så lätt, "is" inkluderar dock polymorfism så alla som ärver av "Student" hade också gått med
            //går visst att nästintill typecase:a objekt såhär genom if checks
                
                if (Console.KeyAvailable) { //VIKTIGT: Switch-case:t måste också ligga inom detta blocket annars flush:as inte knapptrycket bort och det du tryckt checkas varje loop...
                    key = Console.ReadKey(intercept: true);

                    switch (key.Key) {
                        case ConsoleKey.W or ConsoleKey.UpArrow: {
                            if (menuIndex > 0) {
                                    menuIndex--;
                            } else if (menuIndex <= 0) {
                            menuIndex = DataBase.AllCourses.Count - 1;
                            }
                        }
                        break;

                        case ConsoleKey.S or ConsoleKey.DownArrow: {
                            if (menuIndex < DataBase.AllCourses.Count - 1) {
                                    menuIndex++;
                            } else if (menuIndex >= DataBase.AllCourses.Count - 1) {
                            menuIndex = 0;
                            }
                        }
                        break;
                        
                        case ConsoleKey.Enter: {
                            if (!DataBase.AllCourses[menuIndex].StudentList.Contains(student)) {
                                DataBase.AllCourses[menuIndex].SignUp(student);
                                GenUtils.WriteColourLine("\nDin ansökan är Godkänd, välkommen till kursen!", ConsoleColor.Green);
                                GenUtils.PressToContinue();   
                            } else {
                                GenUtils.WriteColourLine("\nDu har redan ansökt till kursen.", ConsoleColor.Red);
                                GenUtils.PressToContinue();        
                            }
                            return;
                        }
                        break; //behåll för säkerhets skull (utifall jag ändrar funktionaliteten)

                        case ConsoleKey.Escape: {return;}

                        default:
                            break;
                    }
                }
                
            }
            if (ci < colourshift.Length - 1) {
                ci++;
            } else if (ci >= colourshift.Length - 1) {
                ci = 0;
            }
            Thread.Sleep(100);
        } while (account?.GetType() == typeof(Student));

        GenUtils.PressToContinue();
    }
}
