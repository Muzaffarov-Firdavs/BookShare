using BookShare.DataAccess.Repository;
using BookShare.Domain.Enriries;
using BookShare.Domain.Enriries.Orders;
using BookShare.Service.DTOs;
using BookShare.Service.Services;



GenericRepository<FacultyAdmin> genericRepository = new GenericRepository<FacultyAdmin>();
FacultyAdmenService facultyAdmenService = new FacultyAdmenService(genericRepository);

FacultyAdminCreationDto facultyAdmin = new FacultyAdminCreationDto()
{
    FirstName = "Muxammad",
    LastName = "Muxammadov",
    Email = "mxuamamddv@gmail.com",
    PhoneNumber = "+998900235088",
    Password = "Password23",

};

await facultyAdmenService.CreateAsync(facultyAdmin);
