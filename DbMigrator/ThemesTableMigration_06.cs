using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(6)]
    public class ThemesTableMigration_06 : Migration
    {
        public override void Apply()
        {
            var script = $@"CREATE TABLE foreignstudy.themes
(
  theme_id uuid NOT NULL,
  theme_name character varying,
  course_id uuid,
  CONSTRAINT themes_pkey PRIMARY KEY(theme_id),
  CONSTRAINT themes_course_id_fkey FOREIGN KEY(course_id)
      REFERENCES foreignstudy.courses(course_id) MATCH SIMPLE
      ON UPDATE CASCADE ON DELETE CASCADE
)
WITH(
  OIDS= FALSE
);
        ALTER TABLE foreignstudy.themes
          OWNER TO postgres;
";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"DROP TABLE foreignstudy.themes;";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
