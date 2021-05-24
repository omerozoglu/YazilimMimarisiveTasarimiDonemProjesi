using System.Collections.Generic;
using Domain.Common.Enums;

namespace Domain.Common {

    //* Tüm Entity base objelerinin ortak bir şekilde dönmeleri için yaptım
    public class BaseResponse<T> where T : EntityBase {
        public string ReponseName { get; set; }
        public ResponseType Status { get; set; }
        public string Message { get; set; }
        public List<T> Content { get; set; }
    }
}