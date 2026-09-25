namespace WestCoastEducation;

public class CourseID
{
    public string ID { get; set; } 
    public required string TitleName { get; set; }
    public DeliveryType DeliveryType { get; set; } //distans, klassrum, hybrid, etc...

    public string CreateID() {
        string acronymifier = "";
        //Take TitleName
        //Take StartDate
        //Take DeliveryType

        //Compact into some form of caps lock'd acronym and return that as a string to "ID"
        return acronymifier;
    }
}
