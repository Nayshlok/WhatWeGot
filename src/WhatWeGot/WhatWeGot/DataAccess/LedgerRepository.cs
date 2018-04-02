using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatWeGot.Infrastructure;
using WhatWeGot.Model;

namespace WhatWeGot.DataAccess
{
    public interface ILedgerRepository
    {
        Task<IEnumerable<FinanceItem>> GetMonthlyItems(int month);
        Task<IEnumerable<FinanceItem>> GetLastMonth();
        Task SaveFinanceItem(FinanceItem item);
    }

    public class LedgerRepository : ILedgerRepository
    {
        private readonly WhatWeGotContext _context;
        private readonly TimeProvider _time;

        public LedgerRepository(WhatWeGotContext context)
        {
            _context = context;
            _time = TimeProvider.Current;
        }

        public async Task<IEnumerable<FinanceItem>> GetMonthlyItems(int month)
        {
            var items = await _context.Items.Include(x => x.Category).Where(i => i.EventDate.Month == month).ToListAsync();
            return items;
        }

        public async Task<IEnumerable<FinanceItem>> GetLastMonth()
        {
            var lastMonth = _time.Now.AddMonths(-1);
            var items = await _context.Items.Include(x => x.Category).Where(i => i.EventDate.CompareTo(lastMonth) > 0).ToListAsync();
            return items;
        }

        public async Task SaveFinanceItem(FinanceItem item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }
    }
}
