using Music4All.Infraestructure.Models;

namespace Music4All.API.Response;

public class GuardianResponse: BaseResponse<Guardian>
{
    public GuardianResponse(Guardian resource) : base(resource)
    {
    }

    public GuardianResponse(string message) : base(message)
    {
    }
}