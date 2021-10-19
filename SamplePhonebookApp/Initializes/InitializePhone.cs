using SamplePhonebookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Initializes
{
    public class InitializePhone
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "Алиев Вали",
                        Telephone="+79003002040",
                        Address = "Душанбе",
                        CategoryId = 1
                    },
                    new Phone
                    {
                        Name = "Закыров Ринат",
                        Telephone="+78003002020",
                        Address = "Казань",
                        CategoryId = 2
                    }                  
                );
                context.SaveChanges();
            }
        }
    }
}
