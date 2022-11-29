using Music4All.Infraestructure.Models;

namespace Music4All.API.Response;

public class MusicianResponse: BaseResponse<Musician>
{
    public MusicianResponse(Musician resource) : base(resource)
    {
    }

    public MusicianResponse(string message) : base(message)
    {
    }
}