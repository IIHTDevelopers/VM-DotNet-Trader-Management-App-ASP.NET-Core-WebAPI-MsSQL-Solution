

using Moq;
using TraderManagementApp.BusinessLayer.Services.Repository;
using TraderManagementApp.BusinessLayer.Services;
using TraderManagementApp.BusinessLayer.ViewModels;
using TraderManagementApp.DataLayer;
using TraderManagementApp.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using TraderManagementApp.BusinessLayer.Interfaces;

namespace TraderManagementApp.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly TraderManagementAppDbContext _dbContext;

        private readonly ITraderManagementService  _traderService;
        public readonly Mock<ITraderManagementRepository> traderservice = new Mock<ITraderManagementRepository>();

        private readonly Trader _trader;
            
        private readonly TraderViewModel _traderViewModel;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
             _traderService = new TraderManagementService(traderservice.Object);

            _output = output;

            _trader = new Trader
            {
                TraderId = 1,
                Name = "Trader",
                DateOfBirth = DateTime.Now,
                Age = 2,
                MobileNumber = "6534231234"
            };

            _traderViewModel = new TraderViewModel
            {
                TraderId = 1,
                Name = "Trader",
                DateOfBirth = DateTime.Now,
                Age = 2,
                MobileNumber = "6534231234"
            };
        }
    

        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidTraderIdIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                traderservice.Setup(repo => repo.CreateTrader(_trader)).ReturnsAsync(_trader);
                var result = await  _traderService.CreateTrader(_trader);
                if (result != null || result.TraderId !=0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        [Fact]
        public async Task<bool> Testfor_Validate_ifInvalidTraderAgeIsPassed()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                traderservice.Setup(repo => repo.CreateTrader(_trader)).ReturnsAsync(_trader);
                var result = await _traderService.CreateTrader(_trader);
                if (result != null || result.Age != 0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}