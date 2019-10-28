using E_Commerce_App;
using E_Commerce_App.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WF_Day.Managers
{
    public class UserManager
    {
        //public DBManager manager { get; set; }
        public DataTable getLoginByEmail(string email,string password)
        {
            string query = "select * from _User where email = '" + email + "' and password = '" + password + "';";// );";
            return DBManager.ExecuteQuery(query);
        }

        public int addUser(User user) {
            string query = "insert into _User (firstname,lastname,email,password) values('" 
                + user.FirstName + "','" 
                +user.LastName+"' , '"
                +user.Email+"' , '"
                + user.Password + "');";
            return DBManager.ExecuteDML(query);
        }

        /*
        public int addUser(int userId)
        {
            string query = "update User set name='"+name+"', countryid="+countryId+" where id = "+UserId;//  values('" + name + "'," + countryId + ");";
            return DBManager.ExecuteDML(query);
        }
        */
        public DataTable getUserTransactions(int userId)
        {
            string query = "select _User.FirstName + _User.LastName as FullName  , _Transaction.Date , Product.Name from"
                + " _User inner join _Transaction on _User.Id = _Transaction.UserId"
                + " inner join ProductTransaction on ProductTransaction.TransactionId = _Transaction.Id"
                + " inner join Product on ProductTransaction.ProductId = Product.Id"
                + " where _User.Id = " + userId + " );";

            return DBManager.ExecuteQuery(query);
        }

    }
}