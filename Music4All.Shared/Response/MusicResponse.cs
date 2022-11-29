using Music4All.Infraestructure.Models;

namespace Music4All.API.Response;

public class MusicResponse : BaseResponse<Music>
{
    public MusicResponse(Music resource) : base(resource)
    {
    }

    public MusicResponse(string message) : base(message)
    {
    }
}