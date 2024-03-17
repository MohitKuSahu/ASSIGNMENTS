using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TentRentalProject.Models;
using TentRentalProject.Utils;
using static TentRentalProject.Utils.Utility;

namespace TentRentalProject.DataAccessLayer
{
    public class DAL
    {
        public static List<ProductModel> GetAllProduct(int sort)
        {
            List<ProductModel> productList = new List<ProductModel>();

            try
            {
                using (var context = new RentalEntities2())
                {

                    productList = context.Products
                      .Select(productModel => new ProductModel
                      {
                          ProductID = productModel.ProductID,
                          ProductTitle = productModel.ProductTitle,
                          QuantityTotal = (int)productModel.QuantityTotal,
                          QuantityBooked = (int)productModel.QuantityBooked,
                          Price = (decimal)productModel.Price,
                      }).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            if (sort == ((int)Utility.Sort.Ascending))
                return productList.OrderBy(x => x.ProductTitle).ToList();
            else if (sort == (int)Utility.Sort.Descending)
                return productList.OrderByDescending(x => x.ProductTitle).ToList();
            else
                return productList;

        }
        public static List<string> GetAllProductTitle()
        {
            List<ProductModel> allProducts = GetAllProduct((int)Sort.Normal);
            List<string> titleList = new List<string>();
            try
            {
                using (var context = new RentalEntities2())
                {
                    foreach (var item in allProducts)
                    {
                        titleList.Add(item.ProductTitle);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return titleList;
        }

        public static ProductModel GetProductByID(int ProductID)
        {
            ProductModel product = null;
            try
            {
                using (var context = new RentalEntities2())
                {
                    var productEntity = context.Products.Where(p => p.ProductID == ProductID).FirstOrDefault();

                    product = new ProductModel
                    {
                        ProductID = productEntity.ProductID,
                        ProductTitle = productEntity.ProductTitle,
                        QuantityTotal = (int)productEntity.QuantityTotal,
                        QuantityBooked = (int)productEntity.QuantityBooked,
                        Price = (decimal)productEntity.Price,
                    };
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return product;
        }

        public static ProductModel UpdateProduct(ProductModel product)
        {
            try
            {
                using (var context = new RentalEntities2())
                {
                    var existingProduct = context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);

                    if (existingProduct != null)
                    {
                        existingProduct.ProductTitle = product.ProductTitle;
                        existingProduct.Price = product.Price;
                        existingProduct.ProductID = product.ProductID;
                        existingProduct.QuantityTotal = product.QuantityTotal;
                        existingProduct.QuantityBooked = product.QuantityBooked;

                        context.SaveChanges();
                    }
                };
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return product;
        }

        public static CustomerModel GetCustomerByID(int CustomerID)
        {
            CustomerModel Customer = null;
            try
            {
                using (var context = new RentalEntities2())
                {
                    var CustomerEntity = context.Customers.Where(p => p.CustomerID == CustomerID).FirstOrDefault();

                    Customer = new CustomerModel
                    {
                        CustomerID = CustomerEntity.CustomerID,
                        CustomerName = CustomerEntity.CustomerName,
                    };
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return Customer;
        }

        public static CustomerModel UpdateCustomer(CustomerModel Customer)
        {
            try
            {
                using (var context = new RentalEntities2())
                {
                    var existingCustomer = context.Customers.FirstOrDefault(p => p.CustomerID == Customer.CustomerID);

                    if (existingCustomer != null)
                    {
                        existingCustomer.CustomerID = Customer.CustomerID;
                        existingCustomer.CustomerName = Customer.CustomerName;
                        context.SaveChanges();
                    }
                };
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return Customer;
        }
        public static List<CustomerModel> GetAllCustomer(int sort)
        {
            List<CustomerModel> customerList = new List<CustomerModel>();

            try
            {

                using (var context = new RentalEntities2())
                {

                    customerList = context.Customers
                      .Select(customerModel => new CustomerModel
                      {
                          CustomerID = customerModel.CustomerID,
                          CustomerName = customerModel.CustomerName,
                      }).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            if (sort == ((int)Utility.Sort.Ascending))
                return customerList.OrderBy(x => x.CustomerName).ToList();
            else if (sort == (int)Utility.Sort.Descending)
                return customerList.OrderByDescending(x => x.CustomerName).ToList();
            else
                return customerList;

        }
        public static List<TransactionHistoryModel> GetAllTransaction(int sort)
        {
            List<TransactionHistoryModel> transactionList = new List<TransactionHistoryModel>();

            try
            {
                using (var context = new RentalEntities2())
                {

                    transactionList = context.TransactionHistories
                      .Select(transactionHistoryModel => new TransactionHistoryModel
                      {
                          TransactionID = transactionHistoryModel.TransactionID,
                          TransactionDateTime = (DateTime)transactionHistoryModel.TransactionDateTime,
                          CustomerID = (int)transactionHistoryModel.CustomerID,
                          ProductID = (int)transactionHistoryModel.ProductID,
                          TransactionType = transactionHistoryModel.TransactionType,
                          TransactionParentID = (int)transactionHistoryModel.TransactionParentID,
                          Quantity = (int)transactionHistoryModel.Quantity

                      }).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            if (sort == ((int)Utility.Sort.Ascending))
                return transactionList.OrderBy(x => x.TransactionDateTime).ToList();
            else if (sort == (int)Utility.Sort.Descending)
                return transactionList.OrderByDescending(x => x.TransactionDateTime).ToList();
            else
                return transactionList;


        }
        public static void InsertTransaction(TransactionHistoryModel model)
        {
            try
            {
                using (var context = new RentalEntities2())
                {


                    var newTransaction = new TransactionHistory
                    {
                        TransactionID = model.TransactionID,
                        TransactionDateTime = DateTime.Now,
                        CustomerID = model.CustomerID,
                        ProductID = model.ProductID,
                        TransactionType = model.TransactionType,
                        Quantity = model.Quantity,
                        TransactionParentID = model.TransactionParentID,
                    };

                    context.TransactionHistories.Add(newTransaction);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

        }
        public static Tuple<int, bool> InsertCustomer(CustomerModel model)
        {
            try
            {
                using (var context = new RentalEntities2())
                {
                    var customer = context.Customers.FirstOrDefault(c => c.CustomerName == model.CustomerName);
                    if (customer != null)
                    {
                        Tuple<int, bool> list = new Tuple<int, bool>(customer.CustomerID, false);
                        return list;
                    }
                    else
                    {
                        var newCustomer = new Customer
                        {
                            CustomerName = model.CustomerName
                        };

                        context.Customers.Add(newCustomer);
                        context.SaveChanges();

                        Tuple<int, bool> list = new Tuple<int, bool>(newCustomer.CustomerID, true);
                        return list;
                    }

                }

            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return null;
        }
        public static bool InsertProduct(ProductModel model)
        {
            try
            {
                using (var context = new RentalEntities2())
                {
                    var product = context.Products.FirstOrDefault(c => c.ProductTitle == model.ProductTitle);
                    if (product != null)
                    {
                        return false;
                    }
                    else
                    {
                        var newProduct = new Product
                        {
                            ProductTitle = model.ProductTitle,
                            Price = model.Price,
                            QuantityBooked = model.QuantityBooked,
                            QuantityTotal = model.QuantityTotal
                        };

                        context.Products.Add(newProduct);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return true;
        }

        public static void InsertProductTransaction()
        {

        }
        public static void InsertUser(UserModel model)
        {
            try
            {
                using (var context = new RentalEntities2())
                {
                    var newUser = new User
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password,
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }
        public static bool UpdateProductIn(int id, int quantity)
        {
            try
            {
                using (var context = new RentalEntities2())
                {
                    Product idToUpdate = context.Products.FirstOrDefault(e => e.ProductID == id);
                    if (idToUpdate != null && idToUpdate.QuantityBooked >= quantity)
                    {

                        idToUpdate.QuantityBooked -= quantity;
                        context.SaveChanges();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return false;
        }
        public static bool UpdateProductOut(int id, int quantity)
        {
            try
            {
                using (var context = new RentalEntities2())
                {
                    Product idToUpdate = context.Products.FirstOrDefault(e => e.ProductID == id);
                    if (idToUpdate != null && quantity <= idToUpdate.QuantityTotal - idToUpdate.QuantityBooked)
                    {
                        idToUpdate.QuantityBooked += quantity;
                        context.SaveChanges();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return false;
        }
        public static int? FindTransactionID(int custID, int productID)
        {
            try
            {
                using (var context = new RentalEntities2())
                {
                    TransactionHistory findId = context.TransactionHistories.FirstOrDefault(e => e.ProductID == productID && e.CustomerID == custID);
                    if (findId != null)
                    {
                        return findId.TransactionID;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return null;
        }
        public static int GetTransactionID()
        {
            using (var context = new RentalEntities2())
            {
                bool isTableEmpty = !context.TransactionHistories.Any();
                if (isTableEmpty)
                    return 123456;
                else
                {
                    int latestTransactionID = context.TransactionHistories
                                       .OrderByDescending(t => t.TransactionID)
                                       .Select(t => t.TransactionID)
                                       .FirstOrDefault();
                    return latestTransactionID + 1;
                }
            }

        }
        public static void DeleteAllTransactions()
        {
            try
            {
                using (var context = new RentalEntities2())
                {
                    var allProducts = context.Products.ToList();

                    foreach (var product in allProducts)
                    {
                        product.QuantityBooked = 0;
                    }
                    context.SaveChanges();

                    var allRecords = context.TransactionHistories.ToList();
                    context.TransactionHistories.RemoveRange(allRecords);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }
        public static void DeleteTransactionByProductID(int productID)
        {
            try
            {
                using (var context = new RentalEntities2())
                {
                    var entitiesToRemove = context.TransactionHistories.Where(e => e.ProductID == productID).ToList();

                    foreach (var entityToRemove in entitiesToRemove)
                    {
                        context.TransactionHistories.Remove(entityToRemove);
                    }


                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
        }
        public static bool IfTransactionExistsByProductID(int productID)
        {
            using (var context = new RentalEntities2())
            {
                var transactionsForProduct = context.TransactionHistories.Where(t => t.ProductID == productID);
                return (transactionsForProduct.Any());
            }

        }

        public static int IsUser(string email, string password)
        {
            int userId = 0;
            try
            {
                using (var context = new RentalEntities2())
                {
                    if ((email != "") && password != "")
                    {
                        var user = context.Users.Single(x => x.Email == email);
                        if (user.Password == password)
                        {
                            userId = user.UserID;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return userId;
        }
        public static bool IsAdmin(int id)
        {
            if (id == (int)(Utility.User.Admin))
                return true;
            else
                return false;
        }
        public static List<string> GetMonthNames()
        {

            Array monthValues = Enum.GetValues(typeof(Month));

            List<string> monthNames = new List<string>();

            foreach (var monthValue in monthValues)
            {
                monthNames.Add(Enum.GetName(typeof(Month), monthValue));
            }

            return monthNames;
        }


    }

}


