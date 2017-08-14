using System.Collections.Generic;
using System.Text;

namespace ItLabs.FinkInformator.Api.Responses
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            IsSuccessful = true;
            Errors = new List<string>();
        }

        public bool IsSuccessful { get; set; }

        public List<string> Errors { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Errors.ForEach(i => sb.Append(i).Append(", "));
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
    }
}