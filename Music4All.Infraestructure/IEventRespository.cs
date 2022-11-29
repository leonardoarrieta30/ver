using Music4All.Infraestructure.Models;

namespace Music4All.Infraestructure;

public interface IEventRepository
{
    Task<List<Event>> getAll();

    Task<Event> getEventById(int id);
    Task<bool> create(Event evento);
    Task<bool> Update(int id, Event evento);

    Task<bool> Delete(int id);
}