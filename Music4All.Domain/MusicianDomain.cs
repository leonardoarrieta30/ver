using Music4All.Infraestructure;
using Music4All.Infraestructure.Models;

namespace Music4All.Domain;

public class MusicianDomain : IMusicianDomain
{
    private readonly IMusicianRepository _musicianRepository;

    public MusicianDomain(IMusicianRepository musicianRepository)
    {
        _musicianRepository = musicianRepository;
    }
    public async Task<List<Musician>> getAll()
    {
        
        return await _musicianRepository.getAll();
    }

    public async Task<Musician> getMusicianById(int id)
    {
        return await _musicianRepository.getMusicianById(id);
    }

    public async Task<bool> createMusician(Musician musician)
    {
        
        musician.Id = musician.Id;
        musician.Name = musician.Name;
        musician.Description = musician.Description;
        musician.Age = musician.Age;
        return await _musicianRepository.create(musician);
    }

    public async Task<bool> updateMusician(int id, Musician musician)
    {
        return await _musicianRepository.Update(id, musician);
    }

    public async Task<bool> deleteMusician(int id)
    {
        return await _musicianRepository.Delete(id);
    }
}