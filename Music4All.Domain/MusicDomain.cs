using Music4All.Infraestructure;
using Music4All.Infraestructure.Models;

namespace Music4All.Domain;

public class MusicDomain : IMusicDomain
{
    private readonly IMusicRepository _musicRepository;
     
    public MusicDomain(IMusicRepository musicRepository)
    {
        _musicRepository = musicRepository;
    }
    public async Task<List<Music>> getAll()
    {
        return await _musicRepository.getAll();
    }

    public async Task<Music> getMusicById(int id)
    {
        return await _musicRepository.getMusicById(id);
    }

    public async Task<bool> createMusic(Music music)
    {
        return await _musicRepository.create(music);
    }

    public async Task<bool> updateMusic(int id, Music music)
    {
        return await _musicRepository.Update(id,music);
    }

    public async Task<bool> deleteMusic(int id)
    {
        return await _musicRepository.Delete(id);
    }
}