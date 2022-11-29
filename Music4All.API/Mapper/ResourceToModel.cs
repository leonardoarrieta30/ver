using AutoMapper;
using Music4All.API.Resources;
using Music4All.Infraestructure.Models;

namespace Music4All.API.Mapper;

public class ResourceToModel : Profile
{
    public ResourceToModel()
    {
        CreateMap<EventsResource, Event>();
        CreateMap<MusicResource, Music>();
        CreateMap<ContractorResource, Contractor>();
        CreateMap<MusicianResource, Musician>();
        CreateMap<SaveGuardianResource, Guardian>();
    }
}