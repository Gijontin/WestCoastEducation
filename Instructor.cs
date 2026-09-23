namespace WestCoastEducation;

public class Instructor : Account {
    //LIST OF ASSIGNED-TO/LED COURSES
    public List<LearningItem> MyAssignedCourses { get; set; } = [];
}
