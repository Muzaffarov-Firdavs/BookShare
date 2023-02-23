using BookShare.DataAccess.Repository;
using BookShare.Domain.Enriries;
using BookShare.Service.Commons;
using BookShare.Service.Commons.Exceptions;
using BookShare.Service.Commons.Security;
using BookShare.Service.DTOs;
using BookShare.Service.Interfaces;
using BookShare.Service.ViewModels;
using System.Reflection;

namespace BookShare.Service.Services
{
    public class FacultyAdmenService : IFacultyAdminService
    {
        private readonly GenericRepository<FacultyAdmin> _genericRepository;

        public FacultyAdmenService(GenericRepository<FacultyAdmin> genericRepository)
        {
           this._genericRepository = genericRepository;
        }

        public async Task<FacultyAdmin> CreateAsync(FacultyAdminCreationDto adminCreationDto)
        {
            var admins = await this._genericRepository.GetAllAsync();
            var emailCheck = admins.FirstOrDefault((email)=> email.Email == adminCreationDto.Email);
            if (emailCheck is not null)
            {
                throw new AlreadyExsistException("User already exist:");
            }
            var phoneNumber = admins.FirstOrDefault((phonenumber) => phonenumber.PhoneNumber== adminCreationDto.PhoneNumber);
            if (phoneNumber is not null)
            {
                throw new AlreadyExsistException("User already exist:");
            }

            var hasherResult = PasswordHasher.Hash(adminCreationDto.Password);

            var facultyAdmin = (FacultyAdmin)adminCreationDto;
            facultyAdmin.CreatedAt= DateTime.Now;
            facultyAdmin.UpdatedAt = DateTime.Now;

            facultyAdmin.PasswordHash = hasherResult.passwordHasher;
            facultyAdmin.Salt = hasherResult.salt;

            var respond = await this._genericRepository.CreateAsync(facultyAdmin);
            return respond;


        }

        public async Task<bool> DeleteAsync(long id)
        {
            var model = await this._genericRepository.GetByIdAsync(id);

            if (model is not null)
            {
                var respond = await this._genericRepository.DeleteAsync(model.Id);
                return respond;
            }
            else throw new NotFoundException("User not found");
        }

        public async Task<List<FacultyAdminViewModel>> GetAllAsync()
        {
            var admins = await this._genericRepository.GetAllAsync();
            FacultyAdminViewModel adminViewModel = new FacultyAdminViewModel();  
            List<FacultyAdminViewModel> viewModels = new List<FacultyAdminViewModel>();

            foreach (var admin in admins)
            {
                adminViewModel.FirstName = admin.FirstName;
                adminViewModel.LastName = admin.LastName;
                adminViewModel.Email = admin.Email;
                adminViewModel.PhoneNumber = admin.PhoneNumber;

                viewModels.Add(adminViewModel);
            }
            return viewModels;
           
        }

        public async Task<FacultyAdminViewModel> GetByIdAsync(long id)
        {
            var admin = await this._genericRepository.GetByIdAsync(id);

            if (admin is null)
            {
                throw new NotFoundException("User not found");
            }

            FacultyAdminViewModel adminViewModel = new FacultyAdminViewModel();

            adminViewModel.FirstName = admin.FirstName;
            adminViewModel.LastName = admin.LastName;
            adminViewModel.Email = admin.Email;
            adminViewModel.PhoneNumber = admin.PhoneNumber;

            return adminViewModel;
        }

        public async Task<FacultyAdmin> UpdateAsync(long id, FacultyAdminCreationDto facultyAdminDto)
        {
            var admin = await this._genericRepository.GetByIdAsync(id);

            var hasherResult = PasswordHasher.Hash(facultyAdminDto.Password);

            if (admin is not null)
            {
                var entity = (FacultyAdmin)facultyAdminDto;

                entity.Id = id;
                entity.CreatedAt = DateTime.UtcNow;
                entity.UpdatedAt = DateTime.UtcNow;

                entity.PasswordHash = hasherResult.passwordHasher;
                entity.Salt = hasherResult.salt;

                var respond = await this._genericRepository.UpdateAsync(id, entity);

                return respond;

            }
            else
            {
                throw new NotFoundException("User not found: ");
            }
            


        }
    }
}
