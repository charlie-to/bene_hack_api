using Microsoft.EntityFrameworkCore;
using bene_hack_api.Models;

namespace bene_hack_api.Data;

public class QuestContext : DbContext
{
    public QuestContext(DbContextOptions<QuestContext> options)
        : base(options)
    {
    }

    public DbSet<Quest> Quests { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Quest>().HasData(
    //        new Quest { id = 1, name = "初めのタスク", deadline=DateTime.Today.AddDays(1), isFinished=false},
    //        new Quest { id = 2, name = "2つ目のタスク", deadline = DateTime.Today.AddDays(1), isFinished = false }
    //    );
    //}
}