using Music4All.Infraestructure.Models;

namespace Music4All.Domain;

public interface IEventDomain
{
    Task<List<Event>> getAll();
    Task<Event> getEventById(int id);
    Task<bool> createEvent(Event evento);
    Task<bool> updateEvent(int id, Event evento);
    Task<bool> deleteEvent(int id);
}