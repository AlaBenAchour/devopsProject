
using MVCdevopsProject.DTOs;
using MVCdevopsProject.Enums;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace MVCdevopsProject.Services.GeneralServices {

    public class BaseService:IBaseService {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService (IHttpClientFactory httpClientFactory){

            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDTO> SendAsync(RequestDTO request)
        {
            var client= _httpClientFactory.CreateClient("DevopsApi");
            HttpRequestMessage message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri=new Uri(request.URL);
            if(request.Data!=null){
                var jsonData = JsonSerializer.Serialize(request.Data);
                message.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            }
            switch(request.apiMethods){
                case ApiMethods.get:message.Method=HttpMethod.Get;break;
                case ApiMethods.post:message.Method=HttpMethod.Post;break;
                case ApiMethods.put:message.Method=HttpMethod.Put;break;
                case ApiMethods.delete:message.Method=HttpMethod.Delete;break;
                default:message.Method=HttpMethod.Get;break;
            }

            try
            {
                var endResult = new ResponseDTO();
                var response = await client.SendAsync(message);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<object>(content);
                    endResult.IsSuccess=true;
                    endResult.Message = "ok";
                    endResult.Result = result;
                    return endResult;
                }
              else
                {
                    endResult.IsSuccess=false;
                    endResult.Message = "Failed";
                    return endResult;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);

                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}