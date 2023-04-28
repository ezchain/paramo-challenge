using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.Request;
using Sat.Recruitment.Api.Response;
using Sat.Recruitment.Domain.Interfaces.Services;
using Sat.Recruitment.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace Sat.Recruitment.Api.Controllers
{


    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
       
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<Result> Create([FromBody] CreateUserRequest request)
        {
            var response = new Result();
            try
            {
            request.IsValid(ModelState);
            var user = _userService.Create(request);
            response.IsSuccess = true;
            response.Body = user;
            response.Message = "User Created";

            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }


        [HttpPost]
        public async Task<Result> UploadFile(UploadFileRequest request)
        {
            var response = new Result();
            try
            {
                _userService.Create(request.Path);
                response.IsSuccess = true;
                response.Message = "Users Created";

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
    
}
