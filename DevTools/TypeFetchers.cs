namespace WestCoastEducation;

public static class TypeFetchers {
    public static T GetEnumType<T>() { //Viktigt: <T> agerar effektivt som parametern istället, call ex: "TypeFetchers.GetEnumType<DeliveryType>();" (enums är fan riktigt AIDS i C#...)

        int index = 0;
        int mostChars = 0;
        T[] array = (T[])Enum.GetValues(typeof(T));

        //sätter maximum loops required för min "We-got-backspace-at-home variant av backspace"
        foreach (T val in array) {
            try { //utifall val.ToString kraschar för att den deref:ar en null ref...
                int length = val.ToString().Length;
                if (length > mostChars) {
                    mostChars = length;
                }
            } catch {}
        }

        do {
            //"\r" i början här för hur jag gör "backspace" med mellanslag
            Console.Write("\r" + array[index]!.ToString()); //"!": trust me, bro

        //KEY INPUT
            ConsoleKeyInfo key = Console.ReadKey(intercept: true); //undviker skriva in extra bokstav i terminalen (via case)

            switch (key.Key) {
            //LEFT
                case ConsoleKey.A or ConsoleKey.LeftArrow: {
                    if (index > 0) {
                        index--;
                    } else if (index <= 0) {
                        index = array.Length - 1;
                    }
                }
                break;
            //RIGHT
                case ConsoleKey.D or ConsoleKey.RightArrow: {
                    if (index < array.Length - 1) {
                        index++;
                    } else if (index >= array.Length - 1) {
                        index = 0;
                    }
                }
                break;
            //ENTER (SELECT/ACTIVATE)
                case ConsoleKey.Enter: {
                    return array[index];    
                }
                //break; //MLG kompilator gnäll-fix, även om jag velat ha den kvar som safety

                default:
                    break;
            }

            //"\r" går till kolumn 0 sen skriver jag över allt med mellanslag (eftersom backspace inte riktigt funkar som jag vill här)
            Console.Write("\r");
            for (int i = 0; i < mostChars; i++) {
                Console.Write(" ");
            }

        } while (true);

    }
}
