using SamplePhonebookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Initializes
{
    public class InitializeCategory
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category 
                    {
                        Name = "Родственики"
                    },
                    new Category
                    {
                        Name = "Друзья",                        
                    }
                ); ; ;
                context.SaveChanges();
            }
        }
    }
}
