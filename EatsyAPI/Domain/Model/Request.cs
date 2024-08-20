using EatsyAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EatsyAPI.Model;

public class Request
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public RequestStatusEnum Status { get; set; } = RequestStatusEnum.AwaitingEstablishmentConfirmation;

    public virtual ICollection<FoodRequest>? FoodRequests { get; set; }
}
