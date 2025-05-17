using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace projectoFinalV2.Models
{
public class FilmRatings
{
    [ValidateNever]
    public Film    Film    { get; set; }

    [ValidateNever]
    public List<Rating> Ratings { get; set; }

    public Rating  NewRating { get; set; }
}
}