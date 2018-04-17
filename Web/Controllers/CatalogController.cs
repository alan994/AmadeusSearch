using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dto.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Web.Services;

namespace Web.Controllers
{
    [Route("api/catalog")]
    public class CatalogController : Controller
    {
        private readonly CatalogService catalogService;
        private readonly ILogger<CatalogController> logger;

        public CatalogController(CatalogService catalogService, ILogger<CatalogController> logger)
        {
            this.catalogService = catalogService;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] SearchVM searchVM)
        {
            try
            {
                var result = await this.catalogService.GetFlights(searchVM);
                return Json(result);
            }
            catch(Exception ex)
            {                
                this.logger.LogError($"Something went wrong. Message: {ex.Message}", ex);
                return this.BadRequest(ex.Message);
            }
        }
    }
}
