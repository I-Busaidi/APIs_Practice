﻿using API_Practice1.Models;
using API_Practice1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API_Practice1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("GetAllAdmins")]
        public IActionResult GetAllAdmins()
        {
            try
            {
                var admins = _adminService.GetAllAdmins();
                return Ok(admins);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ById/{id}")]
        public IActionResult GetAdminById(int id)
        {
            try
            {
                var admin = _adminService.GetAdminById(id);
                return Ok(admin);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ByName/{name}")]
        public IActionResult GetAdminsByName(string name)
        {
            try
            {
                var admins = _adminService.GetAdminByName(name);
                return Ok(admins);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddAdmin(string fname, string? lname, string email, string passcode, int? mAdminId)
        {
            try
            {
                int newAdminId = _adminService.AddAdmin(new Admin
                {
                    AdminFname = fname,
                    AdminLname = lname,
                    AdminEmail = email,
                    AdminPasscode = passcode,
                    MasterAdminId = mAdminId
                });
                return Created(string.Empty, newAdminId);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPut("UpdateAdmin/{id}")]
        public IActionResult UpdateAdminInfo(int id, string fname, string? lname, string email, string passcode, int? mAdminId)
        {
            try
            {
                _adminService.UpdateAdminInfo(id, new Admin
                {
                    AdminFname=fname,
                    AdminLname=lname,
                    AdminEmail=email,
                    AdminPasscode=passcode,
                    MasterAdminId=mAdminId
                });
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/EditEmail")]
        public IActionResult UpdateAdminEmail (int id, [FromBody] string email)
        {
            try
            {
                _adminService.UpdateAdminEmail(id, email);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/EditName")]
        public IActionResult UpdateAdminName(int id, [FromBody] string fname, string? lname)
        {
            try
            {
                _adminService.UpdateAdminName(id, fname, lname);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/EditPassword")]
        public IActionResult UpdateAdminPasscode(int id, [FromBody] string passcode)
        {
            try
            {
                _adminService.UpdateAdminPasscode(id, passcode);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/ChangeSupervisor")]
        public IActionResult ChangeAdminSupervisor(int id, [FromBody] int sId)
        {
            try
            {
                _adminService.ChangeAdminSupervisor(id, sId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            try
            {
                _adminService.DeleteAdmin(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
