using MVCdevopsProject.DTOs;
namespace MVCdevopsProject.Services.GeneralServices {

    public interface IBaseService {
        Task<ResponseDTO> SendAsync(RequestDTO request);
    }
}