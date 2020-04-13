using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(4)]
    public class CoursesTableMigration_04 : Migration
    {
        public override void Apply()
        {
            var script = $@"CREATE TABLE foreignstudy.courses
(
  course_id uuid NOT NULL,
  course_name character varying,
  CONSTRAINT courses_pkey PRIMARY KEY (course_id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE foreignstudy.courses
  OWNER TO postgres;";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"DROP TABLE foreignstudy.courses;";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
