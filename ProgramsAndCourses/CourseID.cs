namespace WestCoastEducation;

public class CourseID
{
    public string ID { get; set; }        //note: set till "required" senare
    public string TitleName { get; set; } //note: set till "required" senare
    public LearningFormat DeliveryType { get; set; } //distans, klassrum, hybrid, etc...

    public string CreateID() {
        string acronymifier = "";
        //Take TitleName
        //Take StartDate
        //Take DeliveryType

        //Compact into some form of caps lock'd acronym and return that as a string to "ID"
        return acronymifier;
    }
}
