using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Finance.B4.Infra.Seed
{
    public class SeedEvent
    {
        public SeedEvent()
        {
        }
        public static void Seed(IApplicationBuilder applicationBuilder, string baseUrl)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                HttpClient cliente = new HttpClient();

                Console.WriteLine($"Vai fazer o request para a url: {baseUrl}/api/Quote/GetQuotesRamdom");

                var result = cliente.GetStringAsync($"{baseUrl}/api/Quote/GetQuotesRamdom").GetAwaiter().GetResult;
                
                Console.WriteLine("Fez o request");
                
                Console.WriteLine(result);
            }

        }

    }
}
