using Microsoft.EntityFrameworkCore;
using AGsite.Models;

namespace AGsite.Data
{
    public class SurveyDataContext : DbContext
    {
        public SurveyDataContext(DbContextOptions<SurveyDataContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<SurveyData> SurveyAnswers { get; set; } //making a new table called Survey Answers of the class SurveyData. 
    }

    public static class DBInitializer //make the thing keep thinging
    {
        public static void Initialize(SurveyDataContext context)
        {
            context.Database.Migrate();
        }
    }
}
