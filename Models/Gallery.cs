using Microsoft.AspNetCore.Components;

namespace PhotoPortofolio.Models;

public class Gallery
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public string Date { get; set; }
    public Picture MainPicture { get; set; }
    public List<Picture> Pictures { get; set; }
}