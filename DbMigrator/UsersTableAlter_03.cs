using System;
using System.Collections.Generic;
using System.Text;
using ThinkingHome.Migrator.Framework;

namespace DbMigrator
{
    [Migration(3)]
    public class UsersTableAlter_03 : Migration
    {
        public override void Apply()
        {
            var script = $@"ALTER TABLE foreignstudy.users
  DROP COLUMN role;
ALTER TABLE foreignstudy.users RENAME id  TO user_id;
ALTER TABLE foreignstudy.users RENAME email  TO user_email;
ALTER TABLE foreignstudy.users RENAME login  TO user_login;
ALTER TABLE foreignstudy.users RENAME password  TO user_password;
ALTER TABLE foreignstudy.users
  ADD COLUMN user_credentials character varying;

";
            Database.ExecuteNonQuery(script);
        }

        public override void Revert()
        {
            base.Revert();
        }
    }
}
