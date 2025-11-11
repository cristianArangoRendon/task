namespace task.core.DTOs.Users
{
    public class UpdateUserDTO
    {
        public int UserId { get; set; }
        public string? NameUser { get; set; }
        public string? EmailUser { get; set; }
        public string? PhoneUser { get; set; }
        public string? SpecialitiesUser { get; set; }
        public bool? IsActiveUser { get; set; }
        public string? UserImage { get; set; }
    }
}
