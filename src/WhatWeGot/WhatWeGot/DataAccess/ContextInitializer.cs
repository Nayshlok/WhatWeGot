using System;
using System.Linq;
using WhatWeGot.Model;

namespace WhatWeGot.DataAccess
{
    public static class ContextInitializer
    {
        public static void Initialize(WhatWeGotContext context)
        {
            if (context.Items.Any() || context.Categories.Any())
            {
                return;   // DB has been seeded
            }

            var category = new Category { CategoryDescription = "Test", CategoryName = "TestCat" };

            var items = new FinanceItem{ Category=category, Amount=123, EventDate=DateTime.Now.AddDays(-5), ItemName="WalmartTest"};

            context.Add(items);
            context.SaveChanges();

        }
    }
}
