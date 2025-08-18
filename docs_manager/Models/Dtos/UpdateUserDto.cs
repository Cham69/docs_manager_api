namespace docs_manager.Models.Dtos
{
    public class UpdateUserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Epf { get; set; }
        public string? Phone { get; set; }
        public string? PasswordHash { get; set; }
    }
}
