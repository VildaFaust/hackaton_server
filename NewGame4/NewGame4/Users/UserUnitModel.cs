namespace NewGame4.Users
{
    public class UserUnitModel : IUserUnitModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Session { get; set; }
        public bool IsNew { get; set; }
        public int IsAuthorisation { get; set; }
        public int CurrentScreen { get; set; }
    }
}