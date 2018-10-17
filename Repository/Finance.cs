using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Finance
    {
        ConnectionString conn = new ConnectionString();
        
        public IEnumerable<Accounting> GetAllRecord()
        {
            SqlConnection connection = new SqlConnection(conn.database);
            return connection.Query<Accounting>("SELECT * FROM Accounting where MemberID = 1 ");
        }

        public void AccountingToDatabase(Accounting model)
        {
            SqlConnection connection = new SqlConnection(conn.database);
            connection.Query<Accounting>("INSERT INTO Accounting(MemberID , AccountingName , AccountingTime , AccountingCost) Values(@MemberID , @AccountingName , @AccountingTime , @AccountingCost) ",new {
                model.MemberID,
                model.AccountingName,
                model.AccountingTime,
                model.AccountingCost
            });
        }



        


    }
}
