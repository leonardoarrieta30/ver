namespace Music4All.Infraestructure.Models;

public class Event : BaseModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description {get; set; }
    
    public string url { get; set; }

   public int? ContractorId { get; set; }
   
   public Contractor? Contractor { get; set; }
}