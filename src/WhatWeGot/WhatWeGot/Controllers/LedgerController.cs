using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatWeGot.DataAccess;
using WhatWeGot.Model;

namespace WhatWeGot.Controllers
{
    [Route("api/[controller]")]
    public class LedgerController : Controller
    {
        private readonly ILedgerRepository _repo;

        public LedgerController(ILedgerRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<FinanceItem>> GetLastMonth()
        {
            return await _repo.GetLastMonth();
        }

        // GET api/values/5
        [HttpGet("{month}")]
        public async Task<IEnumerable<FinanceItem>> GetSpecificMonth(int month)
        {
            return await _repo.GetMonthlyItems(month);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]FinanceItem value)
        {
            await _repo.SaveFinanceItem(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
