using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618
namespace Posts.Models;

public class UserPostComment
{
    [Key]
    public int UserPostCommentId { get;set; }

    [Required]
    public string Body { get;set; }

    public DateTime CreatedAt { get;set; } = DateTime.Now;
    public DateTime UpdatedAt { get;set; } = DateTime.Now;

    //fk
    public int UserId { get;set; }
    public int PostId { get;set; }

    //nav prop
    public User? CommentingUser { get;set; }
    public Post? CommentedPost { get;set; }

}