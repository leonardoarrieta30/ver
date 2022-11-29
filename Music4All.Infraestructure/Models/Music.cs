namespace Music4All.Infraestructure.Models;

public class Music : BaseModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description {get; set; }
    
    public string url { get; set; }
    
   public int? MusicianId { get; set; }

    public Musician? Musician { get; set; }
}