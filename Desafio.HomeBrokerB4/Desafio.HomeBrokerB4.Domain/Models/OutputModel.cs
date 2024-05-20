using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.HomeBrokerB4.Domain.Models
{
    public class OutputModel
    {
        public OutputModel(string? message, object data, bool sucess = true)
        {
            Message = message;
            Sucess = sucess;
            Data = data;
        }

        public OutputModel()
        {
            Sucess = true;
        }

        public string Message { get; private set; }
        public bool Sucess { get; private set; }
        public object Data { get; private set; }

        public void Result<T>(T result) where T : class
        {
            Data = result;
        }

        public void AddErro(string message)
        {
            Message = message;
            Sucess = false;
        }
    }
}
