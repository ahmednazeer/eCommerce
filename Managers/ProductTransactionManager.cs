using E_Commerce_App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace E_Commerce_App.Managers
{
    public class ProductTransactionManager
    {
        public int addProductTransaction(List<ProductTransaction> lst)
        {
            
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append("insert into ProductTransaction (transactionid,productid)  values");
            foreach (var pt in lst)
            {
                string querySegement = "("+pt.TransactionId + " , " + pt.ProductId + " ),";
                queryBuilder.Append(querySegement);
            }
            var query = queryBuilder.Remove(queryBuilder.Length - 1,1 ).ToString();//.Remove();
            
            
            int rowsAffected = DBManager.ExecuteDML(query);
            return rowsAffected;
        }
    }
}