using AutoMapper;
using eCinema.Data;
using eCinema.Services.CRUDservice;
using eCinema.Services.Helpers;
using eCInema.Models.Dtos.Users;
using eCInema.Models.Entities;
using eCInema.Models.Exceptions;
using eCInema.Models.SearchObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eCinema.Services.UserServices
{
    public class UserService:BaseCRUDService<UserDto, User, UserSearchObject, UserInsertDto, UserUpdateDto>, IUserService
    {
        public UserService(eCinemaContext context, IMapper mapper):base(context,mapper)
        {

        }

        public UserDto Login(UserLoginDto login)
        {
            var entity = _context.Users.Where(u => u.UserName == login.UserName).FirstOrDefault();

            if (entity == null)
                throw new NotFoundException("User not found");

            var hash = PasswordHelper.GenerateHash(entity.PasswordSalt, login.Password);

            if (hash != entity.PasswordHash)
                throw new NotFoundException("Password not correct!");

            return _mapper.Map<UserDto>(entity);
        }

        public override IQueryable<User> AddFilter(IQueryable<User> query, UserSearchObject search = null)
        {
            if(!String.IsNullOrEmpty(search.Name))
                query = query.Where(x => x.UserName.ToLower().Contains(search.Name.ToLower()));
            return query;
        }

        public override void BeforeInsert(UserInsertDto insert, User? entity)
        {
            var salt = PasswordHelper.GenerateSalt();
            entity.PasswordSalt = salt;
            entity.PasswordHash = PasswordHelper.GenerateHash(salt, insert.Password);
            if (entity.UserRole == eCInema.Models.Enums.UserRole.Customer)
            {
                var customer = _mapper.Map<Customer>(entity);
                customer.CustomerType = eCInema.Models.Enums.CustomerTypeEnum.Regular;
            }
            base.BeforeInsert(insert, entity);
        }

        public override UserDto Insert(UserInsertDto insert)
        {
            var entity = _mapper.Map<User>(insert);
            var salt = PasswordHelper.GenerateSalt();
            entity.PasswordSalt = salt;
            entity.PasswordHash = PasswordHelper.GenerateHash(salt, insert.Password);
            _context.Users.Add(entity); 
            _context.SaveChanges();

            return _mapper.Map<UserDto>(entity);
        }
    }
}
