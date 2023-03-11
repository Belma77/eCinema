using eCInema.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Data.DataSeeder
{
    public class SeedMoviesData
    {
        public static void SeedMovies(ModelBuilder builder)
        {

            builder.Entity<Movies>().HasData(
            new Movies()
            {
                Id = 1,
                Title = "Harry Potter and the Philosopher's Stone",
                ReleaseYear = 2001,
                Duration = 120,
                Country = "USA",
                Synopsis = "Harry Potter, an eleven-year-old orphan, discovers that he is a wizard and is invited to study at Hogwarts. Even as he escapes a dreary life and enters a world of magic, he finds trouble awaiting him.",
               // Poster = ReadFile("./Images/starposter.jfif")
            },
            new Movies()
            {
                Id = 2,
                Title = "Shazam! Fury of the Gods",
                ReleaseYear = 2022,
                Duration = 130,
                Country = "USA",
                Synopsis = "The film continues the story of teenage Billy Batson who, upon reciting the magic word \"SHAZAM!\" is transformed into his adult Super Hero alter ego, Shazam..",
               // Poster = ReadFile("./Images/shazam.jpg")
            },

             new Movies()
             {
                 Id = 3,
                 Title = "John Wick: Chapter 4",
                 ReleaseYear = 2023,
                 Duration = 169,
                 Country = "USA",
                 Synopsis = "John Wick uncovers a path to defeating The High Table. But before he can earn his freedom, Wick must face off against a new enemy with powerful alliances across the globe and forces that turn old friends into foes.",
                 //Poster = ReadFile("./Images/johnWick.jfif")
             },
              new Movies()
              {
                  Id = 4,
                  Title = "Creed III",
                  ReleaseYear = 2023,
                  Duration = 116,
                  Country = "USA",
                  Synopsis = "Adonis has been thriving in both his career and family life, but when a childhood friend and former boxing prodigy resurfaces, the face-off is more than just a fight.",
                 // Poster = ReadFile("./Images/cred.jpg")
              },
              new Movies()
              {
                  Id = 5,
                  Title = "Maybe I Do",
                  ReleaseYear = 2023,
                  Duration = 95,
                  Country = "USA",
                  Synopsis = "Michelle and Allen are in a relationship. They decide to invite their parents to finally meet about marriage. Turns out, the parents already know one another well, which leads to some differing opinions about marriage.",
                 // Poster = ReadFile("./Images/ido.jpg")
              },
               new Movies()
               {
                   Id = 6,
                   Title = "The Banshees of Inisherin",
                   ReleaseYear = 2023,
                   Duration = 114,
                   Country = "Great Britain",
                   Synopsis = "Two lifelong friends find themselves at an impasse when one abruptly ends their relationship, with alarming consequences for both of them.",
                  // Poster = ReadFile("./Images/banshees.jpg")
               },
                new Movies()
                {
                    Id = 7,
                    Title = "Babylon",
                    ReleaseYear = 2023,
                    Duration = 189,
                    Country = "USA",
                    Synopsis = "A tale of outsized ambition and outrageous excess, it traces the rise and fall of multiple characters during an era of unbridled decadence and depravity in early Hollywood.",
                   // Poster = ReadFile("./Images/babylon.jpg")
                },
                 new Movies()
                 {
                     Id = 8,
                     Title = "Elvis",
                     ReleaseYear = 2023,
                     Duration = 160,
                     Country = "USA",
                     Synopsis = "The life of American music icon Elvis Presley, from his childhood to becoming a rock and movie star in the 1950s while maintaining a complex relationship with his manager, Colonel Tom Parker.",
                    // Poster = ReadFile("./Images/elvis.jfif")
                 },
                 new Movies()
                 {
                     Id = 9,
                     Title = "Top Gun: Maverick",
                     ReleaseYear = 2023,
                     Duration = 130,
                     Country = "USA",
                     Synopsis = "After thirty years, Maverick is still pushing the envelope as a top naval aviator, but must confront ghosts of his past when he leads TOP GUN's elite graduates on a mission that demands the ultimate sacrifice from those chosen to fly it.",
                    // Poster = ReadFile("./Images/topgun.jfif")
                 },
                  new Movies()
                  {
                      Id = 10,
                      Title = "Avatar: The Way of Water",
                      ReleaseYear = 2022,
                      Duration = 192,
                      Country = "USA",
                      Synopsis = "Jake Sully lives with his newfound family formed on the extrasolar moon Pandora. Once a familiar threat returns to finish what was previously started, Jake must work with Neytiri and the army of the Na'vi race to protect their home.",
                      //Poster = ReadFile("./Images/avatar.jpg")
                  },
                   new Movies()
                   {
                       Id = 11,
                       Title = "Black Panther: Wakanda Forever",
                       ReleaseYear = 2022,
                       Duration = 161,
                       Country = "USA",
                       Synopsis = "The people of Wakanda fight to protect their home from intervening world powers as they mourn the death of King T'Challa.",
                      // Poster = ReadFile("./Images/wakanda.jpg")
                   },
                   
                     new Movies()
                     {
                         Id = 12,
                         Title = "The Fabelmans",
                         ReleaseYear = 2022,
                         Duration = 151,
                         Country = "USA",
                         Synopsis = "Growing up in post-World War II era Arizona, young Sammy Fabelman aspires to become a filmmaker as he reaches adolescence, but soon discovers a shattering family secret and explores how the power of films can help him see the truth.",
                        // Poster = ReadFile("./Images/fabelmans.jpg")
                     },
                      new Movies()
                      {
                          Id = 13,
                          Title = "The Whale",
                          ReleaseYear = 2022,
                          Duration = 117,
                          Country = "USA",
                          Synopsis = "A reclusive, morbidly obese English teacher attempts to reconnect with his estranged teenage daughter.",
                        //  Poster = ReadFile("./Images/whale.jpg")
                      },
                       new Movies()
                       {
                           Id = 14,
                           Title = "Triangle of Sadness",
                           ReleaseYear = 2022,
                           Duration = 147,
                           Country = "Sweden",
                           Synopsis = "A fashion model celebrity couple join an eventful cruise for the super-rich.",
                           //Poster = ReadFile("./Images/triangle.jfif")
                       },
                       new Movies()
                       {
                           Id = 15,
                           Title = "Winnie the Pooh: Blood and Honey",
                           ReleaseYear = 2022,
                           Duration = 84,
                           Country = "USA",
                           Synopsis = "After Christopher Robin abandons them for college, Pooh and Piglet embark on a bloody rampage as they search for a new source of food.",
                           //Poster = ReadFile("./Images/winnie.jpg")
                       },
                       new Movies()
                       {
                           Id = 16,
                           Title = "Cocaine Bear",
                           ReleaseYear = 2022,
                           Duration = 95,
                           Country = "USA",
                           Synopsis = "An oddball group of cops, criminals, tourists and teens converge on a Georgia forest where a huge black bear goes on a murderous rampage after unintentionally ingesting cocaine.",
                           //Poster = ReadFile("./Images/bear.jpg")
                       },
                       new Movies()
                       {
                           Id = 17,
                           Title = "Dogtanian and the Three Muskehounds",
                           ReleaseYear = 2021,
                           Duration = 144,
                           Country = "USA",
                           Synopsis = "Dogtanian is a young swordsman who dreams of joining the legendary Muskehounds. After proving his skills and earning their trust, he and the Muskehounds must defend the King from the evil Cardinal Richelieu's secret plot to seize power.",
                          // Poster = ReadFile("./Images/dogtanian.jpg")
                       },
                       new Movies()
                       {
                           Id = 18,
                           Title = "Ant-Man and the Wasp: Quantumania",
                           ReleaseYear = 2023,
                           Duration = 124,
                           Country = "USA",
                           Synopsis = "Scott Lang and Hope Van Dyne, along with Hank Pym and Janet Van Dyne, explore the Quantum Realm, where they interact with strange creatures and embark on an adventure that goes beyond the limits of what they thought was possible.",
                           //Poster = ReadFile("./Images/antman.jpg")
                       },
                       new Movies()
                       {
                           Id = 19,
                           Title = "What’s Love Got to Do with It?",
                           ReleaseYear = 2022,
                           Duration = 108,
                           Country = "USA",
                           Synopsis = "In London, an award-winning film-maker documents her best friend's journey into an assisted marriage in line with his family's Pakistani heritage. In the process, she challenges her own attitude towards relationships.",
                          // Poster = ReadFile("./Images/love.jpg")
                       },
                       new Movies()
                       {
                           Id = 20,
                           Title = "Magic Mike’s Last Dance",
                           ReleaseYear = 2023,
                           Duration = 112,
                           Country = "USA",
                           Synopsis = "Mike takes to the stage again, following a business deal that went bust, leaving him broke and taking bartender gigs in Florida. Mike heads to London with a wealthy socialite who lures him with an offer he can't refuse.",
                          // Poster = ReadFile("./Images/mike.jpg")
                       },
                       new Movies()
                       {
                           Id = 21,
                           Title = "Little Nicholas’ Treasure",
                           ReleaseYear = 2021,
                           Duration = 103,
                           Country = "France",
                           Synopsis = "What Nicholas (9) loves most is playing with his gang of middle school pals, The Invincibles. Adorable, yet mischievous, they have all sorts of adventures together and life could not be funnier. So when his dad gets promoted and announces that the family is relocating to the South of France, his world falls apart. Little Nicholas cannot live without his friends. But the pack has a plan to prevent this terrible relocation: a treasure hunt.",
                           //Poster = ReadFile("./Images/nicholas.jpg")
                       },
                       new Movies()
                       {
                           Id = 22,
                           Title = "Asterix & Obelix: The Middle Kingdom",
                           ReleaseYear = 2021,
                           Duration = 103,
                           Country = "France",
                           Synopsis = "The only daughter of the Chinese emperor Han Xuandi, escapes from a strict prince and seeks help from the Gauls and the two brave warriors Asterix and Obelix.",
                          // Poster = ReadFile("./Images/asterix.jfif")
                       },
                       new Movies()
                       {
                           Id = 23,
                           Title = "A Man Called Otto",
                           ReleaseYear = 2021,
                           Duration = 126,
                           Country = "USA",
                           Synopsis = "Otto is a grump who's given up on life following the loss of his wife and wants to end it all. When a young family moves in nearby, he meets his match in quick-witted Marisol, leading to a friendship that will turn his world around.",
                           //Poster = ReadFile("./Images/otto.jfif")
                       }

           );
        }
            public static byte[] ReadFile(string sPath)
            {
                //Initialize byte array with a null value initially.
                byte[] data = null;

                //Use FileInfo object to get file size.
                FileInfo fInfo = new FileInfo(sPath);
                long numBytes = fInfo.Length;

                //Open FileStream to read file
                FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

                //Use BinaryReader to read file stream into byte array.
                BinaryReader br = new BinaryReader(fStream);

                //When you use BinaryReader, you need to supply number of bytes 
                //to read from file.
                //In this case we want to read entire file. 
                //So supplying total number of bytes.
                data = br.ReadBytes((int)numBytes);

                return data;
            }
        }
}
