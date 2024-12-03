using dolar_api.model;
using dolar_api.resource;
using Microsoft.AspNetCore.Mvc;

namespace dolar_api.Controllers
{

    
    [Route("api/[Controller]")]
    [ApiController]

    public class CotizacionController : ControllerBase
    {
        [HttpGet]
        [Route("api/ObtenerCotizacion")]
        public string ObtenerCotizacion()
        {
            DolarApi api = new DolarApi(); //instanciamos la clase dolar api

            return api.ObtenerCotizacion().Result;
        }

        [HttpPost]
        [Route("api/ObtenerCotizacionEspecifica")]

        public async Task<string> ObtenerCotizacionEspecifica([FromBody] Currency currency)
        {
            DolarApi dolarApi = new DolarApi();

            return await dolarApi.ObtenerCotizacionEspecifica(currency);
        }

    }
}
