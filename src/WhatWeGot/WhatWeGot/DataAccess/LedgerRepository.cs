using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatWeGot.Infrastructure;
using WhatWeGot.Model;

namespace WhatWeGot.DataAccess
{
    public class LedgerRepository
    {
        private readonly WhatWeGotContext _context;
        private readonly TimeProvider _time;

        public LedgerRepository(WhatWeGotContext context)
        {
            _context = context;
            _time = TimeProvider.Current;
        }

        public async Task<IEnumerable<FinanceItem>> getMonthlyItems(int month)
        {
            var items = await _context.Items.Where(i => i.EventDate.Month == month).ToListAsync();
            return items;
        }

        public async Task<IEnumerable<FinanceItem>> getLastMonth()
        {
            var lastMonth = _time.Now.AddMonths(-1);
            var items = await _context.Items.Where(i => i.EventDate.CompareTo(lastMonth) > 0).ToListAsync();
            return items;
        }
    }
}
