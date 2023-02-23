using BookShare.Domain.Enriries;
using Org.BouncyCastle.Crmf;

namespace BookShare.Service.ViewModels;

public class FacultyAdminViewModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public static implicit operator FacultyAdmin(FacultyAdminViewModel facultyAdminViewModel)
    {
        return new FacultyAdmin()
        {
            FirstName = facultyAdminViewModel.FirstName,
            LastName = facultyAdminViewModel.LastName,
            Email = facultyAdminViewModel.Email,
            PhoneNumber = facultyAdminViewModel.PhoneNumber,

        };
    }
}
