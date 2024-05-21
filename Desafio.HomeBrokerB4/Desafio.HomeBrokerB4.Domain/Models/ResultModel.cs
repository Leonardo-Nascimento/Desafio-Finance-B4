using Desafio.HomeBrokerB4.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.HomeBrokerB4.Domain.Models
{
    public class ResultModel : IOutput
    {
        private readonly OutputModel _output;

        public ResultModel()
        {
            _output = new OutputModel();
        }

        public ResultModel Result<T>(T result) where T : class
        {
            _output.Result(result);
            return this;
        }

        public ResultModel ResultErro(string message)
        {
            _output.AddErro(message);
            return this;
        }

        public ResultModel Response() => this;

        //public ResultModel ok() => this;


    }
}
