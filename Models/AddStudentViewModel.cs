namespace Studentportal.Models
{
    public class AddStudentViewModel
    {
        public Guid ID { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string School { get; set; }
        public required string Phone { get; set; }
        public required string Province { get; set; }
        public required string PreferredTimeslot { get; set; }
    }
}
