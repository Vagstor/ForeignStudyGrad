using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(10)]
    public class LecturesTableMigration_10 : Migration
    {
        public override void Apply()
        {
            var script = $@"CREATE TABLE foreignstudy.lectures
(
  lecture_id uuid NOT NULL,
  theme_id uuid,
  CONSTRAINT lectures_pkey PRIMARY KEY (lecture_id),
  CONSTRAINT lectures_theme_id_fkey FOREIGN KEY (theme_id)
      REFERENCES foreignstudy.themes (theme_id) MATCH SIMPLE
      ON UPDATE CASCADE ON DELETE CASCADE
)
WITH (
  OIDS=FALSE
);
ALTER TABLE foreignstudy.lectures
  OWNER TO postgres;
";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"DROP TABLE foreignstudy.lectures;";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
