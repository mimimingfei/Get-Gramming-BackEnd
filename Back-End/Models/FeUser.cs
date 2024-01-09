namespace Back_End.Models
{
    public class FeUser
    {

        public FeUser(int userId, string userName, string email, string token) 
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            Token = token;

        }


        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
