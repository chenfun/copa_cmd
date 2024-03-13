using CopaCmd.ViewModel.Sensor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static CopaCmd.Services.SensorService;

namespace CopaCmd.Services
{
    public class SensorService
    {
        public SensorService()
        {
        }

        /// <summary>
        /// 取得計數器(Counter)的值
        /// </summary>
        /// <returns></returns>
        public async Task<SensorValueResponse> GetSensorsValues()
        {
            //網址使用https，所以要忽略憑證錯誤，都可以執行
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            // 設定 HttpClient 超時時間為 10 秒
            HttpClient client = new HttpClient(handler);
            client.Timeout = TimeSpan.FromSeconds(10);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Helpers.ConfigHelper.GetSettings.TapSensorUrl);

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SensorValueResponse>(jsonString);
            }
            else
            {
                Console.WriteLine($"取得計數器資料發生錯誤：{response.StatusCode}");
                return null;
            }
        }
    }
}