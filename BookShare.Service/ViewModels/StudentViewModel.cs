using BookShare.Domain.Enriries;

namespace BookShare.Service.ViewModels
{
    public class StudentViewModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
      
        public static implicit operator Student(StudentViewModel viewModel)
        {
            return new Student
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
            };
        }

    }
}
