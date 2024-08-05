
using Microsoft.AspNetCore.Components.Web;
using Bl.Interfaces;
using Dal;
using Dto.models;
using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dal.Models;
using Bl;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettlementController : ControllerBase
    {
        public ISettlement _SettlementService { get; set; }
        public SettlementController(ISettlement SettlementService)
        {
            this._SettlementService = SettlementService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Settlements>>> ReadAllAsync()
        {
           
            try
            {
                List<Settlements> Settlement = await _SettlementService.ReadAllAsync();
                if (Settlement.Count == 0) { return NotFound("Settlement  Not exsist "); }
                return Settlement;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

       
        [HttpPost]
        public async Task<ActionResult<Settlements>> CreateAsync([FromBody] Settlements Settlement)
        {
            try
            {
                if (Settlement == null)
                    return BadRequest("Invalid body request!");
                Settlements createdSettlement = await _SettlementService.CreateAsync(Settlement);
                return Ok(createdSettlement);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
           
        }

        [HttpPut]
        public async Task<ActionResult<Settlement>> UpdateAsync([FromBody] Settlements Settlement)
        {
            try
            {
                bool UpdateSettlement = await _SettlementService.UpdateAsync(Settlement);
                if (UpdateSettlement)
                    return Ok(true);
                else
                    return NotFound("Settlement not found!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
           
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync([FromQuery(Name = "id")] int id)
        {
            try
            {
                if (id < 0) return BadRequest("Invalid id!");
                bool deleted = await _SettlementService.DeleteAsync(id);
                if (deleted)
                    return true;
                else
                    return NotFound("Settlement not found!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }
    }
}
