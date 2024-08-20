using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EatsyAPI.Model;

public class Food
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O preço é obrigatório.")]
    public double Price { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Name { get; set; }  = default!;

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    public string Description { get; set; }  = default!;

    [Required(ErrorMessage = "O link da foto é obrigatório.")]
    public string PhotoLink { get; set; }  = default!;

    [Required(ErrorMessage = "O campo favorito é obrigatório.")]
    public bool IsFavorite { get; set; }

    [Required]
    public Guid FoodCategoryId { get; set; }

    [Required]
    public virtual FoodCategory FoodCategory { get; set; }  = default!;
}
