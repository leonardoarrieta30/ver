using Music4All.Infraestructure.Models;

namespace Music4All.Infraestructure;

public interface IContractorRepository
{
    Task<List<Contractor>> getAll();

    Task<Contractor> getContractorById(int id);
    Task<bool> create(Contractor contractor);
    Task<bool> Update(int id, Contractor contractor);

    Task<bool> Delete(int id);
}