using ItLabs.FinkInformator.Core.Models;
namespace ItLabs.FinkInformator.Core.Responses
{
    public class GetProgramResponse:ResponseBase
    {
        public Program Program { get; set; }
    }
}