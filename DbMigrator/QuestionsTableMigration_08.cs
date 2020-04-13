using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(8)]
    public class QuestionsTableMigration_08 : Migration
    {
        public override void Apply()
        {
            var script = $@"CREATE TABLE foreignstudy.questions
(
  question_id uuid NOT NULL,
  question_body character varying,
  test_id uuid,
  CONSTRAINT questions_pkey PRIMARY KEY (question_id),
  CONSTRAINT questions_test_id_fkey FOREIGN KEY (test_id)
      REFERENCES foreignstudy.tests (test_id) MATCH SIMPLE
      ON UPDATE CASCADE ON DELETE CASCADE
)
WITH (
  OIDS=FALSE
);
ALTER TABLE foreignstudy.questions
  OWNER TO postgres;
";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"DROP TABLE foreignstudy.questions;";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
