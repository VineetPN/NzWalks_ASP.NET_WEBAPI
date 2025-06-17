using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApiProjectTest.Data;
using MyApiProjectTest.Models.Domain;
using MyApiProjectTest.Models.Domain.DTOs;
using MyAPIProjectTest.Models.DTOs;
using MyAPIProjectTest.Repositories;

namespace MyApiProjectTest.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : ControllerBase{
        
        private readonly NzWalksDbContext _nzWalksDbContext;
        private readonly IDbRepository _dbRepository;
        
        private readonly IMapper _mapper;
        public RegionsController(NzWalksDbContext nzWalksDbContext, IDbRepository dbRepository, IMapper mappper) 
        {
            _nzWalksDbContext = nzWalksDbContext;
            _dbRepository = dbRepository;
            _mapper = mappper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions(){
            
            var regionsDomain = await _dbRepository.GetAllRegionAsync();
            
            return Ok(_mapper.Map<List<RegionDTO>>(regionsDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionsByGuid([FromRoute] Guid id){
            var region = await _dbRepository.GetRegionAsync(id);
            if(region == null){
                return NotFound();
            }
            return Ok(_mapper.Map<RegionDTO>(region));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateNewRegion([FromBody] AddRegionRequestDTO addRegionRequestDTO){
            var regionDomain = _mapper.Map<Region>(addRegionRequestDTO);

            try{
                await _dbRepository.AddRegionAsync(regionDomain);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
            return CreatedAtAction(nameof(GetRegionsByGuid), new {id = regionDomain.Id}, regionDomain);
            
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> PutRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateDTO){
            var regionDomain = _nzWalksDbContext.regions.FirstOrDefault(x => x.Id == id);
            if(regionDomain is null){
                return NotFound();
            }
            regionDomain = _mapper.Map<Region>(updateDTO);
            
            // Update the database here
            await _dbRepository.UpdateRegionAsync(regionDomain);
            return CreatedAtAction(nameof(GetRegionsByGuid), new{id = regionDomain.Id}, regionDomain);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id){
            try{
                var regionDomain = await _dbRepository.GetRegionAsync(id) 
                    ?? throw new ArgumentException("Record not found");
                await _dbRepository.DeleteRegionAsync(regionDomain);
                return Ok($"{id} deleted from the database.");
                
            }
            catch(ArgumentException ex){
                return NotFound();
            }
        }
        
    }

}