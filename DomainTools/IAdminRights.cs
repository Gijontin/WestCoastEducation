namespace WestCoastEducation;

public interface IAdminRights {
    //När du använder interface mer som en nyckel/badge - där värdet inte spelar någon roll / behövs så kallas det att det är en "Marker Interface"
    string AdminID { get; } 
    //okay du kan typ injicera detta fältet i ett tool-object's constructor (när skapar/init:ar tool-objektet inuti ett Account)
    //den kommer då fungera som en slags nyckel och om man inte har detta interface fältets variabel så kommer det bara inte att fungera...
    //+ att tex studentkonton inte ens kommer ha tool-objektet deklararerat i sig ändå så det är ännu mer okänt (inkapsulerat) bort från konto som inte ska ha den priviledge nivån...

    //det viktiga är att:
    //1. deklarera själva tool-objektet i ett konto som ska ha tillgång
    //2. I kontots constructor måste du injicera AdminID i tool-objektets parameter(aka dess egna constructor) endast då funkar det som en slags nyckel...

    //se Administrator och StudentTutor konstruktorn för att se hur det går till...
}
