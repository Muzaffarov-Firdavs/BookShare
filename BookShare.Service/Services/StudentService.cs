using BookShare.DataAccess.IRepository;
using BookShare.DataAccess.Repository;
using BookShare.Domain.Enriries;
using BookShare.Service.Commons;
using BookShare.Service.Commons.Exceptions;
using BookShare.Service.Commons.Security;
using BookShare.Service.DTOs;
using BookShare.Service.Interfaces;
using BookShare.Service.ViewModels;
using System.Net;
using System.Runtime.CompilerServices;

namespace BookShare.Service.Services;

public class StudentService : IStudentService
{
    private readonly IGenericRepository<Student> _genericRepository;
    public StudentService(GenericRepository<Student> genericRepository)
    {
        this._genericRepository = genericRepository;
    }

    public async Task<Student> CreateAsync(StudentCreationDto studentCreationDto)
    {
        var models = await _genericRepository.GetAllAsync();
        var emailCheck = models.FirstOrDefault((e) => e.Email == studentCreationDto.Email);
        if (emailCheck is not null)
        {
        }

        var phoneNumberCheck = models.FirstOrDefault((p) => p.PhoneNumber == studentCreationDto.PhoneNumber);
        if (phoneNumberCheck is not null)
        {
            throw new AlreadyExsistException("User Already exist:");
        }

        var hasherResult = PasswordHasher.Hash(studentCreationDto.Password);

        var student = (Student)studentCreationDto;
        student.CreatedAt = DateTime.UtcNow;
        student.UpdatedAt = DateTime.UtcNow;

        student.PasswordHash = hasherResult.passwordHasher;
        student.Salt = hasherResult.salt;

        var result = await this._genericRepository.CreateAsync(student);

        return result;


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

    public async Task<List<StudentViewModel>> GetAllAsync()
    {
        var models = await this._genericRepository.GetAllAsync();
        StudentViewModel studentViewModel = new StudentViewModel();
        List<StudentViewModel> entities = new List<StudentViewModel>();



        foreach (var model in models)
        {
            studentViewModel.FirstName = model.FirstName;
            studentViewModel.LastName = model.LastName;
            studentViewModel.Email = model.Email;
            studentViewModel.PhoneNumber = model.PhoneNumber;

            entities.Add(studentViewModel);
        }
        return entities;
    }

    public async Task<StudentViewModel> GetByIdAsync(long id)
    {
        var model = await this._genericRepository.GetByIdAsync(id);
        if (model is  null)
        {
            throw new NotFoundException("User not found");
        }
        StudentViewModel studentViewModel = new StudentViewModel();

        studentViewModel.FirstName = model.FirstName;
        studentViewModel.LastName = model.LastName;
        studentViewModel.Email = model.Email;
        studentViewModel.PhoneNumber = model.PhoneNumber;

        return studentViewModel;
       
       
    }

    public async Task<Student> UpdateAsync(long id, StudentCreationDto studentCreationDto)
    {
        var model = await this._genericRepository.GetByIdAsync(id);

        var hasherResult = PasswordHasher.Hash(studentCreationDto.Password);


        if (model is not null)
        {
            var student = (Student)studentCreationDto;
            student.Id = id;
            student.PasswordHash = hasherResult.passwordHasher;
            student.Salt = hasherResult.salt;

            student.CreatedAt = DateTime.UtcNow;
            student.UpdatedAt = DateTime.UtcNow;


            var respond = await this._genericRepository.UpdateAsync(id, student);

            return respond;

        }
        else
        {
            throw new NotFoundException("User not found: ");
        }
    }
}
