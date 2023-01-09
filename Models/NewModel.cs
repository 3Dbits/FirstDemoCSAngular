using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstDemoCSAngular.Models;

public class NewModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [MaxLength(200)]
    public string? Summary { get; set; }

    // hidden field
    [Range(0, 9999)]
    public int PinCode { get; set; } = 0000;

}