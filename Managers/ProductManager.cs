using E_Commerce_App;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WF_Day.Managers
{
    public class ProductManager
    {
        public DataTable getAll()
        {
            string query = "select * from Product where capacity > 0 ;";
            return DBManager.ExecuteQuery(query);
        }
        public int UpdateProductCount(int productId,int newCount)
        {
            string query = "update product set capacity =" + newCount + " where id = " + productId;
            return DBManager.ExecuteDML(query);
        }


    }
}