using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(2)]
    public class UsersTableMigration_02 : Migration
    {
        public override void Apply()
        {
            var script = $@"
CREATE TABLE foreignstudy.users
(
  id uuid NOT NULL,
  email character varying,
  login character varying,
  password character varying,
role character varying,
  CONSTRAINT users_pkey PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE foreignstudy.users
  OWNER TO postgres;
";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            base.Revert();
        }
    }
}
