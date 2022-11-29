using System.ComponentModel.DataAnnotations;

namespace Music4All.API.Resources;

public class SaveGuardianResource
{
    [MaxLength(50)]
    public string firstname { get; set; }
    [MaxLength(50)]
    public string lastname { get; set; }
    [MaxLength(50)]
    public string gender { get; set; }
    public string address { get; set; }
    [Required]
    public string email { get; set; }
}