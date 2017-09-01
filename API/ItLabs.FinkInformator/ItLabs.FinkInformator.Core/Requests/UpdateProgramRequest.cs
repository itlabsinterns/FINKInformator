using ItLabs.FinkInformator.Core.Models;

namespace ItLabs.FinkInformator.Core.Requests
{
    public class UpdateProgramRequest
    {
        public int IdToUpdate { get; set; }
        public Program Program { get; set; }
    }
}
