using Expenses.API.Dtos;
using Expenses.API.Models;

namespace Expenses.API.Data.Services
{
    public interface ITransactionsService
    {
        List<Transaction> GetAllList();
        Transaction? GetById(int id);
        Transaction Create(PostTransactionDto transaction);
        Transaction? Update(int id, PutTransactionDto transaction);
        void Delete(int id);

    }

    public class TransactionsService(AppDbContext context) : ITransactionsService
    {
        public List<Transaction> GetAllList()
        {
            return context.Transactions.ToList();
        }

        public Transaction? GetById(int id)
        {
            var transactionDb = context.Transactions.FirstOrDefault(n => n.Id == id);
            return transactionDb;
        }

        public Transaction Create(PostTransactionDto transaction)
        {
            var newTransaction = new Transaction
            {
                Type = transaction.Type,
                Amount = transaction.Amount,
                Category = transaction.Category,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Transactions.Add(newTransaction);
            context.SaveChanges();
            return newTransaction;
        }

        public Transaction? Update(int id, PutTransactionDto transaction)
        {
            var transactionDb = context.Transactions.FirstOrDefault(n => n.Id == id);
            if (transactionDb != null)
            {
                transactionDb.Type = transaction.Type;
                transactionDb.Amount = transaction.Amount;
                transactionDb.Category = transaction.Category;
                transactionDb.UpdatedAt = DateTime.UtcNow;

                context.Transactions.Update(transactionDb);
                context.SaveChanges();
            }

            return transactionDb;
        }

        public void Delete(int id)
        {
            var transactionDb = context.Transactions.FirstOrDefault(n => n.Id == id);
            if (transactionDb != null)
            {
                context.Transactions.Remove(transactionDb);
                context.SaveChanges();
            }
        }
    }
}
