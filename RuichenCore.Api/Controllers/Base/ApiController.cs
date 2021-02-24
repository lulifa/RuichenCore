using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuichenCore.Common;

namespace RuichenCore.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public abstract class ApiController : ControllerBase
    {
        protected ResponseResult JsonCore()
        {
            return new ResponseResult();
        }

        protected ResponseResult JsonCore(bool success)
        {
            return new ResponseResult(success);
        }

        protected ResponseResult JsonCore(bool success,string msg)
        {
            return new ResponseResult(success, msg);
        }

        protected ResponseResult JsonCore(bool success,object data)
        {
            return new ResponseResult(success, data);
        }

        protected ResponseResult JsonCore(bool success,string msg,object data)
        {
            return new ResponseResult(success, msg, data);
        }
    }
}
