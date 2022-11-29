using Microsoft.EntityFrameworkCore;
using Music4All.Infraestructure.Context;
using Music4All.Infraestructure.Models;

namespace Music4All.Infraestructure;

public class EventRepository : IEventRepository
{
    private readonly Music4AllBDContext _music4AllBdContext;

    public EventRepository(Music4AllBDContext music4AllDbContext)
    {
        _music4AllBdContext = music4AllDbContext;
    }
    public async Task<List<Event>> getAll()
    {
       // new Music().Musician.Name
       return await _music4AllBdContext.Events
           .ToListAsync();
       
    }

    public async Task<Event> getEventById(int id)
    {
        return await _music4AllBdContext.Events
            .SingleOrDefaultAsync(evento => evento.Id == id);
    }

    public async Task<bool> create(Event evento)
    {
        using (var transacction = await _music4AllBdContext.Database.BeginTransactionAsync())
        {
            try
            {
               
                await _music4AllBdContext.Events.AddAsync(evento);
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

    public async Task<bool> Update(int id, Event evento)
    {
        using (var transacction = await _music4AllBdContext.Database.BeginTransactionAsync())
        {
            try
            {
                var existingEvent = await _music4AllBdContext.Events.FindAsync(id);

                existingEvent.Title = evento.Title;
                existingEvent.Description = evento.Description;
                existingEvent.url = evento.url;
                existingEvent.DateCreated = DateTime.Now;

                _music4AllBdContext.Events.Update(existingEvent);
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
        var evento = await _music4AllBdContext.Events.FindAsync(id);

        _music4AllBdContext.Events.Remove(evento);
       await _music4AllBdContext.SaveChangesAsync();
        return true;
    }
    
}