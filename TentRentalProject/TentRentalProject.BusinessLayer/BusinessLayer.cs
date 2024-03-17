using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TentRentalProject.DataAccessLayer;
using TentRentalProject.Models;

namespace TentRentalProject.Business
{
    public class BusinessLayer
    {
        public static List<ProductModel> GetAllProduct(int sort)
        {
            return DAL.GetAllProduct(sort);
        }

        public static List<string> GetAllProductTitle()
        {
            return DAL.GetAllProductTitle();
        }

        public static ProductModel GetProductByID(int ProductID)
        {
            return DAL.GetProductByID(ProductID);
        }
        public static ProductModel UpdateProduct(ProductModel product)
        {
            return DAL.UpdateProduct(product);
        }
        public static CustomerModel GetCustomerByID(int CustomerID)
        {
            return DAL.GetCustomerByID(CustomerID);
        }
        public static CustomerModel UpdateCustomer(CustomerModel customer)
        {
            return DAL.UpdateCustomer(customer);
        }
        public static List<CustomerModel> GetAllCustomer(int sort)
        {
            return DAL.GetAllCustomer(sort);
        }
        public static List<TransactionHistoryModel> GetAllTransaction(int sort)
        {
            return DAL.GetAllTransaction(sort);
        }
        public static void InsertTransaction(TransactionHistoryModel model)
        {
            DAL.InsertTransaction(model);
        }
        public static bool InsertProduct(ProductModel model)
        {
            return DAL.InsertProduct(model);
        }

        public static Tuple<int, bool> InsertCustomer(CustomerModel model)
        {
            return DAL.InsertCustomer(model);
        }

        public static void InsertUser(UserModel model)
        {
            DAL.InsertUser(model);
        }
        public static bool UpdateProductIn(int id, int quantity)
        {
            return DAL.UpdateProductIn(id, quantity);
        }
        public static bool UpdateProductOut(int id, int quantity)
        {
            return DAL.UpdateProductOut(id, quantity);
        }
        public static int? FindTransactionID(int custID, int productID)
        {
            return DAL.FindTransactionID(custID, productID);
        }
        public static int GetTransactionID()
        {
            return DAL.GetTransactionID();
        }

        public static void DeleteAllTransactions()
        {
            DAL.DeleteAllTransactions();
        }

        public static void DeleteTransactionByProductID(int productID)
        {
            DAL.DeleteTransactionByProductID(productID);
        }
        public static bool IfTransactionExistsByProductID(int productID)
        {
            return DAL.IfTransactionExistsByProductID(productID);
        }
        public static int IsUser(string email, string password)
        {
            return DAL.IsUser(email, password);
        }
        public static bool IsAdmin(int id)
        {
            return DAL.IsAdmin(id);
        }
        public static List<string> GetMonthNames()
        {
            return DAL.GetMonthNames();
        }

    }
}
