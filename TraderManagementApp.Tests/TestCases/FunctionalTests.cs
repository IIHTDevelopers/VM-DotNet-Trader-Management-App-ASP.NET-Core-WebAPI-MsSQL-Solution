
using Moq;
using TraderManagementApp.BusinessLayer.Services;
using TraderManagementApp.BusinessLayer.Services.Repository;
using TraderManagementApp.BusinessLayer.ViewModels;
using TraderManagementApp.DataLayer;
using TraderManagementApp.Entities;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using TraderManagementApp.BusinessLayer.Interfaces;

namespace TraderManagementApp.Tests.TestCases
{
     public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly TraderManagementAppDbContext _dbContext;

        private readonly ITraderManagementService  _traderService;
        public readonly Mock<ITraderManagementRepository> traderservice= new Mock<ITraderManagementRepository >();

        private readonly Trader _trader;
        private readonly TraderViewModel _traderViewModel;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_Create_Trader()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                traderservice.Setup(repos => repos.CreateTrader(_trader)).ReturnsAsync(_trader);
                var result = await  _traderService.CreateTrader(_trader);
                //Assertion
                if (result != null)
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
        public async Task<bool> Testfor_Update_Trader()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
           
            //Action
            try
            {
                traderservice.Setup(repos => repos.UpdateTrader(_traderViewModel)).ReturnsAsync(_trader); 
                var result = await  _traderService.UpdateTrader(_traderViewModel);
                if (result != null)
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
        public async Task<bool> Testfor_GetTraderById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                traderservice.Setup(repos => repos.GetTraderById(id)).ReturnsAsync(_trader);
                var result = await  _traderService.GetTraderById(id);
                //Assertion
                if (result != null)
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
        public async Task<bool> Testfor_DeleteTraderById()
        {
            //Arrange
            var res = false;
            int id = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                traderservice.Setup(repos => repos.DeleteTraderById(id)).ReturnsAsync(response);
                var result = await  _traderService.DeleteTraderById(id);
                //Assertion
                if (result != null)
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