using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EatsyAPI.Model;

[Table("FoodRequests")]
public class FoodRequest
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public Guid FoodId { get; set; }

    [Required]
    public virtual Food Food { get; set; } = default!;

    [Required]
    public Guid RequestId { get; set; }

    [Required]
    public virtual Request Request { get; set; } = default!;

    [Required]
    public int Quantity { get; set; }
}
