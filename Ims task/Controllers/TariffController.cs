using Ims_task.RequestModel;
using Ims_task.TariffDB;
using Microsoft.AspNetCore.Mvc;
using Ims_task.BillScripts;

namespace Ims_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TariffController : ControllerBase
    {
        private readonly ITariffService _tariffService;
        public TariffController(ITariffService tariffService)
        {
            _tariffService = tariffService;
        }
        [HttpPost("generateBill")]
        public IActionResult CalculateBill(BillRequestModel model)
        {
            var tariff = _tariffService.getTariff(model.id);
            int unit = model.endUnit - model.startUnit;
            BillCalculate bill = new BillCalculate(unit);

            var serviceChargeAmount = bill.GetServiceCharge();
            var energyChargeAmount = bill.GetEnergyCharge();
            if(model.startUnit > model.endUnit)
            {
                return BadRequest("End unit cannot be less than Start unit");
            }
            if (model.id <= 0)
            {
                return BadRequest("Please Enter a valid ID.");
            }

            if (tariff == null)
            { 
              _tariffService.AddTariff(model.id, model.startUnit, model.endUnit, energyChargeAmount, serviceChargeAmount);
                return Ok(new { serviceChargeAmount,  energyChargeAmount});
            }
            else
            {
                _tariffService.UpdateTariff(model.id, model.startUnit, model.endUnit, energyChargeAmount, serviceChargeAmount);
                return Ok(new { serviceChargeAmount,  energyChargeAmount});
            }
        }
        [HttpGet("getTariff/")]
        public IActionResult getTariff([FromQuery] int id)
        {
            var tariff = _tariffService.getTariff(id);
            if (tariff != null)
            {
                if(tariff.details == null)
                {
                    var message = "Tariff details cannot be found";
                    return Ok(new { tariff, message });
                }
                return Ok(new {tariff});
            }
            else
            {
                return BadRequest("The specified tariff doesnot exist yet");
            }
        }
        [HttpGet("getAllTariff/")]
        public IActionResult getAllTariffs()
        {
            var tariff = _tariffService.getTariff();
            if (tariff != null)
            {
                if (tariff.details == null)
                {
                    var message = "Tariff details cannot be found";
                    return Ok(new { tariff, message });
                }
                return Ok(new { tariff });
            }
            else
            {
                return BadRequest("The specified tariff doesnot exist yet");
            }
        }
    }
}
