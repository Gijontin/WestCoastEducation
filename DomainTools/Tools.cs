namespace WestCoastEducation;
/*
    Purpose:
        Vill inte göra JsonIO till en global (static) och misstänker att det är en dålig idé att hålla på att instansiera den varenda klass och sådant också
        ...fast i webappar verkar det som att instansera den typ hela tiden är något man gör, men får läsa på mer om det senare...
*/
public abstract class Tools {
    //protected så inga andra klasser än parent/child kan komma åt dem, i detta fallet tror jag inte 
    protected JsonIO jsonIO { get; } = new JsonIO(); //får skriva mer avancerade begränsningar sen när studenter behöver tillgång till någon form av json sparande de med, för tex utskrift...
}
