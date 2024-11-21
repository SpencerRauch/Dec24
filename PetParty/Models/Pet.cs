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
    [NoZNames]
    public string Name { get;set; }
    [Required]
    // [Options]
    [SuppliedOptions("Bobcat","Raccoon","Squirrel","Deer","Bear")]
    public string Species { get;set; }
    [Required]
    [Range(0,int.MaxValue)]
    public int? Age { get;set; }
    public bool Cute { get;set; }

}

public class NoZNamesAttribute : ValidationAttribute
{    
    // Call upon the protected IsValid method
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)    
    {   
        // We are expecting the value coming in to be a string
        // so we need to do a bit of type casting to our object
        // Strings work similarly to arrays under the hood 
        // so we can grab the first letter using its index   
        // If we discover that the first letter of our string is z...  
        if (value == null || ((string)value).ToLower()[0] == 'z')
        {        
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("No names that start with Z allowed!");   
        } else {   
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;  
        }  
    }
}

public class OptionsAttribute : ValidationAttribute
{    
    // Call upon the protected IsValid method
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)    
    {   

        string[] ValidOptions = ["Dog","Fish","Cat"]; // this would probably actual come from a database
        if (value == null || !ValidOptions.Contains((string)value))
        {        
            return new ValidationResult("Please choose Cat Fish or Dog");   
        } else {   
            return ValidationResult.Success;  
        }  
    }
}

public class SuppliedOptionsAttribute : ValidationAttribute
{    
    public string[] Options { get;set; }

    public SuppliedOptionsAttribute(params string[] options)
    {
        Options = options;
    }

    // Call upon the protected IsValid method
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)    
    {   

        
        if (value == null || !Options.Contains((string)value))
        {        
            return new ValidationResult("Please choose from supplied options");   
        } else {   
            return ValidationResult.Success;  
        }  
    }
}