using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Posts.Models;

namespace Posts.Controllers;

public class PostController : Controller
{
    private readonly ILogger<PostController> _logger;

    private MyContext _context;

    public PostController(ILogger<PostController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("posts")]
    public ViewResult AllPosts()
    {
        List<Post> Posts = _context.Posts.OrderByDescending(p => p.CreatedAt).Take(100).ToList();
        return View(Posts);
    }

    [HttpGet("posts/{postId}")]
    public IActionResult ViewPost(int postId)
    {
        Post? SinglePost = _context.Posts.FirstOrDefault(p => p.PostId == postId);
        if (SinglePost == null)
        {
            return RedirectToAction("AllPosts");
        }
        return View(SinglePost);
    }

    [HttpGet("posts/new")]
    public ViewResult NewPost() => View();

    [HttpPost("posts/create")]
    public IActionResult CreatePost(Post newPost)
    {
        if (!ModelState.IsValid)
        {
            return View("NewPost");
        }
        _context.Add(newPost);
        _context.SaveChanges();
        // _context.Posts.Add(newPost);
        return RedirectToAction("AllPosts");
    }

    [HttpPost("posts/{postId}/delete")]
    public RedirectToActionResult DeletePost(int postId)
    {
        Post? SinglePost = _context.Posts.SingleOrDefault(p => p.PostId == postId );
        if (SinglePost != null)
        {
            _context.Remove(SinglePost);
            _context.SaveChanges();
        }
        return RedirectToAction("AllPosts");
    }

    [HttpGet("posts/{postId}/edit")]
    public IActionResult EditPost(int postId)
    {
        Post? ToBeEdited = _context.Posts.FirstOrDefault(p => p.PostId == postId );
        if (ToBeEdited == null)
        {
            return RedirectToAction("AllPosts");
        }
        return View(ToBeEdited);
    }

    [HttpPost("posts/{postId}/update")]
    public IActionResult UpdatePost(Post editedPost, int postId)
    {
        Post? OldPost = _context.Posts.FirstOrDefault(p => p.PostId == postId);
        if (!ModelState.IsValid || OldPost == null)
        {
            if (OldPost == null)
            {
                ModelState.AddModelError("Title","Post not found to edit, what did you do?!?");
            }
            return View("EditPost", editedPost);
        }
        OldPost.Title = editedPost.Title;
        OldPost.Body = editedPost.Body;
        OldPost.ImgURL = editedPost.ImgURL;
        OldPost.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return RedirectToAction("ViewPost", new {postId});

    }
}
