namespace WestCoastEducation;
/*
    Vet inte hur omfattande denna blir, kändes som ett naturligare ställe för ViewCourses() iallafall för att i princip alla konton
    ska få tillgång till att se kursutbudet...
*/
public class PublicTools {
    public void ViewCourses() {
        //bara printa ut hela listan med enskilda kursutbudet, får spåna på hur mycket detaljer som behövs OCH CLI-format...
        if (DataBase.AllCourses == null || DataBase.AllCourses.Count < 1) {
            Console.WriteLine("Antal kurser: " + (DataBase.AllCourses?.Count ?? -1)); GenUtils.PressToContinue();
            return;
        }
        
        Console.WriteLine(); //lite skiljerum för UI visiblity
        foreach (Course kurs in DataBase.AllCourses) {
            Console.WriteLine(kurs.ToString());
        }
        GenUtils.PressToContinue();
    }
}
