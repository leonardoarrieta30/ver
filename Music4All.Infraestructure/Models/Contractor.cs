namespace Music4All.Infraestructure.Models;

public class Contractor : BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Age { get; set; }
    public string Description {get; set; }
    
    public string Correo { get; set; }

   // public List<Event>? Events { get; set; }
}