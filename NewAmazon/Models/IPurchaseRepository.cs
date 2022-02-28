using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public interface IPurchaseRepository
    {
        IQueryable<BookPurchase> BookPurchases { get; }

        void SavePurchase(BookPurchase purchase);
    }
}
