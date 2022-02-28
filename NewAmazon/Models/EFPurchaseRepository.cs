using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext context;

        public EFPurchaseRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<BookPurchase> BookPurchases => context.BookPurchases.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SavePurchase(BookPurchase purchase)
        {
            context.AttachRange(purchase.Lines.Select(x => x.Book));

            if (purchase.PurchaseId == 0)
            {
                context.BookPurchases.Add(purchase);
            }

            context.SaveChanges();
        }
    }
}
