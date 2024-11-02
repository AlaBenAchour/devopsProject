using Microsoft.Extensions.Configuration;
using MVCdevopsProject.DTOs;
using MVCdevopsProject.Enums;
using MVCdevopsProject.Services.GeneralServices;
using Newtonsoft.Json;


namespace MVCdevopsProject.Services.BookServices
{
    public class BookService : IBookService
    {
        private readonly IBaseService _baseService;
        //private readonly IConfiguration _configuration;

        //public BookService(IBaseService baseService, IConfiguration configuration)
        //{
        //    _baseService = baseService;
        //    _configuration = configuration;
        //}
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

            try
            {
                var response = await _baseService.SendAsync(requestDTO);

                if (response?.Result == null)
                {
                    // Log error or notify that result is null
                    return new List<BookDTO>(); // Return an empty list instead of throwing an exception
                }

                return JsonConvert.DeserializeObject<List<BookDTO>>(response.Result.ToString());
            }
            catch (Exception ex)
            {
                // Optionally log the exception for debugging
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<BookDTO>(); // Return an empty list in case of error
            }
        }


        //public async Task<List<BookDTO>> GetBooks()
        //{
        //    var RequestDTO = new RequestDTO();
        //    RequestDTO.apiMethods = ApiMethods.get;
        //    //RequestDTO.URL = _configuration["ApiBaseUrl"] +"WeatherForecast";
        //    RequestDTO.URL = "http://localhost:7156/WeatherForecast";
        //    var response = await _baseService.SendAsync(RequestDTO);
        // //   response.IsSuccess
        //    return JsonConvert.DeserializeObject<List<BookDTO>>(response.Result.ToString());
        //}
    }

}

