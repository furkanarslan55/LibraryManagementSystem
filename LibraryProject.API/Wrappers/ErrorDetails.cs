using System.Text.Json;

namespace LibraryProject.API.Wrappers
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; } // Örn: 400, 404, 500
        public string Message { get; set; } // Örn: "Kitap bulunamadı."

        // Bu nesneyi JSON string'e çeviren yardımcı metot
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
