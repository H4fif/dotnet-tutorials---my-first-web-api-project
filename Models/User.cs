using System.ComponentModel.DataAnnotations;

namespace MyFirstWebAPIProject.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; }

    [EmailAddress]
    public string Email { get; set; }
}
