﻿using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProesBack.Domain.Entities;
using ProesBack.Infrastructure.Data.Common;
using ProesBack.Interfaces;
using System.Text;

namespace ProesBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginViewModelService _loginViewModelService;

        public LoginController(ILoginViewModelService loginViewModelService)
        {
            _loginViewModelService = loginViewModelService;
        }

        [HttpGet("Login")]
        public async Task<ActionResult<dynamic>> Login(string username, string password)
        {
            try
            {
                var user = _loginViewModelService.GetLogin(username, password) ;
                var token = _loginViewModelService.Authenticate(user);

                _loginViewModelService.UpdateLogin(new Login{
                    Id = user.Id,
                    Username = user.Username,
                    Password = user.Password,
                    Token = token,
                    TokenExpiration = 30,
                    UserType = user.UserType
                });

                
                if (token == null)
                    return BadRequest("Username or password is incorrect");

                user.Password = "";
                return user;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> Refresh([FromBody]string token)
        {
            try
            {
                var refreshToken = _loginViewModelService.RefreshJSONWebToken(token);
                return Ok(new { token = refreshToken });
            }

            catch (SecurityTokenException ex)
            {
                return BadRequest("Invalid token");
            }
            
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] Login login)
        {
            try
            {
                if (string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
                    return BadRequest("Username or password is empty");

                var user = _loginViewModelService.GetLogin(login.Username, login.Password);
                if(user ==null)
                {
                    _loginViewModelService.InsertLogin(new Login
                    {
                        Username = login.Username,
                        Password = login.Password,
                        TokenExpiration = 3,
                        Token = Encoding.ASCII.GetBytes(Settings.GetKey()).ToString()
                });

                    return CreatedAtAction(null, null);
                }
            }
            catch (Exception ex)
            {
                StatusCode(500, ex.Message);
                throw;
            }
            return BadRequest(login.Username+ " already exists");
            
        }
    }
}
