namespace WestCoastEducation;

/*
    OKAY, DAGS ATT TESTA ATT GÖRA EN LITE MER MLG VARIANT PÅ MIN TUPLE-ARRAY DÄR MAN ISTÄLLET DYNAMISKT
    HÄMTAR FUNKTIONER TILL EN LISTA...
*/

public class MenuItem(string label, Action callback) {
    public string Label { get; set; } = label;       //text för menyn
    public Action Callback { get; set; } = callback; //funktionen i fråga
}