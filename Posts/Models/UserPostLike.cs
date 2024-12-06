using System.ComponentModel.DataAnnotations;
namespace Posts.Models;

public class UserPostLike
{
    [Key]
    public int UserPostLikeId { get;set; }

    public DateTime CreatedAt { get;set; } = DateTime.Now;
    public DateTime UpdatedAt { get;set; } = DateTime.Now;

    //fk
    public int UserId { get;set; }
    public int PostId { get;set; }

    //nav prop
    public User? LikingUser { get;set; }
    public Post? LikedPost { get;set; }

}