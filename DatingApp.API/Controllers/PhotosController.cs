using AutoMapper;
using CloudinaryDotNet;
using DatingApp.API.Data;
using DatingApp.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/users/{userId}/photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;
        public PhotosController(
            IDatingRepository repo, 
            IMapper mapper, 
            IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _mapper = mapper;
            _repo = repo;
            _cloudinaryConfig = cloudinaryConfig;
            
            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret            
            );
            _cloudinary = new Cloudinary(acc);
        }

        
        
    }
}