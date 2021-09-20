using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Npgsql;
using ThinkingHome.Migrator;
using ThinkingHome.Migrator.Providers.SqlServer;

namespace DbMigrator
{
    public class MigrationRunner
    {
        public void MigrationConnection(string cnnStrng)
        {
            //Npgsql.NpgsqlConnection conn = new NpgsqlConnection(cnnStrng);
            //SqlServerConnection conn = new SqlServerConnection(cnnStrng);
            //conn.Open();
            //"Server=localhost;Port=5432;Database=test_migration;UserId=postgres;Password=postgres"
            //Console.WriteLine(conn.FullState);
            var assembly = typeof(Program).Assembly;
            //var migrator = new Migrator("sqlserver", "server=ASKOLD-ПК\\sqlexpress;database=foreignstudy;Trusted_Connection=True;", assembly);
            //var migrator = new Migrator("sqlserver", "server=LAPTOP-2I0E2SNC\\sqlexpress;database=foreignstudy;Trusted_Connection=True;", assembly);
            Npgsql.NpgsqlConnection conn = new NpgsqlConnection(cnnStrng);
            conn.Open();
            var migrator = new Migrator("postgres", conn, assembly);
            migrator.Migrate();
        }
    }
}
