using Consumer.Data;
using Consumer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Services
{
    public class RepositoryToMySql
    {
        private readonly AppDbContext _dbContext;
        public RepositoryToMySql(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> SendAnalistToDataBase(AnalystReading analyst)
        {
            try
            {
                Analyst analyst1 = new Analyst
                {
                    analyst_id = analyst.analyst_id,
                    name = analyst.name,
                    arena = analyst.arena,
                    specialty = analyst.specialty
                };
                _dbContext.Analysts.Add(analyst1);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Somthing get wrong: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> SendCallToDataBase(CallReading call)
        {
            try
            {
                Call call1 = new Call
                {
                    call_id = call.call_id,
                    word_charlie = call.word_charlie,
                    agent_id = call.agent_id,
                    word_alpha = call.word_alpha,
                    word_bravo = call.word_bravo,
                    analyst_id = call.analyst_id
                };
                _dbContext.Calls.Add(call1);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Somthing get wrong: {ex.Message}");
                return false;
            }
        }
    }
}
