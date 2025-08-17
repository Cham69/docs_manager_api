namespace docs_manager.Models.Dtos
{
    public class CreateUserDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public required string PasswordHash { get; set; }
        public int? CompanyId { get; set; }
        public int? DepartmentId { get; set; }
    }
}
