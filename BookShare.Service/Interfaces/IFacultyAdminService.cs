using BookShare.Domain.Enriries;
using BookShare.Service.DTOs;
using BookShare.Service.ViewModels;

namespace BookShare.Service.Interfaces;

public interface IFacultyAdminService
{
    public Task<FacultyAdmin> CreateAsync(FacultyAdminCreationDto facultyAdminCreationDto);
    public Task<List<FacultyAdminViewModel>> GetAllAsync();
    public Task<FacultyAdminViewModel> GetByIdAsync(long id);
    public Task<FacultyAdmin> UpdateAsync(long id, FacultyAdminCreationDto facultyAdminDto);
    public Task<bool> DeleteAsync(long id);
}
