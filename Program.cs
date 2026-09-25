namespace WestCoastEducation;

class Program
{
    static void Main() {
/*
        Skapa pseudo-konton:
            1   st Student
            2-3 st Lärare
            1   st StudentHandledare (SH)
            1   st Admin
*/      Menus newMenu = new();
        GenUtils.AddressLista = GenUtils.GenerateSix();

        Student newStudent = new() {
            Address = GenUtils.AddressLista[0],
        };

        newMenu.StartMenu();
    }
}
