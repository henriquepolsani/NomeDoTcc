namespace SimpleClassroom.Web.ViewModels
{
    public class LegalResponsableViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string StudentId { get; set; }
        public StudentViewModel Student { get; set; }
    }
}