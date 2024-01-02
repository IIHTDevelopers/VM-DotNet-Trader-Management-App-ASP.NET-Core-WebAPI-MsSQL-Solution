using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraderManagementApp.BusinessLayer.Interfaces;
using TraderManagementApp.BusinessLayer.ViewModels;
using TraderManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementApp.Entities;

namespace TraderManagementApp.Controllers
{
    [ApiController]
    public class TraderManagementController : ControllerBase
    {
        private readonly ITraderManagementService  _traderService;
        public TraderManagementController(ITraderManagementService traderservice)
        {
             _traderService = traderservice;
        }

        [HttpPost]
        [Route("create-trader")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateTrader([FromBody] Trader model)
        {
            var TraderExists = await  _traderService.GetTraderById(model.TraderId);
            if (TraderExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Trader already exists!" });
            var result = await  _traderService.CreateTrader(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Trader creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Trader created successfully!" });

        }


        [HttpPut]
        [Route("update-trader")]
        public async Task<IActionResult> UpdateTrader([FromBody] TraderViewModel model)
        {
            var Trader = await  _traderService.UpdateTrader(model);
            if (Trader == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Trader With Id = {model.TraderId} cannot be found" });
            }
            else
            {
                var result = await  _traderService.UpdateTrader(model);
                return Ok(new Response { Status = "Success", Message = "Trader updated successfully!" });
            }
        }

      
        [HttpDelete]
        [Route("delete-trader")]
        public async Task<IActionResult> DeleteTrader(long id)
        {
            var Trader = await  _traderService.GetTraderById(id);
            if (Trader == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Trader With Id = {id} cannot be found" });
            }
            else
            {
                var result = await  _traderService.DeleteTraderById(id);
                return Ok(new Response { Status = "Success", Message = "Trader deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-trader-by-id")]
        public async Task<IActionResult> GetTraderById(long id)
        {
            var Trader = await  _traderService.GetTraderById(id);
            if (Trader == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Trader With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(Trader);
            }
        }

        [HttpGet]
        [Route("get-all-traders")]
        public async Task<IEnumerable<Trader>> GetAllTraders()
        {
            return   _traderService.GetAllTraders();
        }
    }
}
