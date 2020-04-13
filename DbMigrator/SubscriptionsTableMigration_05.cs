using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(5)]
    public class SubscriptionsTableMigration_05 : Migration
    {
        public override void Apply()
        {
            var script = $@"CREATE TABLE foreignstudy.subscriptions
(
  user_id uuid NOT NULL,
  course_id uuid NOT NULL,
  CONSTRAINT subscriptions_pkey PRIMARY KEY (user_id, course_id),
  CONSTRAINT subscriptions_course_id_fkey FOREIGN KEY (course_id)
      REFERENCES foreignstudy.courses (course_id) MATCH SIMPLE
      ON UPDATE CASCADE ON DELETE CASCADE,
  CONSTRAINT subscriptions_user_id_fkey FOREIGN KEY (user_id)
      REFERENCES foreignstudy.users (user_id) MATCH SIMPLE
      ON UPDATE CASCADE ON DELETE CASCADE
)
WITH (
  OIDS=FALSE
);
ALTER TABLE foreignstudy.subscriptions
  OWNER TO postgres;
";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            var revert_script = $@"DROP TABLE foreignstudy.subscriptions;";
            Database.ExecuteNonQuery(revert_script);
        }
    }
}
