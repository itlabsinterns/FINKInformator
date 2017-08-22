namespace ItLabs.FinkInformator.Core.Requests
{
    public class IdRequest
    {
        public IdRequest(int? id = null)
        {
            if (id.HasValue)
                Id = id.Value;
        }

        public int Id { get; set; }
    }
}