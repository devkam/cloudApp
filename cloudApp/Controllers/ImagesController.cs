using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using cloudApp.Models;
using cloudApp.Resources.Images;
using cloudApp.Services.Api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cloudApp.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public ImagesController(IImageService imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostImage([FromBody] CreateImageResource model)
        {
            try
            {
                var image = _mapper.Map<Image>(model);
                var guid = await _imageService.UploadImageAsync(image, model.ImageContent);
                return Ok(new CreatedImageResponseResource { Guid = guid });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetImages()
        {
            var images = await _imageService.GetImages();
            var result = _mapper.Map<List<GetAllImageResource>>(images.ToList());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetImage(string id)
        {
            var image = await _imageService.GetImageById(id);
            var result = _mapper.Map<GetSingleImageResource>(image);
            return Ok(result);
        }
    }
}
