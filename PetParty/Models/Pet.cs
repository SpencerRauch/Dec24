#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetParty.Models;

public class Pet
{
    // public string? Name { get;set; }
    // public string Name { get;set; } = null!;
    [DisplayName("Pet Name")]
    [Required(ErrorMessage = "plz gib name")]
    [MinLength(3, ErrorMessage = "Name should be 3 chars or more")]
    public string Name { get;set; }
    [Required]
    public string Species { get;set; }
    [Required]
    public int? Age { get;set; }
    public bool Cute { get;set; }

}