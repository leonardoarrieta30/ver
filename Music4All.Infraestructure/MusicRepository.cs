using Microsoft.EntityFrameworkCore;
using Music4All.Infraestructure.Context;
using Music4All.Infraestructure.Models;

namespace Music4All.Infraestructure;

public class MusicRepository : IMusicRepository
{
    private readonly Music4AllBDContext _music4AllBdContext;
    
    public MusicRepository(Music4AllBDContext music4AllDbContext)
    {
        _music4AllBdContext = music4AllDbContext;
    }

    public async Task<List<Music>> getAll()
    {
        return await _music4AllBdContext.Musics
            .ToListAsync();
    }

    public async Task<Music> getMusicById(int id)
    {
        return await _music4AllBdContext.Musics
            .SingleOrDefaultAsync(music => music.Id == id);
    }

    public async Task<bool> create(Music music)
    {
        using (var transacction = await _music4AllBdContext.Database.BeginTransactionAsync())
        {
            try
            {
               
                await _music4AllBdContext.Musics.AddAsync(music);
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

    public async Task<bool> Update(int id, Music music)
    {
        using (var transacction = await _music4AllBdContext.Database.BeginTransactionAsync())
        {
            try
            {
                var existingMusic = await _music4AllBdContext.Musics.FindAsync(id);

                existingMusic.Title = music.Title;
                existingMusic.Description = music.Description;
                existingMusic.url = music.url;
                existingMusic.DateCreated = new DateTime();
                _music4AllBdContext.Musics.Update(existingMusic);
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
        var music = await _music4AllBdContext.Musics.FindAsync(id);

        _music4AllBdContext.Musics.Remove(music);
        await _music4AllBdContext.SaveChangesAsync();
        return true;
    }
}