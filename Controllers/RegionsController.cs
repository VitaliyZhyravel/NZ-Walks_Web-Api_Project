using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZ_Walks_web_api_project.Data;
using NZ_Walks_web_api_project.Models.DTO;
using NZ_Walks_web_api_project.Repositories;
using NZWalks.Models.Domain;

namespace NZ_Walks_web_api_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(mapper.Map<List<RegionRespondDto>>(await regionRepository.GetAllAsync()));
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await regionRepository.GetByIdAsync(id);
            if (region == null) return BadRequest();
            return Ok(mapper.Map<RegionRespondDto>(region));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegionRequestCreateDto region)
        {
            var newRegion = await regionRepository.CreateAsync(mapper.Map<Region>(region));
            return CreatedAtAction(nameof(GetById), new { id = newRegion.Id }, mapper.Map<RegionRespondDto>(newRegion));
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RegionRequestUpdateDto region)
        {
            var updateRegion = await regionRepository.UpdateAsync(id, mapper.Map<Region>(region));
            if (updateRegion == null) return BadRequest();
            return Ok(mapper.Map<RegionRespondDto>(updateRegion));
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) 
        {
           var deleteRegion =  await regionRepository.DeleteAsync(id);
            if (deleteRegion == null) return BadRequest();

            return Ok(mapper.Map<RegionRespondDto>(deleteRegion));
        }
    }
}
