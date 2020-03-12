using System.Collections;
using AutoMapper;
using DecouplingOData.Application.Dtos;
using DecouplingOData.Application.Interfaces.AppServices;
using DecouplingOData.Services.WebApi.AutoMapper;
using DecouplingOData.Services.WebApi.DtoModels;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;

namespace DecouplingOData.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/public/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryAppService<CategoryDto> _categoryAppService;
        private IMapper Mapper;

        public CategoriesController(ICategoryAppService<CategoryDto> categoryAppService)
        {
            _categoryAppService = categoryAppService;
            SetMapper(new MappingDtoModelProfile());
        }

        [HttpGet]
        [Route("")]
        [EnableQuery]
        public ActionResult<IEnumerable> Get()
        {
            var model = Startup.GetEdmModel(); 
            var context = new ODataQueryContext(model,
                                                typeof(CategoryDtoModel),
                                                Request.ODataFeature().Path);
            var queryOptions = new ODataQueryOptions<CategoryDtoModel>(context, Request);
            var categories = _categoryAppService.GetAll(queryOptions);
            return Ok(categories);
        }

        [HttpPost]
        [Route("")]
        public void Post(CategoryDto category)
        {
            _categoryAppService.Add(category);
        }

        private void SetMapper(Profile mappingDtoModelProfile)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(mappingDtoModelProfile);
            });

            var mapper = mappingConfig.CreateMapper();
            Mapper = mapper;
        }
    }
}