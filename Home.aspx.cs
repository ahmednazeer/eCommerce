using E_Commerce_App.Entities;
using E_Commerce_App.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WF_Day.Managers;

namespace E_Commerce_App
{
    public partial class Home : System.Web.UI.Page
    {
        private static List<int> shoppingListProductsIds;//= new List<int>();
        private static List<int> boughtProductsRowsIndexes;//= new List<int>();
        private static Dictionary<int,int> productsNewCountDictionary;//= new List<int>();

        void Page_PreInit(Object sender, EventArgs e) {
            //check if user is loged in and there are cookies
                if (Request.Cookies["userInfo"] != null)//already loged in
                    this.MasterPageFile = "~/LogoutMaster.master";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ProductManager productManager = new ProductManager();
                shoppingListProductsIds= new List<int>();
                productsNewCountDictionary= new Dictionary<int, int>();
                boughtProductsRowsIndexes = new List<int>();

                DataTable productsTable = productManager.getAll();

                if (productsTable.Rows.Count > 0)
                {
                    if (ViewState["products"] != null)
                    {
                        ViewState["products"] = null;
                    }
                    ViewState.Add("products", productsTable);
                    gv_products.DataSource = productsTable;
                    gv_products.DataBind();
                    
                }

            }
        }

        protected void gv_products_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "buy_click")
            {
                //first thing is to check if user is loged in or not 
                //if yes oredr item and perform transactions if no redirect to login page
                if (Request.Cookies["userInfo"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    gv_products.DataSource = (DataTable)ViewState["products"];
                    gv_products.DataBind();
                    GridViewRow gridViewRow = gv_products.Rows[rowIndex];
                    if (int.TryParse(gridViewRow.Cells[4].Text, out int productId))
                    {
                        var x = (gridViewRow.Cells[3].Text);
                        if (shoppingListProductsIds.Contains(productId))//romove this item from shoping list
                        {
                            removeProductFromShoppingList(rowIndex, productId);
                        }
                        else if (!shoppingListProductsIds.Contains(productId) && int.Parse(gridViewRow.Cells[2].Text) > 0)//buy this item
                        {
                            addProductToShoppingList(rowIndex, productId);
                        }
                        foreach (var item in boughtProductsRowsIndexes)
                        {
                            ((ImageButton)gv_products.Rows[item].Controls[5].Controls[0]).ImageUrl = "~/Images/removeCart.PNG";
                        }
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //1-add transaction
            //2-add ProdductTransaction
            //3-decrease Product Cpacity by 1 each
            ProductManager productManager = new ProductManager();
            //string message = "Something Wrong Occurred";
            if (shoppingListProductsIds.Count > 0)
            {
                int newTransactionId = addTransactionData();
                if (newTransactionId > 0)
                {
                    int rowsAffected = addProductTransactions(newTransactionId);
                    if (rowsAffected > 0)
                    {
                        int counter = 0;
                        foreach (var item in productsNewCountDictionary.Values)
                        {
                            productManager.UpdateProductCount(shoppingListProductsIds[counter], item);
                            counter++;
                        }
                        Response.Redirect("Home.aspx");
                    }

                }
            }


        }

        public void removeProductFromShoppingList(int rowIndex,int productId)
        {
            boughtProductsRowsIndexes.Remove(rowIndex);
            shoppingListProductsIds.Remove(rowIndex);
            ((ImageButton)gv_products.Rows[rowIndex].Controls[5].Controls[0]).ImageUrl = "~/Images/cart.PNG";
            productsNewCountDictionary.Remove(productId);
        }

        public void addProductToShoppingList(int rowIndex, int productId)
        {
            GridViewRow gridViewRow = gv_products.Rows[rowIndex];
            int.TryParse(gridViewRow.Cells[2].Text, out int itemsCount);
            shoppingListProductsIds.Add(productId);
            boughtProductsRowsIndexes.Add(rowIndex);
            productsNewCountDictionary.Add(productId, itemsCount - 1);
            ((ImageButton)gridViewRow.Controls[5].Controls[0]).ImageUrl = "~/Images/removeCart.PNG";

        }

        public int addTransactionData()
        {
            TransactionManager transactionManager = new TransactionManager();

            string userId = Request.Cookies["userInfo"].Values[0];
            Transaction transaction = new Transaction
            {
                UserId = int.Parse(userId),
                Date = DateTime.Now
            };

            int newTransactionId = transactionManager.addTransaction(transaction);
            return newTransactionId;

        }

        public int addProductTransactions(int newTransactionId)
        {
            ProductTransactionManager productTransactionManager = new ProductTransactionManager();

            List<ProductTransaction> productTransactionList = new List<ProductTransaction>();
            foreach (var item in shoppingListProductsIds)
            {
                ProductTransaction productTransaction = new ProductTransaction { ProductId = item, TransactionId = newTransactionId };
                productTransactionList.Add(productTransaction);
            }
            int rowsAffected = productTransactionManager.addProductTransaction(productTransactionList);
            return rowsAffected;
        }
        
        /*public void showErrorMessage(string message)
        {
            lblOperationResult.Visible = true;
            lblOperationResult.Text = message;
        }
        public void showSuccessMessage(string message)
        {
            lblOperationResult.Visible = true;
            lblOperationResult.Text = message;
        }
        */
    }
}