namespace Music4All.Infraestructure.Models;

public class Guardian : BaseModel
{
    public int Id { get; set; }
    public string email { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string gender { get; set; }
    public string address { get; set; }
}