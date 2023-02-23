using BookShare.Domain.Enriries;
using BookShare.Service.DTOs;
using BookShare.Service.ViewModels;

namespace BookShare.Service.Interfaces;

public interface IStudentService
{
    public Task<Student> CreateAsync(StudentCreationDto studentCreationDto);
    public Task<Student> UpdateAsync(long id , StudentCreationDto student);
    public Task<bool> DeleteAsync(long id);
    public Task<StudentViewModel> GetByIdAsync(long id);
    public Task<List<StudentViewModel>> GetAllAsync();
}
