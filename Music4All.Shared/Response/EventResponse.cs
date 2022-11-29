using Music4All.Infraestructure.Models;

namespace Music4All.API.Response;

public class EventResponse : BaseResponse<Event>
{
    public EventResponse(Event resource) : base(resource)
    {
    }

    public EventResponse(string message) : base(message)
    {
    }
}