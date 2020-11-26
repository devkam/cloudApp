using AutoMapper;
using cloudApp.Models;
using cloudApp.Resources.Images;

namespace cloudApp.Mappers
{
    public class ModelToResource : Profile
    {
        public ModelToResource()
        {
            CreateMap<Image, GetSingleImageResource>();
            CreateMap<Image, GetAllImageResource>();
        }
    }
}
