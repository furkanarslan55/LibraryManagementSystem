using System.Text.Json;

namespace LibraryProject.API.Models
{
    public class ErrorResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        // Bu metot, nesneyi JSON string'e çevirir (Serialize).
        // Middleware içinde kullanacağız.
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
