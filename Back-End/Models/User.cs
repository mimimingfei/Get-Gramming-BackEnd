using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back_End.Models
{ 
public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
	public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}
}