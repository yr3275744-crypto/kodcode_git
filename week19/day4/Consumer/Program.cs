// אני צריך לשים try catch
// מחוץ ללופ, אחרת בסוף כל איטרציה הוא ימחק את ה consumer 
// בבלוק ה finally

using Consumer.Data;
using Consumer.Models;
using Consumer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System.Text.Json;

namespace Consumer
{
    class Program
    {
        private static IConfiguration GetConfiguration()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            return configuration;
        }
        private static IServiceCollection ConfigServicesContainer(string connectionString)
        {
            var serviceColleection = new ServiceCollection();

            serviceColleection.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            serviceColleection.AddScoped<RepositoryToMySql>();
            return serviceColleection;

        }
        private async static Task EnshorDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = await scope.ServiceProvider.GetService<AppDbContext>()!
                .Database.EnsureCreatedAsync();
            }
        }

        public async static Task Main()
        {
            var configuration = GetConfiguration();

            string bootstrapServers = configuration["Kafka:BootstrapServers"]!;
            string groupId = configuration["Kafka:GroupId"]!;
            string connectionString = configuration["ConnectionStrings:MySql"]!;
            string analystTopic = configuration["Kafka:Topics:Analyst"]!;
            string callTopic = configuration["Kafka:Topics:Call"]!;

            var serviceColleection = ConfigServicesContainer(connectionString);
            var serviceProvider = serviceColleection.BuildServiceProvider();
            await EnshorDatabase(serviceProvider);

            using (var scop2 = serviceProvider.CreateScope())
            {
                var consumer1 = new MyConsumer(bootstrapServers, groupId, analystTopic);
                try
                {
                    while (true)
                    {
                        var consumeResult = consumer1.Consumer.Consume(TimeSpan.FromSeconds(5));
                        if (consumeResult == null || consumeResult.Message!.Value == null)
                        {
                            break;
                        }

                        AnalystReading analyst = JsonSerializer.Deserialize<AnalystReading>(consumeResult.Message.Value)!;
                        if (string.IsNullOrWhiteSpace(analyst.name) ||
                            string.IsNullOrWhiteSpace(analyst.arena) ||
                                string.IsNullOrWhiteSpace(analyst.specialty))
                        {
                            continue;
                        }
                        var repo = scop2.ServiceProvider.GetRequiredService<RepositoryToMySql>();
                        await repo.SendAnalistToDataBase(analyst);

                    }
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("send analysts Done");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fail to send a analyst: {ex.Message}");
                }
                finally
                {
                    consumer1.UnsubscribeAndDispose();
                }

            }
            using (var scop3 = serviceProvider.CreateScope())
            {
                var consumer2 = new MyConsumer(bootstrapServers, groupId, callTopic);
                try
                {
                    while (true)
                    {
                        var consumeResult = consumer2.Consumer.Consume(TimeSpan.FromSeconds(5));
                        if (consumeResult == null || consumeResult.Message!.Value == null)
                        {
                            continue;
                        }
                        CallReading call = JsonSerializer.Deserialize<CallReading>(consumeResult.Message.Value)!;
                        //if (string.IsNullOrWhiteSpace(call.word_alpha) ||
                        //    string.IsNullOrWhiteSpace(analyst.arena) ||
                        //        string.IsNullOrWhiteSpace(analyst.specialty))
                        //{
                        //    continue;
                        //}
                        var repo = scop3.ServiceProvider.GetRequiredService<RepositoryToMySql>();
                        await repo.SendCallToDataBase(call);

                    }
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("send calls Done");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fail to send a call: {ex.Message}");
                }
                finally
                {
                    consumer2.UnsubscribeAndDispose();
                }
            }
        }
    }
}