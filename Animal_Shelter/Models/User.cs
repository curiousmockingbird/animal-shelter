using System.ComponentModel.DataAnnotations;

namespace Animal_Shelter.Models
{
  public class User
  {
    public int UserId { get; set; }
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Password { get; set; }
  }
}