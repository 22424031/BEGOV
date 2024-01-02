using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Ward.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace UserMapService
{
    public abstract class BaseClient
    {
        private readonly IConfiguration _configuration;
        private string url = "";
        public BaseClient(IConfiguration configuration)
        {
            _configuration = configuration;
            url = _configuration["client:UserMapurl"];
        }
        protected virtual async Task<BaseResponse<bool>> PostAsync<T>(string path,T data)
        {
            BaseResponse<bool> result = new BaseResponse<bool>();
            string dataJson = JsonConvert.SerializeObject(data);
            var content = new StringContent(dataJson);
            HttpClient client = new HttpClient();
            HttpResponseMessage rs = await client.PostAsJsonAsync<T>($"{url}/{path}", data);
            if (rs.IsSuccessStatusCode)
            {
                rs.EnsureSuccessStatusCode();
                result.IsError = false;
                result.Data = true;
                
            }
            else
            {
                result.IsError = true;
                result.ErrorMessage = "Error post data";
                result.Status = 500;
            }
            return result;
        }

    }
}
