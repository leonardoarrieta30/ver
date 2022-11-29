using Music4All.API.Response;
using Music4All.Infraestructure;
using Music4All.Infraestructure.Models;

namespace Music4All.Domain;

public class GuardianDomain : IGuardianDomain
{
    private readonly IGuardianRepository _guardianRepository;


    public GuardianDomain(IGuardianRepository guardianRepository)
    {
        _guardianRepository = guardianRepository;
    }

    public async Task<IEnumerable<Guardian>> getAll()
    {
        return await _guardianRepository.getAll();
    }

    public async Task<Guardian> getGuardianById(int id)
    {
        return await _guardianRepository.getGuardianById(id);
    }

    public async Task<GuardianResponse> createGuardian(Guardian guardian)
    {
        try
        {
            await _guardianRepository.create(guardian);
            return new GuardianResponse(guardian);

        }catch(Exception e)
        {
            return new GuardianResponse($"An error occurred when saving the provider. See details at {e.Message}. {e.InnerException.Message}");
        }
    }

    public async Task<GuardianResponse> updateGuardian(int id, Guardian guardian)
    {
        var existingGuardian = await _guardianRepository.getGuardianById(id);
        if (existingGuardian == null)
            return new GuardianResponse($"Not provider found with id {id}");
        
        existingGuardian.firstname = guardian.firstname;
        existingGuardian.lastname = guardian.lastname;
        existingGuardian.email = guardian.email;
        existingGuardian.address = guardian.address;
        existingGuardian.gender = guardian.gender;
        try
        {
            _guardianRepository.update(existingGuardian);
            return new GuardianResponse(existingGuardian);
        }catch(Exception e)
        {
            return new GuardianResponse($"An error occured when updating the provider. See details at: {e.Message}. {e.InnerException.Message}");
        }
    }

    public async Task<GuardianResponse> deleteGuardian(int id)
    {
        var existingGuardian = await _guardianRepository.getGuardianById(id);
        if (existingGuardian == null)
            return new GuardianResponse($"Not provider found with id {id}");
        try
        {
            _guardianRepository.delete(existingGuardian);
            return new GuardianResponse(existingGuardian);

        }catch(Exception e)
        {
            return new GuardianResponse($"An error occurred while removing the provider. See details in {e.Message}. {e.InnerException.Message}");
        }
    }
}