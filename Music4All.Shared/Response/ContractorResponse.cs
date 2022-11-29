using Music4All.Infraestructure.Models;

namespace Music4All.API.Response;

public class ContractorResponse: BaseResponse<Contractor>
{
    public ContractorResponse(Contractor resource) : base(resource)
    {
    }

    public ContractorResponse(string message) : base(message)
    {
    }
}