using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(9)]
    public class AnswersTableMigration_09 : Migration
    {
        public override void Apply()
        {
            var script = $@"CREATE TABLE foreignstudy.answers
(
  answer_id uuid NOT NULL,
  answer_body character varying,
  question_id uuid,
  CONSTRAINT answers_pkey PRIMARY KEY (answer_id),
  CONSTRAINT answers_question_id_fkey FOREIGN KEY (question_id)
      REFERENCES foreignstudy.questions (question_id) MATCH SIMPLE
      ON UPDATE CASCADE ON DELETE CASCADE
)
WITH (
  OIDS=FALSE
);
ALTER TABLE foreignstudy.answers
  OWNER TO postgres;
";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"DROP TABLE foreignstudy.answers;";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
