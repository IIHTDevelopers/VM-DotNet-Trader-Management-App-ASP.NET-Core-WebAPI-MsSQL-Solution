using TraderManagementApp.BusinessLayer.Interfaces;
using TraderManagementApp.BusinessLayer.Services.Repository;
using TraderManagementApp.BusinessLayer.ViewModels;
using TraderManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TraderManagementApp.BusinessLayer.Services
{
    public class TraderManagementService : ITraderManagementService
    {
        private readonly ITraderManagementRepository _repo;

        public TraderManagementService(ITraderManagementRepository repo)
        {
            _repo = repo;
        }

        public async Task<Trader> CreateTrader(Trader employeeTrader)
        {
            return await _repo.CreateTrader(employeeTrader);
        }

        public async Task<bool> DeleteTraderById(long id)
        {
            return await _repo.DeleteTraderById(id);
        }

        public List<Trader> GetAllTraders()
        {
            return  _repo.GetAllTraders();
        }

        public async Task<Trader> GetTraderById(long id)
        {
            return await _repo.GetTraderById(id);
        }

        public async Task<Trader> UpdateTrader(TraderViewModel model)
        {
           return await _repo.UpdateTrader(model);
        }
    }
}
