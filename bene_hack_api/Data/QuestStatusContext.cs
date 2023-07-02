using Microsoft.EntityFrameworkCore;
using bene_hack_api.Models;

namespace bene_hack_api.Data;

public class QuestStatusContext : DbContext
{
    public QuestStatusContext(DbContextOptions<QuestStatusContext> options)
        : base(options)
    {
    }

    public DbSet<QuestStatus> QuestStatus { get; set; }
}