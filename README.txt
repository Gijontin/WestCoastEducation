
- GUIDE - för hur programmet än sålänge (kan) fungera -
    ...för inlämningsdelen(eftersom jag kladdat med massa annat):

Orkade inte fixa över kontoskaparsystemet jag gjordt från ATM uppgiften ännu...
...så det får bli lite hardcoded konton till att börja med, inkludera lite premade kurser och för flavour

(tekniskt sett laddas kursdatabasen från en .json fil direkt vid programstart, så VG punkten covered redan där, JsonIO.cs)

1. Välj först inloggning som antingen studenthandledare eller admin (same shit till 100% just nu)
    - Alt. 01: fullt fungerande funktion (composition)
    - Alt. 02: fullt fungerande funktion (ej interaktiv) (aggregation)
    - Alt. 03: fullt fungerande funktion (en .ToString override för föräldra-klassen "Account", subklassen 'Instructor' har en ytterligare override modifiering)
    - Alt. 07: fullt fungerande men inkomplett funktion (orkade inte göra fler CLI ifyllningsmetoder när detta ska skrivas om till GUI...) (marker/tag interface användande) (+ .json read/write)
               (notera: CLI magi vid val av undervisningsform)
    - Alt. 10: simpel lambda (bool ändring) över en "riktig" funktion
    - Alt. 11: simpel kombination av ett clear och exit call

    Kolla in alternativ 1 och 2, testa sedan 'Skapa Kurs'(alt. 7) följt av att kolla in alternativ 2 igen.

    Välj sedan 'Go Back'(alt. 10)

2. Välj inloggning som lärarkonto
    - Alt. 03: fullt fungerande funktion (ej interaktiv) (aggregation) //tänker sedan egentligen att bygga ut den fullt interaktiv precis som i learnpoint ..fast förhoppningsvis lite snyggare och mer bekväm 

    Inget nytt där annars så välj 'Go Back'

3. Välj inlogging som student

    -Kolla först alt. 3 (Visa Mina Kurser)
    - Välj sedan alt. 2 (Visa Kursutbud) (notera: special Student-konto case)
        - har tillochmed dubbletthantering, amazing! (men inte för om två kursobjekt innehåller exakt samma curriculum, aj aj aj)


ANNARS DÅ(?):

Lärde mig några stycken nya saker men marker/tag interface tekniken och hur man både kan göra class specific och ett polymorfiskt if-check filter var nog high light:sen