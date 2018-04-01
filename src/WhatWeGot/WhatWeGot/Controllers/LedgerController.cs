using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatWeGot.DataAccess;
using WhatWeGot.Model;

namespace WhatWeGot.Controllers
{
    public class LedgerController : Controller
    {
        private readonly LedgerRepository _repo;

        protected LedgerController(LedgerRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<FinanceItem>> GetLastMonth()
        {
            return await _repo.getLastMonth();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<FinanceItem>> GetSpecificMonth(int month)
        {
            return await _repo.getMonthlyItems(month);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
