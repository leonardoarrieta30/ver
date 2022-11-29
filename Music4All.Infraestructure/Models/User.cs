namespace Music4All.Infraestructure.Models;

public class User : BaseModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public bool type_of_user {get; set; }
    public string mail {get; set; }
    public string Password {get; set; }
}