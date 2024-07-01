namespace DAL.Entities;

public class Photo
{
    public Guid IdPhoto { get; set; }
    public string Url { get; set; }
    public Guid IdLinked { get; set; }
}