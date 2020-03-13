using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace RHSoft.Study.DbUpdater
{
    [Migration( 3 )]
    public class VisitsTableMigration_03 : Migration
    {
        public override void Apply()
        {

            var script = $@"
CREATE TABLE monitoring.visits
(
      id uuid NOT NULL,
    url character varying COLLATE pg_catalog.""default"",
    visit_time timestamp(0) without time zone NOT NULL,
    status integer NOT NULL,
    site_id uuid NOT NULL,
    error_desc character varying COLLATE pg_catalog.""default"",
    CONSTRAINT visits_pkey PRIMARY KEY( id),
    CONSTRAINT visits_site_id_fk FOREIGN KEY(site_id)
        REFERENCES monitoring.sites( id ) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION 
); ";
            Database.ExecuteNonQuery( script );
        }
        public override void Revert()
        {
            var script = $@"

DROP TABLE monitoring.visits;
";
            Database.ExecuteNonQuery( script );
        }
    }
}
