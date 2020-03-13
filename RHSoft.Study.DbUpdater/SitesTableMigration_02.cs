using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace RHSoft.Study.DbUpdater
{
    [Migration( 2 )]
    public class SitesTableMigration_02 : Migration
    {
        public override void Apply()
        {

            var script = $@"
CREATE TABLE monitoring.sites
(
        id uuid NOT NULL,
    url character varying COLLATE pg_catalog.""default"",
    user_id uuid,
    add_time timestamp(0) without time zone NOT NULL,
    last_status integer NOT NULL,
    CONSTRAINT sites_pkey PRIMARY KEY( id),
    CONSTRAINT sites_user_id_fk FOREIGN KEY(user_id)
        REFERENCES monitoring.users( id ) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
); ";
            Database.ExecuteNonQuery( script );
        }
        public override void Revert()
        {
            var script = $@"

DROP TABLE monitoring.sites;
";
            Database.ExecuteNonQuery( script );
        }
    }
}
