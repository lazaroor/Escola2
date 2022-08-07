using MySql.Data.EntityFramework;
using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola2
{
    public class MysqlContext:DbContext
    {
        private MySqlConnection mConn;

        private MySqlDataAdapter mAdapter;

        private DataSet mDataSet;
        public MysqlContext()
        {
            mDataSet = new DataSet();

        }

        public MySqlConnection MConn
        {
            get { return mConn; }
            private set { mConn = value; }
        }
    }
}
