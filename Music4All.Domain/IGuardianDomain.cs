using Music4All.API.Response;
using Music4All.Infraestructure.Models;

namespace Music4All.Domain;

public interface IGuardianDomain
{
    Task<IEnumerable<Guardian>> getAll();

    Task<Guardian> getGuardianById(int id);

    Task<GuardianResponse> createGuardian(Guardian guardian);

    Task<GuardianResponse> updateGuardian(int id, Guardian guardian);

    Task<GuardianResponse> deleteGuardian(int id);
}