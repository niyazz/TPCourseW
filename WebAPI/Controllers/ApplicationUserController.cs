﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using WebAPI.Models;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public ApplicationUserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            var applicationUser = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}