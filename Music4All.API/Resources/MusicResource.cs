using System.ComponentModel.DataAnnotations;

namespace Music4All.API.Resources;

public class MusicResource
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(150)]
    public string Description { get; set; }
    
    public string url { get; set; }
    
    public DateTime DateCreated { get; set; }
}