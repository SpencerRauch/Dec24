#pragma warning disable CS8618

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Posts.Models;

public class Post
{
    [Key]
    public int PostId { get;set; }

    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string Title { get;set; }

    [Required]
    [MinLength(2)]
    public string Body { get;set; }

    [DisplayName("Image URL")]
    public string? ImgURL { get;set; }

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    //fk
    public int UserId { get;set; }

    //nav prop
    public User? PostingUser { get;set; }
    public List<UserPostLike> UserLikes { get;set; } = [];


}