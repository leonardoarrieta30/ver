using Microsoft.EntityFrameworkCore;
using Music4All.Infraestructure.Context;
using Music4All.Infraestructure.Models;

namespace Music4All.Infraestructure;

public class GuardianRepository: IGuardianRepository
{
    private readonly Music4AllBDContext _music4AllBdContext;


    public GuardianRepository(Music4AllBDContext music4AllBdContext)
    {
        _music4AllBdContext = music4AllBdContext;
    }

    public async Task<IEnumerable<Guardian>> getAll()
    {
        return await _music4AllBdContext.Guardians.ToListAsync();
    }

    public async Task<Guardian> getGuardianById(int id)
    {
        return await _music4AllBdContext.Guardians.FindAsync(id);
    }

    public async Task create(Guardian guardian)
    {
        await _music4AllBdContext.Guardians.AddAsync(guardian);
        
    }

    public void update(Guardian guardian)
    {
        _music4AllBdContext.Update(guardian);
    }

    public void delete(Guardian guardian)
    {
        _music4AllBdContext.Remove(guardian);
    }
}