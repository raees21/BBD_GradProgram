using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BudgetPlanner.Functions
{


        public class transactionsRepository
        {

            private SqlConnection con;
            private SqlCommand com;

            private void connection()
            {
               // string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
                con = new SqlConnection("Data Source = clouddb.cbsozziiwdya.eu - west - 1.rds.amazonaws.com; Initial Catalog = BudgetPlanner; Persist Security Info = True; User ID = group3; Password = password");


            }

            public string AddTransaction(Decimal amount, int account, int category, int token , string date)
            {
                connection();
                com = new SqlCommand("dbo.addTransaction", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Amount", amount);
                com.Parameters.AddWithValue("@AccountID", account);
                com.Parameters.AddWithValue("@CategoryID", category);
                com.Parameters.AddWithValue("@Token", token);
                com.Parameters.AddWithValue("@Date", date);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    return "New Transaction Added Successfully";

                }
                else
                {
                    return "Transaction Not Added";

                }
            }
        }
    } 