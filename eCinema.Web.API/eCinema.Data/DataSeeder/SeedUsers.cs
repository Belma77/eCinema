using eCInema.Models.Entities;
using eCInema.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Data.DataSeeder
{
    public class SeedUsersData
    {
        private static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);
            return Convert.ToBase64String(byteArray);
        }

        private static string GenerateHash(string salt, string password)
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
        public static void SeedUsers(ModelBuilder builder)
        {
            var password = "pass123";
            var salt = GenerateSalt();
            var passwordSalt = salt;
            var passwordHash = GenerateHash(salt, password);
            builder.Entity<User>().HasData(
             new User() { Id = 1, FirstName = "Admin", LastName = "Admin", Email = "admin@gmail.com", UserRole = UserRole.Admin, UserName = "Admin", PasswordSalt = salt, PasswordHash = passwordHash, Phone = "041233234" }

            );
            builder.Entity<Customer>().HasData(
               new Customer() { Id = 2, FirstName = "Customer", LastName = "Customer", Email = "customer@gmail.com", UserRole = UserRole.Customer, UserName = "Customer", PasswordSalt = salt, PasswordHash = passwordHash, Phone = "041233234" }
                );
        }

    }
}
