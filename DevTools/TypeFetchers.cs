namespace WestCoastEducation;

public static class TypeFetchers {
    public static T GetEnumType<T>() { //Viktigt: <T> agerar effektivt som parametern istället, call ex: "TypeFetchers.GetEnumType<DeliveryType>();" (enums är fan riktigt AIDS i C#...)

        int index = 0;
        T[] array = (T[])Enum.GetValues(typeof(T));

        do {
            Console.WriteLine(array[index]!.ToString()); //"!": trust me, bro

        //KEY INPUT
            ConsoleKeyInfo key = Console.ReadKey();

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
        } while (true);

    }
}
