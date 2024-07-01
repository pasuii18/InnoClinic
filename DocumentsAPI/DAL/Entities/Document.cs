namespace DAL.Entities;

public class Document
{
    public Guid IdDocument { get; set; }
    public string Url { get; set; }
    public Guid IdLinked { get; set; }
}