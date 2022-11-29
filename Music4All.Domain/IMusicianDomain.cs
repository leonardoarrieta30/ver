using Music4All.Infraestructure.Models;

namespace Music4All.Domain;

public interface IMusicianDomain
{
    Task<List<Musician>> getAll();
    Task<Musician> getMusicianById(int id);
    Task<bool> createMusician(Musician musician);
    Task<bool> updateMusician(int id, Musician musician);
    Task<bool> deleteMusician(int id);
}