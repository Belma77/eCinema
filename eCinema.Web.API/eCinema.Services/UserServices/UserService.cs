using AutoMapper;
using eCinema.Data;
using eCinema.Services.CRUDservice;
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

namespace eCinema.Services.UserServices
{
    public class UserService:BaseCRUDService<UserDto, User, UserSearchObject, UserInsertDto, UserUpdateDto>, IUserService
    {
        public UserService(eCinemaContext context, IMapper mapper):base(context,mapper)
        {

        }

        public UserDto Login(UserLoginDto login)
        {
            var entity = _context.Users.FirstOrDefault(x => x.UserName==login.UserName);

            if (entity == null)
                throw new NotFoundException("User not found");

            var hash = GenerateHash(entity.PasswordSalt, login.Password);

            if (hash != entity.PasswordHash)
                return null;

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
            var salt = GenerateSalt();
            entity.PasswordSalt = salt;
            entity.PasswordHash = GenerateHash(salt, insert.Password);
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
            var salt = GenerateSalt();
            entity.PasswordSalt = salt;
            entity.PasswordHash = GenerateHash(salt, insert.Password);
            _context.Users.Add(entity); 
            _context.SaveChanges();

            return _mapper.Map<UserDto>(entity);


        }

        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);
            return Convert.ToBase64String(byteArray);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
    }
}
