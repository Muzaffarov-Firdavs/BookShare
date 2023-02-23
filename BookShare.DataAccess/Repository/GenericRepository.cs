using BookShare.DataAccess.Configurations;
using BookShare.DataAccess.IRepository;
using BookShare.Domain.Commons;
using BookShare.Domain.Enriries;
using BookShare.Domain.Enriries.Orders;
using Newtonsoft.Json;

namespace BookShare.DataAccess.Repository;


public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Auditable
{
    private string path;
    private long lastId;

    public GenericRepository()
    {

        if (typeof(TEntity) == typeof(Book))
        {
            path = DbPath.BOOKS;
        }
        else if (typeof(TEntity) == typeof(FacultyAdmin))
        {
            path = DbPath.ADMINS;
        }
        else if (typeof(TEntity) == typeof(Order))
        {
            path = DbPath.ORDERS;
        }
        else if (typeof(TEntity) == typeof(Student))
        {
            path = DbPath.STUDENTS;
        }
        else if (typeof(TEntity) == typeof(Payment))
        {
            path = DbPath.PAYMENTS;
        }
        
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {

       
        var entities = await GetAllAsync();
        if (entities.Count == 0) 
        {
            lastId = 1;
        }
        else
        {
            lastId = entities[entities.Count - 1].Id;
        }
        entity.Id = ++lastId;
        entity.CreatedAt = DateTime.Now;
        entities.Add(entity);

        var json = JsonConvert.SerializeObject(entities,Formatting.Indented);
        await File.WriteAllTextAsync(path, json);
        return entity;
    }

    public async Task<bool> DeleteAsync(long Id)
    {
        var models = await GetAllAsync();
        var model = models.FirstOrDefault((m) => m.Id == Id);

        if (model != null)
        {
            models.Remove(model);
            string json = JsonConvert.SerializeObject(models,Formatting.Indented);
            await File.WriteAllTextAsync(path, json);
            return true;
        }
        return false;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        string model = await File.ReadAllTextAsync(path);
        if (string.IsNullOrEmpty(model))
        {
            model = "[]";
        }
        List<TEntity> models = JsonConvert.DeserializeObject<List<TEntity>>(model);
        return models;
    }

    public async Task<TEntity> GetByIdAsync(long id)
    {
        var models = await GetAllAsync();
        var model = models.FirstOrDefault(model => model.Id == id);

        if (model != null)
        {
            return model;
        }
        return model;
    }

    public async Task<TEntity> UpdateAsync(long id,TEntity entity)
    {
        var models = await GetAllAsync();
        var model = models.FirstOrDefault((model) => model.Id == id);
        if (model != null)
        {
            var index = models.IndexOf(model);
            models.RemoveAt(index);

            entity.CreatedAt= model.CreatedAt;
            entity.UpdatedAt= DateTime.Now;

            models.Insert(index, entity);

            var json = JsonConvert.SerializeObject(models,Formatting.Indented);
            await File.WriteAllTextAsync(path,json);
            return model;
        }

        return model;
    }
}
