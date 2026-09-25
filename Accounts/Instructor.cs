namespace WestCoastEducation;

public class Instructor : Account {
    //LIST OF ASSIGNED-TO/LED COURSES
    public List<LearningExperience> LearningItemAssignmentsList { get; set; } = [];
    public DateTime EmploymentStartDate { get; set; }

    public override AccountType AccountType => AccountType.Instructor;
}
