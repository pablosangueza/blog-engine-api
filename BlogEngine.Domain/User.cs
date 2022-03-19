namespace BlogEngine.Domain
{
    public enum UserRole
    {
        Public = 0,
        Writer = 1,
        Editor = 2
    }
    public class User
    {
        public string Username {get; set;}
        public string Password {get; set;}
        public string Name {get; set;}
        public UserRole Role {get; set;}

    }
}