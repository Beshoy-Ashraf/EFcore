using System;
using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFcore
{
      public class program
      {
            public static int Main(string[] args)
            {
                  transactionOnDB();
                  return 0;
            }

            private static void transactionOnDB()
            {
                  using (var context = new AppDBContext())
                  {
                        using (var transaction = context.Database.BeginTransaction())
                        {

                              var fromWallet = context.wallet.SingleOrDefault(x => x.id == 4);
                              var toWallet = context.wallet.SingleOrDefault(x => x.id == 7);

                              fromWallet.balance -= 100;
                              context.SaveChanges();

                              toWallet.balance += 100;
                              context.SaveChanges();


                              if (fromWallet.balance < 0)
                              {
                                    return;
                              }
                              transaction.Commit();
                        }
                  }
            }

            private static void retrieveGroub()
            {
                  using (var context = new AppDBContext())
                  {
                        var selectedItems = context.wallet.Where(x => x.balance >= 200);

                        foreach (var item in selectedItems)
                        {
                              Console.WriteLine(item);
                        }
                  }
            }

            private static void deleteItem()
            {
                  using (var context = new AppDBContext())
                  {
                        var selectedItem = context.wallet.Single(x => x.id == 9);
                        context.Remove(selectedItem);
                        context.SaveChanges();
                  }
            }

            private static void UpdateRowData()
            {
                  using (var context = new AppDBContext())
                  {
                        var selectedItem = context.wallet.SingleOrDefault(x => x.id == 7);
                        selectedItem!.balance += 5000;
                        context.SaveChanges();
                  }
            }

            private static void retrieveItems()
            {
                  using (var context = new AppDBContext())
                  {
                        foreach (var item in context.wallet)
                        {
                              Console.WriteLine(item);
                        }
                  }
            }

            private static void insertItem()
            {

                  var newitem = new wallet
                  {
                        holldername = "Adham",
                        balance = 5000,

                  };
                  using (var context = new AppDBContext())
                  {
                        context.wallet.Add(newitem);
                        context.SaveChanges();
                  }
            }
      }
}