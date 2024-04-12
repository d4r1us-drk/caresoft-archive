﻿using caresoft_core.Dto;
using caresoft_core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace caresoft_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresoController : ControllerBase
    {
        private readonly IIngresoService _ingresoService;

        public IngresoController(IIngresoService ingresoService)
        {
            _ingresoService = ingresoService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddIngreso([FromBody] IngresoDto ingresoDto)
        {
            if (ingresoDto == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var result = await _ingresoService.AddIngresoAsync(ingresoDto);
                if (result == 1)
                    return Ok("Ingreso added successfully.");
                else
                    return BadRequest("Failed to add ingreso.");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateIngreso(uint id, [FromBody] IngresoDto ingresoDto)
        {
            if (ingresoDto == null || id != ingresoDto.IdIngreso)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var result = await _ingresoService.UpdateIngresoAsync(ingresoDto);
                if (result == 1)
                    return Ok("Ingreso updated successfully.");
                else
                    return NotFound("Ingreso not found.");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteIngreso(uint id)
        {
            try
            {
                var result = await _ingresoService.DeleteIngresoAsync(id);
                if (result == 1)
                    return Ok("Ingreso deleted successfully.");
                else
                    return NotFound("Ingreso not found.");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<IngresoDto>>> GetIngresos()
        {
            try
            {
                var ingresos = await _ingresoService.GetIngresosAsync();
                return Ok(ingresos);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<IngresoDto>> GetIngresoById(uint id)
        {
            try
            {
                var ingreso = await _ingresoService.GetIngresoByIdAsync(id);
                if (ingreso != null)
                    return Ok(ingreso);
                else
                    return NotFound("Ingreso not found.");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
