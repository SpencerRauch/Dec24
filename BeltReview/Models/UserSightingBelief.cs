#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BeltReview.Models;

public class UserSightingBelief
{
    [Key]
    public int UserSightingBeliefId { get;set; }

   
    public DateTime CreatedAt {get;set;} = DateTime.Now;        
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    //fk 
    public int UserId { get;set; }
    public int SightingId { get;set; }

    //navprop 
    public User? BelievingUser { get;set; }   
    public Sighting? BelievedSighting { get;set; }
}