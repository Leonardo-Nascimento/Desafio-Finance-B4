using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Finance.B4.Infra.Seed
{
    public class SeedEvent
    {
        public static void Seed(IApplicationBuilder applicationBuilder, string baseUrl)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                HttpClient cliente = new HttpClient();

                var result = cliente.GetStringAsync($"{baseUrl}/api/Quote/GetQuotesRamdom");

                Console.WriteLine(result);
            }

        }

    }
}
