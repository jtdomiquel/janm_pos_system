namespace jandm_pos.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
    }
}
