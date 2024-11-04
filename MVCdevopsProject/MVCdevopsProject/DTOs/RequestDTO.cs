using MVCdevopsProject.Enums;

namespace MVCdevopsProject.DTOs {
    public class RequestDTO {
        public string URL { get; set; }
        public object Data{ get; set; }
        public ApiMethods apiMethods { get; set; }=ApiMethods.get;
    }

}