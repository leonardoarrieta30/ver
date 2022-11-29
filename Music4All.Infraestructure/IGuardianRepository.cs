using Music4All.Infraestructure.Models;

namespace Music4All.Infraestructure;

public interface IGuardianRepository
{
    Task<IEnumerable<Guardian>> getAll();

    Task<Guardian> getGuardianById(int id);

    Task create(Guardian guardian);

    void update(Guardian guardian);

    void delete(Guardian guardian);
}