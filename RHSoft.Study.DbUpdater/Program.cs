using System;
using System.Reflection;
using Npgsql;
using ThinkingHome.Migrator;

namespace RHSoft.Study.DbUpdater
{
    public class Program
    {
        static void Main( string[] args )
        {
            MigrationRunner a = new MigrationRunner();
            a.MigrationConnection( "Server=localhost;Port=5432;Database=monitoring;UserId=postgres;Password=th3d4t4b4s3" );
        }
    }
}
