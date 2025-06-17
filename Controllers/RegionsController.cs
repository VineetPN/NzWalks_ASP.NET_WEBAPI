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
        
        public RegionsController(NzWalksDbContext nzWalksDbContext, IDbRepository dbRepository) 
        {
            _nzWalksDbContext = nzWalksDbContext;
            _dbRepository = dbRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions(){
            
            var regionsDomain = await _dbRepository.GetAllRegionAsync();
            List<RegionDTO> regionDTO = new List<RegionDTO>();

            foreach (var region in regionsDomain){
                regionDTO.Add(new RegionDTO(){
                    Id = region.Id,
                    Code = region.Code,
                    RegionImageURL = region.RegionImageURL,
                    Name = region.Name
                });
            }
            return Ok(regionDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegionsByGuid([FromRoute] Guid id){
            var region = await _dbRepository.GetRegionAsync(id);
            if(region == null){
                return NotFound();
            }
            return Ok(new RegionDTO()
            {
                Id = region.Id,
                RegionImageURL = region.RegionImageURL,
                Name = region.Name,
                Code = region.Code
            });
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateNewRegion([FromBody] AddRegionRequestDTO addRegionRequestDTO){
            var regionDomain = new Region(){
                Id = Guid.NewGuid(),
                RegionImageURL = addRegionRequestDTO.RegionImageURL,
                Name = addRegionRequestDTO.Name,
                Code = addRegionRequestDTO.Code
            };

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
            regionDomain.Code = updateDTO.Code;
            regionDomain.Name = updateDTO.Name;
            regionDomain.RegionImageURL = updateDTO.RegionImageURL;

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