using System.ComponentModel.DataAnnotations;

namespace Animal_Shelter.Models
{
  public class Users
  {
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Password { get; set; }
  }
}