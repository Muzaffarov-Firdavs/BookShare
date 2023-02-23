using BookShare.Domain.Enriries;
using BookShare.Service.Commons.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BookShare.Service.DTOs;

public class StudentCreationDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false), Email]
    public string Email { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = false), PhoneNumberAttribute]

    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;


    public static implicit operator Student(StudentCreationDto dto)
    {
        return new Student() 
        {
            FirstName= dto.FirstName,
            LastName= dto.LastName,
            Email= dto.Email,
            PhoneNumber= dto.PhoneNumber,
        };
    }

}
