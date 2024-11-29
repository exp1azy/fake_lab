namespace FakeLab.Test
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email
        {
            get => _email;
            set => _email = string.Concat(value, "@example.com");
        }

        public DateOnly Birth { get; set; }

        public DateTime Created { get; set; }
 
        public Role Role { get; set; }

        public List<Role> Roles { get; set; }

        public IEnumerable<int> Ints { get; set; }

        public string[] Strings { get; set; }

        private string _email;

        private object Obj { get; set; }
    }

    public enum Role
    {
        User,
        Admin,
        Moderator
    }
}
