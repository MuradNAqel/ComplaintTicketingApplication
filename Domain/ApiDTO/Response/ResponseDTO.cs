using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ApiDTO.Response
{
    public class ResponseDTO<TData>
    {
        public TData Data { get; set; }
        public bool Success { get; set; }
        public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();

        public void SetFailureWithError(string errKey, string errMessage)
        {
            Success = false;
            Errors.Add(errKey, errMessage);
        }

        public void SetSuccessWithPayload(TData data)
        {
            Success = true;
            Data = data;
        }

    }
}
