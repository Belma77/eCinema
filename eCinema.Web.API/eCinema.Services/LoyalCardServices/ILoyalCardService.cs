using eCinema.Services.BaseService;
using eCinema.Services.CRUDservice;
using eCInema.Models.Dtos.Customer;
using eCInema.Models.Dtos.LoyaltyCard;
using eCInema.Models.Entities;
using eCInema.Models.SearchObjects;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.LoyalCardServices
{
    public interface ILoyalCardService:IBaseService<LoyalCardDto, LoyalCardSearchObject>
    {
        LoyalCardDto Insert(LoyalCardInsertDto insert);
        bool Exists(int id);
    }
}
