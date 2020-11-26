using AutoMapper;
using cloudApp.Models;
using cloudApp.Resources.Images;

namespace cloudApp.Mappers
{
    public class ResourceToModel : Profile
    {
        public ResourceToModel()
        {
            CreateMap<CreateImageResource, Image>();
        }
    }
}
