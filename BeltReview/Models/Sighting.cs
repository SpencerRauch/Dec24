#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BeltReview.Models;

public class Sighting
{
    [Key]
    public int SightingId { get;set; }

    [Required]
    [MinLength(3)]
    public string Title { get;set; }

    [Required]
    public string Location { get;set; }

    [Required]
    [DataType(DataType.Date)]
    [PastDate]
    public DateTime Date { get;set; }

    [Required]
    [MinLength(30)]
    public string Description { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;        
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    //fk 
    public int UserId { get;set; }

    //navprop 
    public User? ReportingUser { get;set; } 
    public List<UserSightingBelief> UserBeliefs { get;set; } = [];  
}


public class PastDateAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {        
        // You first may want to unbox "value" here and cast to to a DateTime variable!
        if (value == null)
        {
            return new ValidationResult("Date must be in the past");
        }
        DateTime Input = (DateTime)value;
        DateTime Now = DateTime.Now;

        if (Input > Now)
        {
            return new ValidationResult("Date must be in the past");
        }
        else
        {
            return ValidationResult.Success;
        }    
    }
}