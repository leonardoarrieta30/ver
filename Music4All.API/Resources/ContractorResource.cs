using System.ComponentModel.DataAnnotations;

namespace Music4All.API.Resources;

public class ContractorResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Correo { get; set; }


    [Required]
    [Range(18, 80, ErrorMessage = "Valor fuera del rango requerido")]
    public int Age { get; set; }

    [Required]
    [MaxLength(150)]
    public string Description { get; set; }

}