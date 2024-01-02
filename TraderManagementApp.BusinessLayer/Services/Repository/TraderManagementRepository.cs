using Microsoft.EntityFrameworkCore;
using TraderManagementApp.BusinessLayer.ViewModels;
using TraderManagementApp.DataLayer;
using TraderManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TraderManagementApp.BusinessLayer.Services.Repository
{
    public class TraderManagementRepository : ITraderManagementRepository
    {
        private readonly TraderManagementAppDbContext _dbContext;
        public TraderManagementRepository(TraderManagementAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Trader> CreateTrader(Trader TraderModel)
        {
            try
            {
                var result = await _dbContext.Traders.AddAsync(TraderModel);
                await _dbContext.SaveChangesAsync();
                return TraderModel;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteTraderById(long id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Traders.Single(a => a.TraderId== id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Trader> GetAllTraders()
        {
            try
            {
                var result = _dbContext.Traders.
                OrderByDescending(x => x.TraderId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Trader> GetTraderById(long id)
        {
            try
            {
                return await _dbContext.Traders.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

       
        public async Task<Trader> UpdateTrader(TraderViewModel model)
        {
            var Trader = await _dbContext.Traders.FindAsync(model.TraderId);
            try
            {

                _dbContext.Traders.Update(Trader);
                await _dbContext.SaveChangesAsync();
                return Trader;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}