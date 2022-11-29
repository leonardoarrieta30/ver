using Music4All.Infraestructure.Models;

namespace Music4All.Domain;

public interface IContractorDomain
{
    Task<List<Contractor>> getAll();
    Task<Contractor> getContractorById(int id);
    Task<bool> createContractor(Contractor contractor);
    Task<bool> updateContractor(int id, Contractor contractor);
    Task<bool> deleteContractor(int id);
}