namespace PhotoPortofolio.Models.Requests;

public class WeddingSolicitationRequest
{
    public int Id { get; set; }
    public string Names { get; set; }
    public string Email { get; set; }
    public string Location { get; set; }
    public string Date { get; set; }
    public string WeddingInfo { get; set; }
    public int GuestsNumber { get; set; }
}