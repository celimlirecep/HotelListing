
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;

using AutoMapper;

using Microsoft.AspNetCore.Authorization;

using  HotelListing.API.Data.Abstract;
using  HotelListing.API.Data.Models.Country;
using  HotelListing.API.Data.Models;
using  HotelListing.API.Data.Exceptions;

namespace HotelListing.API.Controllers
{
    [Route("api/v{version:apiVersion}/countries")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    public class CountriesController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countries;
        private readonly ILogger<CountriesController> _logger;

        public CountriesController( IMapper mapper,ICountriesRepository countries,ILogger<CountriesController> logger)
        {
            
            _mapper = mapper;
            this._countries = countries;
            this._logger = logger;
        }

        // GET: api/Countries
        [HttpGet("GetAll")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GetCountryDTO>>> GetCountries()
        {
            var countries = await _countries.GetAllAsync();
            var records=_mapper.Map<List<GetCountryDTO>>(countries);
       
            return records ;
        }

        //GET: api/v1/GetPagedCountries/?startIndex=25&PageNumber=1
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<PagesResult<GetCountryDTO>>> GetPagedCountries([FromQuery] QueryParameters queryParameters)
        {
            var pagedCountriesResult = await _countries.GetAllAsync<GetCountryDTO>(queryParameters);
            return Ok(pagedCountriesResult);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CountryDTO>> GetCountry(int id)
        {
            var country =await _countries.GetDetails(id);

            if (country == null)
            {
                throw new NotFoundException(nameof(GetCountry), id);
            }
            var countryDto=_mapper.Map<CountryDTO>(country);

            return Ok(countryDto);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDTO updateCountryDTO)
        {

            if (id != updateCountryDTO.Id)
            {
                return BadRequest();
            }

            var country = await _countries.GetAsync(updateCountryDTO.Id);
            if (country==null)
            {
                throw new NotFoundException(nameof(PutCountry), id);
            }

            _mapper.Map(updateCountryDTO, country);
            try
            {
                await _countries.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    throw new NotFoundException(nameof(PutCountry), id);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDTO countryDTO)
        {
            var country=_mapper.Map<Country>(countryDTO);
           await _countries.AddAsync(country);
            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")] //[Authorize(Roles = "Administrator,User")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countries.GetAsync(id);
            if (country == null)
            {
                throw new NotFoundException(nameof(DeleteCountry), id);
            }

           await _countries.DeleteAsync(id);
            

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countries.Exist(id);
        }
    }
}
