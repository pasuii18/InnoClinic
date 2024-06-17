namespace Application.Common.Dtos.ResultDtos;

public class ResultUpdateDto
{
    public Guid IdResult { get; set; }
    public string Complaints { get; set; }
    public string Conclusion { get; set; }
    public string Recommendations { get; set; }
}