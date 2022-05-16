using System.Net;
using Hospitality.Data;
using Hospitality.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    public class DevicesController : Controller
    {
        static HospitalityContext context;

        public DevicesController(HospitalityContext hospitalityContext)
        {
            context = hospitalityContext;
        }

        [HttpGet("Search/Devices")]
        [ProducesResponseType(typeof(List<Device>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllDevices()
        {
            return Ok(context.Devices.Where(d => d.OperatorID == 100018 && d.AccountDevice != null).ToList());
        }

        [HttpGet("Search/Devices/{macAddress}")]
        [ProducesResponseType(typeof(Device), (int)HttpStatusCode.OK)]
        public IActionResult GetDevice(string macAddress)
        {
            var device = context.Devices.Where(d => d.OperatorID == 100018 && d.MACAddress == macAddress).FirstOrDefault();
            if (device!= null)
                return Ok(device);
            else
                return BadRequest();
        }

        [HttpPost("NewDevice/{macAddress}")]
        public IActionResult PostNewDevice(string macAddress)
        {
            var device = new Device
            {
                ID = Guid.NewGuid(),
                MACAddress = macAddress,
                OperatorID = 100018,
                ModelID = Guid.Parse("9817f7c9-9ef6-4775-9be8-074d713358a5"),
                StatusID = 1,
                SerialNumber = "12345"
            };
            context.Devices.Add(device);
            return Created("Search/Devices/{macAddress}", context.SaveChanges());
        }

        [HttpPut("Update/{macAddress}/{statusID}")]
        public IActionResult UpdateStatusCode(string macAddress, int statusID)
        {
            var device = context.Devices.Where(d => d.OperatorID == 100018 && d.MACAddress == macAddress).FirstOrDefault();
            if (device == null)
                return BadRequest();
            device.StatusID = statusID;
            return Ok(context.SaveChanges());
        }

        [HttpDelete("Delete/{macAddress}")]
        public IActionResult DeleteDevice(string macAddress)
        {
            var device = context.Devices.Where(d => d.OperatorID == 100018 && d.MACAddress == macAddress).FirstOrDefault();
            context.Remove(device);
            return Ok(context.SaveChanges());
        }
    }
}
