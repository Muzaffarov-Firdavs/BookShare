using BookShare.Domain.Enriries;
using BookShare.Service.Commons.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BookShare.Service.DTOs;

public class FacultyAdminCreationDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false), EmailAttribute]
    public string Email { get; set; } = string.Empty;

    [Required(AllowEmptyStrings =false), PhoneNumberAttribute]
    public string PhoneNumber { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public static implicit operator FacultyAdmin(FacultyAdminCreationDto adminCreationDto)
    {
        return new FacultyAdmin()
        {
            FirstName = adminCreationDto.FirstName,
            LastName = adminCreationDto.LastName,
            Email = adminCreationDto.Email,
            PhoneNumber = adminCreationDto.PhoneNumber,
        };
    }
}

