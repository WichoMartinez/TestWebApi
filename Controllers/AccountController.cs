using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Models;
using StoreApi.Repository;

namespace StoreApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private IAccountRepository _repository;
        

        public AccountController(IAccountRepository accountRepository)
        {
            _repository = accountRepository;
        }
        // GET: api/Getplaces/5
        [HttpGet("{Account}")]
        public IActionResult SetAccount(Account account)
        {
            return Ok(_repository.CreateAccount(account));
        }

        
    }
}