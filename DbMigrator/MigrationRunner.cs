using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using ThinkingHome.Migrator;

namespace DbMigrator
{
    public class MigrationRunner
    {
        public void MigrationConnection(string cnnStrng)
        {
            Npgsql.NpgsqlConnection conn = new NpgsqlConnection(cnnStrng);
            conn.Open();
            //"Server=localhost;Port=5432;Database=test_migration;UserId=postgres;Password=postgres"
            Console.WriteLine(conn.FullState);
            var assembly = typeof(Program).Assembly;
            var migrator = new Migrator("postgres", conn, assembly);
            migrator.Migrate();
        }
    }
}
