using System;
using System.Reflection;
using Npgsql;
using ThinkingHome.Migrator;

namespace DbMigrator
{
    public class Program
    {
        static void Main(string[] args)
        {
            MigrationRunner a = new MigrationRunner();
            a.MigrationConnection("Server=localhost;Port=5432;Database=foreignstudy;UserId=postgres;Password=123");
            Console.WriteLine("Successfully imported DB");
        }
    }
}
