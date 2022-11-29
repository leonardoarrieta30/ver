using Microsoft.EntityFrameworkCore;
using Music4All.Infraestructure.Context;
using Music4All.Infraestructure.Models;

namespace Music4All.Infraestructure;

public class MusicianRepository :IMusicianRepository
{
    
    private readonly Music4AllBDContext _music4AllBdContext;
    public MusicianRepository(Music4AllBDContext music4AllDbContext)
    {
        _music4AllBdContext = music4AllDbContext;
    }
    
    
    public async Task<List<Musician>> getAll()
    {
        return await _music4AllBdContext.Musicians
            .ToListAsync();
    }

    public async Task<Musician> getMusicianById(int id)
    {
        return await _music4AllBdContext.Musicians
            .SingleOrDefaultAsync(musician => musician.Id == id);
    }

    public async Task<bool> create(Musician musician)
    {
        using (var transacction = await _music4AllBdContext.Database.BeginTransactionAsync())
        {
            try
            {
               
                await _music4AllBdContext.Musicians.AddAsync(musician);
                await _music4AllBdContext.SaveChangesAsync();
                await _music4AllBdContext.Database.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _music4AllBdContext.Database.RollbackTransactionAsync();
            }
            finally
            {
                _music4AllBdContext.DisposeAsync();
            }
        }
        return true;
    }

    public async Task<bool> Update(int id, Musician musician)
    {
        using (var transacction = await _music4AllBdContext.Database.BeginTransactionAsync())
        {
            try
            {
                var existingMusician = await _music4AllBdContext.Musicians.FindAsync(id);

                existingMusician.Name = musician.Name;
                existingMusician.Age = musician.Age;
                existingMusician.Correo = musician.Correo;
                existingMusician.Description = musician.Description;
                existingMusician.DateCreated = DateTime.Now;

                _music4AllBdContext.Musicians.Update(existingMusician);
                await _music4AllBdContext.SaveChangesAsync();
                await _music4AllBdContext.Database.CommitTransactionAsync();
                
            }
            catch (Exception ex)
            {
                await _music4AllBdContext.Database.RollbackTransactionAsync();
            }
        }

        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var musician = await _music4AllBdContext.Musicians.FindAsync(id);

        _music4AllBdContext.Musicians.Remove(musician);
        await _music4AllBdContext.SaveChangesAsync();
        return true;
    }
}