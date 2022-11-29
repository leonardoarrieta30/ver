using AutoMapper;
using Music4All.API.Resources;
using Music4All.Infraestructure.Models;

namespace Music4All.API.Mapper;

public class ModelToResource : Profile
{
    public ModelToResource()
    {
        CreateMap<Event, EventsResource>();
        CreateMap<Music, MusicResource>();
        CreateMap<Musician, MusicianResource>();
        CreateMap<Contractor, ContractorResource>();
        CreateMap<Guardian, GuardianResource>();

    }
}