using Music4All.Infraestructure.Models;

namespace Music4All.Infraestructure;

public interface IMusicianRepository
{
    Task<List<Musician>> getAll();

    Task<Musician> getMusicianById(int id);
    Task<bool> create(Musician musician);
    Task<bool> Update(int id, Musician musician);

    Task<bool> Delete(int id);
}