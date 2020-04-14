using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(12)]
    public class DictionaryTableMigration_12 : Migration
    {
        public override void Apply()
        {
            var script = $@"CREATE TABLE foreignstudy.dictionary
(
  word_id uuid NOT NULL,
  user_id uuid,
  word_body character varying,
  CONSTRAINT dictionary_pkey PRIMARY KEY (word_id),
  CONSTRAINT dictionary_user_id_fkey FOREIGN KEY (user_id)
      REFERENCES foreignstudy.users (user_id) MATCH SIMPLE
      ON UPDATE CASCADE ON DELETE CASCADE
)
WITH (
  OIDS=FALSE
);
ALTER TABLE foreignstudy.dictionary
  OWNER TO postgres;
";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"DROP TABLE foreignstudy.answers;
";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
