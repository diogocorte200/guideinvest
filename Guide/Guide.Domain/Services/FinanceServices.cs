using Guide.Domain.Domain;
using Guide.Domain.Interfaces;
using Guide.Entity.Entity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Guide.Domain.Services
{
    public class FinanceServices : IFinanceService
    {
        private readonly ILogger<FinanceServices> _logger;
        private readonly HttpClient _httpClient;
        private readonly GuideService<GuideModel, FinanceEntity> _guideService;
        public FinanceServices(ILogger<FinanceServices> logger, HttpClient httpClient, GuideService<GuideModel, FinanceEntity> guideService)
        {
            _logger = logger;
            _httpClient = httpClient;
            _guideService = guideService;
        }

        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
            return dtDateTime;
        }
        public static DateTime ToDateTime(double unixTimeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp).ToLocalTime();
        }

        public double ToUnixTimestamp(DateTime datetime)
        {
            return (datetime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        public IEnumerable<FinanceEntity> GetFinances()
        {
            var searchDate = DateTime.Now.AddMonths(-1);
            return _guideService.GetFinances(Convert.ToInt32(ToUnixTimestamp(searchDate)));
        }

        public async Task<Finance> InsertFinances()
        {
            try
            {
                var strUri = $"https://query2.finance.yahoo.com/v8/finance/chart/PETR4.SA";

                var result = await _httpClient.GetAsync(strUri);


                if (result.IsSuccessStatusCode)
                {
                    var resultJson = await result.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Finance>(resultJson);
                    //Grava no banco//
                    _guideService.ProcessFinance(data);

                    return data;
                }
                else
                {
                    _logger.LogInformation($"Error :{result.StatusCode} Msg:{result.Content}");
                    return default;
                }

            }
            catch (Exception error)
            {
                _logger.LogError(error, $"Exc {error.Message}");
                throw;
            }
        }
    }
}
