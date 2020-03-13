using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace RHSoft.Study.DbUpdater
{
    [Migration(1)]
    public class UsersTableMigration_01 : Migration
    {
        public override void Apply()
        {

            var script = $@"CREATE SCHEMA monitoring;
CREATE TABLE monitoring.users
(
    id uuid NOT NULL,
    login character varying COLLATE pg_catalog.""default"" NOT NULL,
    password character varying COLLATE pg_catalog.""default"" NOT NULL,
    email character varying COLLATE pg_catalog.""default"" NOT NULL,
    CONSTRAINT users_pkey PRIMARY KEY( id)
); ";
            Database.ExecuteNonQuery( script );
        }
        public override void Revert()
        {
            var script = $@"

DROP TABLE monitoring.users;
";
            Database.ExecuteNonQuery( script );
        }
    }
}
