using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(7)]
    public class TestsTableMigration_07 : Migration
    {
        public override void Apply()
        {
            var script = $@"CREATE TABLE foreignstudy.tests
(
  test_id uuid NOT NULL,
  theme_id uuid,
  test_name character varying,
  CONSTRAINT tests_pkey PRIMARY KEY (test_id),
  CONSTRAINT tests_theme_id_fkey FOREIGN KEY (theme_id)
      REFERENCES foreignstudy.themes (theme_id) MATCH SIMPLE
      ON UPDATE CASCADE ON DELETE CASCADE
)
WITH (
  OIDS=FALSE
);
ALTER TABLE foreignstudy.tests
  OWNER TO postgres;
";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"DROP TABLE foreignstudy.tests;";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
