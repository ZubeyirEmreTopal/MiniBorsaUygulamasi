using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public class DataResult<T>:Result,IDataResult<T>
    {
        public DataResult(T data, bool success, string messsage):base(success,messsage)
        {
            Data = data;
        }

        public DataResult(T data, bool succes):base(succes)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
