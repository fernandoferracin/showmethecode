using System.Collections.Generic;

namespace DesafioTecnico.MVC.Communication
{
    public class ResponseResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
    }
}