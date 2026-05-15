namespace ALLmoco.Models
{
    public class User
    {
        public int Id { get; set; } // primary key
        public string Username { get; set; } = string.Empty; // string do username do usuario
        public string Password { get; set; } = string.Empty; // senha do usuario
    }
}
