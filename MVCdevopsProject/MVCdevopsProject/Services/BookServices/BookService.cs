//using Microsoft.Extensions.Configuration;
//using MVCdevopsProject.DTOs;
//using MVCdevopsProject.Enums;
//using MVCdevopsProject.Services.BookServices;
//using MVCdevopsProject.Services.GeneralServices;
//using Newtonsoft.Json;


//namespace MVCdevopsProject.Services.BookServices
//{
//    public class BookService : IBookService
//    {
//        private readonly IBaseService _baseService;
//        //private readonly IConfiguration _configuration;

//        //public BookService(IBaseService baseService, IConfiguration configuration)
//        //{
//        //    _baseService = baseService;
//        //    _configuration = configuration;
//        //}
//        public BookService(IBaseService baseService)
//        {
//            _baseService = baseService;

//        }
//        public async Task<List<BookDTO>> GetBooks()
//        {
//            var RequestDTO = new RequestDTO();
//            RequestDTO.apiMethods = ApiMethods.get;
//            // RequestDTO.URL = _configuration["ApiBaseUrl"] + "WeatherForecast";
//            RequestDTO.URL = "http://localhost:7156/WeatherForecast";
//            var response = await _baseService.SendAsync(RequestDTO);
//            return JsonConvert.DeserializeObject<List<BookDTO>>(response.Result.ToString());
//        }


//        //public async Task<List<BookDTO>> GetBooks()
//        //{
//        //    var RequestDTO = new RequestDTO();
//        //    RequestDTO.apiMethods = ApiMethods.get;
//        //    //RequestDTO.URL = _configuration["ApiBaseUrl"] +"WeatherForecast";
//        //    RequestDTO.URL = "http://localhost:7156/WeatherForecast";
//        //    var response = await _baseService.SendAsync(RequestDTO);
//        // //   response.IsSuccess
//        //    return JsonConvert.DeserializeObject<List<BookDTO>>(response.Result.ToString());
//        //}
//    }

//}
using Microsoft.Extensions.Configuration;
using MVCdevopsProject.DTOs;
using MVCdevopsProject.Enums;
using MVCdevopsProject.Services.GeneralServices;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCdevopsProject.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly IBaseService _baseService;

        public BookService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<List<BookDTO>> GetBooks()
        {
            var requestDTO = new RequestDTO
            {
                apiMethods = ApiMethods.get,
                URL = "http://localhost:7156/WeatherForecast"
            };

            var response = await _baseService.SendAsync(requestDTO);

            if (response.IsSuccess && response.Result != null)
            {
                // Check if Result is a JSON-formatted string and can be deserialized
                return JsonConvert.DeserializeObject<List<BookDTO>>(response.Result.ToString());
            }

            // If Result is null or the response is unsuccessful, return an empty list
            return new List<BookDTO>();
        }
    }
}



