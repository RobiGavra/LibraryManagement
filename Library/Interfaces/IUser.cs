namespace LibraryManagement.Interfaces
{
    public interface IUser
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public bool Removed { get; set; }
    }
}
