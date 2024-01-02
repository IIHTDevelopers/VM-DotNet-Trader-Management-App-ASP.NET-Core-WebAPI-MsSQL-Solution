using TraderManagementApp.BusinessLayer.ViewModels;
using TraderManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TraderManagementApp.BusinessLayer.Interfaces
{
    public interface ITraderManagementService
    {
        List<Trader> GetAllTraders();
        Task<Trader> CreateTrader(Trader trader);
        Task<Trader> GetTraderById(long id);
        Task<bool> DeleteTraderById(long id);
        Task<Trader> UpdateTrader(TraderViewModel model);
    }
}
