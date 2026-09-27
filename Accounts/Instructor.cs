namespace WestCoastEducation;

public class Instructor : Account {

/*
    - LÄRARE -
        - adress
        - "kunskapsområde" (ex: språklärare, natur, historia, samhälle, bild, IT, Svampbruksmentor)
        - assigned kurser, dvs kurser läraren är knuten/ansvarar/håller i (hyfsat dynamiskt ändrade, dock static för köpte on-demand kurserna)

*/
    //LIST OF ASSIGNED-TO/LED COURSES
    public List<LearningExperience> LearningItemAssignmentsList { get; set; } = [];
    public DateTime EmploymentStartDate { get; set; }

    public override AccountType AccountType => AccountType.Instructor;

    public override string ToString() {
        return $"{Address.FirstName} {Address.LastName}";
    }
}
