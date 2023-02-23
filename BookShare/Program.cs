using BookShare.DataAccess.Repository;
using BookShare.Domain.Enriries;
using BookShare.Domain.Enriries.Orders;
using BookShare.Service.DTOs;
using BookShare.Service.Services;



GenericRepository<FacultyAdmin> genericRepository = new GenericRepository<FacultyAdmin>();
FacultyAdmenService facultyAdmenService = new FacultyAdmenService(genericRepository);

FacultyAdminCreationDto facultyAdmin = new FacultyAdminCreationDto()
{
    FirstName = "Rasulbek",
    LastName = "Maxsudov",
    Email = "Maxsudov@gmail.com",
    PhoneNumber = "+998900223030",
    Password = "Password",

};

await facultyAdmenService.CreateAsync(facultyAdmin);
