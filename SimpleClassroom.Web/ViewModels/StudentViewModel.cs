using System.Collections.Generic;

namespace SimpleClassroom.Web.ViewModels
{
    public class StudentViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<LegalResponsableViewModel> Responsables { get; set; }
    }
}