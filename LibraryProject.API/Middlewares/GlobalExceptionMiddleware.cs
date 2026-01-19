using LibraryProject.API.Models;
using System.Net;

namespace LibraryProject.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        // RequestDelegate: Bir sonraki adımı temsil eder (Controller vb.)
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Middleware'in asıl işi yaptığı yer: InvokeAsync
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                // 1. İsteği bir sonraki adıma (Controller'a) gönder.
                // Eğer hata yoksa burası normal çalışır ve biter.
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // 2. Eğer içeride BİRİ hata fırlatırsa (throw new Exception),
                // Kod buraya düşer. Biz de hatayı ele alırız.
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Cevabın tipini JSON yapıyoruz.
            context.Response.ContentType = "application/json";

            // Varsayılan olarak 500 (Internal Server Error) veriyoruz.
            // İstersen hatanın türüne göre if-else ile 400, 404 vs. ayarlayabilirsin.
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Sunucu kaynaklı bir hata oluştu.";

            // ÖZELLEŞTİRME:
            // Eğer hata bizim manuel fırlattığımız bir hataysa mesajı olduğu gibi göster.
            // Değilse (SQL hatası vs.) gizle.
            // Şimdilik öğrenme aşamasında olduğumuz için hepsini gösterelim:
            message = exception.Message;

            var errorResponse = new ErrorResult()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            };

            // Hazırladığımız JSON'u kullanıcıya gönderiyoruz.
            await context.Response.WriteAsync(errorResponse.ToString());

        }
    }
}