//using MVCdevopsProject.DTOs;
//using MVCdevopsProject.Enums;
//using MVCdevopsProject.Services.GeneralServices;
//using System.Text.Json;
//using System.Text.Json.Serialization;

//namespace MVCdevopsProject.Services.BookServices
//{
//    public class BookService: IBookService
//    {
//        public readonly IBaseService _baseService;

//        public BookService(IBaseService baseService)
//        {
//            _baseService = baseService;
//        }
//       public async Task<List<BookDTO>> GetBooks()
//        {
//            var RequestDTO = new RequestDTO();
//            RequestDTO.apiMethods = ApiMethods.get;
//            RequestDTO.URL = "http://localhost:5083/WeatherForecast";
//            var response = await _baseService.SendAsync(RequestDTO);
//            return JsonSerializer.Deserialize<List<BookDTO>>(response.Result.ToString());
//        }
//    }

//}
using MVCdevopsProject.DTOs;
using MVCdevopsProject.Enums;
using MVCdevopsProject.Services.GeneralServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MVCdevopsProject.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly IBaseService _baseService;
        private readonly IConfiguration _configuration;

        public BookService(IBaseService baseService,IConfiguration configuration)
        {
            _baseService = baseService;
            _configuration = configuration;
        }

        public async Task<List<BookDTO>> GetBooks()
        {
            var requestDTO = new RequestDTO
            {
                apiMethods = ApiMethods.get,
                URL = _configuration["ApiBaseUrl"]+ "WeatherForecast"
            };

            var response = await _baseService.SendAsync(requestDTO);

            if (response.Result is not null)
            {
                return JsonSerializer.Deserialize<List<BookDTO>>(response.Result.ToString()) ?? new List<BookDTO>();
            }

            return new List<BookDTO>(); // Return an empty list if the result is null
        }
    }
}
