#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeltReview.Models;
public class LogUser
{        

    [Required]
    [EmailAddress]
    [DisplayName("Email")]
    public string LogEmail { get; set; }        
    
    [Required]
    [DisplayName("Password")]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string LogPassword { get; set; }          
    
}