using Microsoft.EntityFrameworkCore;
using NLog;
using SamplePhonebookApp.Models;
using SamplePhonebookApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Repository
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger _logger;

        public PhoneRepository(ApplicationContext context )
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }

        public async Task<IList<Phone>> GetListOfPhones()
        {
            try
            {
                _logger.Info("Get List Of Phones is Completed ");
                return await _context.Phones.ToListAsync();
            }
            catch (Exception exp)
            {
                _logger.Error("Get List Of Phones is Failed:" + exp.Message);
                return null;
            }
        }

        public async Task CreatePhone(Phone phone)
        {
            try
            {
                _context.Phones.Add(phone);
                await _context.SaveChangesAsync();
                _logger.Info("Create the new Phone is Completed ");
            }
            catch (Exception exp)
            {
                _logger.Error("Create the new Phone is Failed:" + exp.Message);
            }
        }

        public async Task EditPhone(Phone phone)
        {
            try
            {
                _context.Phones.Update(phone);
                await _context.SaveChangesAsync();
                _logger.Info("Update the Phone is Completed ");
            }
            catch (Exception exp)
            {
                _logger.Error("Update the Phone is Failed:" + exp.Message);
            }
        }


        public async Task<Phone> GetPhoneByID(int? id)
        {
            try
            {
                Phone phone = await _context.Phones.FirstOrDefaultAsync(p => p.Id == id);
                _logger.Info("GetPhoneByID is Completed ");
                return phone;
            }
            catch (Exception exp)
            {
                _logger.Error("GetPhoneByID  is Failed:" + exp.Message);
                return null;
            }
        }

        public async Task Delete(int? id)
        {
            try
            {
                Phone phone = await _context.Phones.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null)
                {
                    _context.Phones.Remove(phone);
                    await _context.SaveChangesAsync();
                    _logger.Info("Delete Phone is Completed ");
                }

            }
            catch (Exception exp)
            {
                _logger.Error("Delete phone  is Failed:" + exp.Message);
            }
        }

        public async Task<IList<PhoneAndCategoryDto>> GetListOfPhonesWithCategoryName()
        {
            try
            {
                var sql = (from phone in _context.Phones
                           join category in _context.Categories on phone.CategoryId equals category.Id
                           select new PhoneAndCategoryDto
                           {
                               Id= phone.Id,                               
                               Name = phone.Name,
                               Address= phone.Address,
                               CategoryName= category.Name                              
                           }).ToListAsync();
                _logger.Info("Get List Of phones with CategoryName is Completed ");
                return await sql;
            }
            catch (Exception exp)
            {
                _logger.Error("Get List Of phones with CategoryName is Failed:" + exp.Message);
                return null;
            }
        }

        public IQueryable<Phone> GetListOfPhonesWithCategory()
        {
            try
            {
                IQueryable<Phone> phones = _context.Phones.Include(x => x.Category);
                _logger.Info("Get List Of phones with Category is Completed ");
                return phones;
            }
            catch (Exception exp)
            {
                _logger.Error("Get List Of phones with Category is Failed:" + exp.Message);
                return null;
            }
        }

    }
}