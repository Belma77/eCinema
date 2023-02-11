using AutoMapper;
using eCinema.Data;
using eCinema.Services.CRUDservice;
using eCinema.Services.CustomerServices;
using eCInema.Models.Dtos.Customer;
using eCInema.Models.Dtos.LoyaltyCard;
using eCInema.Models.Entities;
using eCInema.Models.Exceptions;
using eCInema.Models.SearchObjects;
using Microsoft.Identity.Client;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Services.LoyalCardServices
{
    public class LoyalCardService:BaseService<LoyalCardDto, LoyalCard, LoyalCardSearchObject>, ILoyalCardService
    {
        ICustomerService _customerService;
        public LoyalCardService(eCinemaContext context, IMapper mapper, ICustomerService customerService) :base(context,mapper)
        {
            _customerService = customerService;
        }

        public LoyalCardDto Insert(LoyalCardInsertDto insert)
        {

            var customer = _context.Customers.Where(x => x.Id == insert.CustomerId);
            var loyalCustomers = _context.LoyalCards.FirstOrDefault(x => x.CustomerId == insert.CustomerId);

            if (loyalCustomers != null)
                throw new BadRequestException("Customer already added to loyalty club");

            if (customer == null)
                throw new NotFoundException("Customer not found");

            insert.CustomerType = eCInema.Models.Enums.CustomerTypeEnum.Premium;

            var customerUpdate = new UpdateCustomerDto();
            customerUpdate.FirstName = insert.FirstName;
            customerUpdate.LastName = insert.LastName;
            customerUpdate.City = insert.City;
            customerUpdate.Email = insert.Email;
            customerUpdate.Phone = insert.Phone;
            customerUpdate.IdentificationNumber=insert.IdentificationNumber;

            var update=_customerService.Update(insert.CustomerId, customerUpdate);

            if(update!=null)
            {
                var loyalCard = new LoyalCard();
                loyalCard.CustomerId = update.Id;
                loyalCard.price = 23.90;
                _context.LoyalCards.Add(loyalCard);
                _context.SaveChanges();
                return _mapper.Map<LoyalCardDto>(loyalCard);
            }

            throw new BadRequestException("Something went wrong");
        }
        public List<SessionLineItemOptions> CreatesessionLineItemOptions(LoyalCardInsertDto card)
        {
            var LineItems = new List<SessionLineItemOptions>();

                var option = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long?)(23.90 * 100),
                        Currency = "bam",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Loyal card",
                        },
                    },
                    Quantity = 1,
                };
                LineItems.Add(option);
            return LineItems;
        }
    }
}
