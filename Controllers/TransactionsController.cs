using Expenses.API.Data;
using Expenses.API.Data.Services;
using Expenses.API.Dtos;
using Expenses.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController(ITransactionsService transactionService) : ControllerBase
    {
       
        [HttpPost("Create")]
        public IActionResult CreateTransaction([FromBody] PostTransactionDto payload)
        {
            var newTransaction = transactionService.Create(payload);
            return Ok(newTransaction);
        }

        [HttpGet("All")]
        public IActionResult GetAllTransactions()
        {
            var transactions = transactionService.GetAllList();
            return Ok(transactions);
        }

        [HttpGet("Details/{Id}")]
        public IActionResult GetTransactionById(int Id)
        {
            var transaction = transactionService.GetById(Id);
            if (transaction == null) return NotFound();
            return Ok(transaction);
        }

        [HttpPut("Update/{Id}")]
        public IActionResult UpdateTransaction(int Id, [FromBody] PutTransactionDto payload)
        {
            var updatedTransaction = transactionService.Update(Id, payload);
            if (updatedTransaction == null) return NotFound();
            return Ok(updatedTransaction);
        }

        [HttpDelete("Delete/{Id}")]
        public IActionResult DeleteTransaction(int Id)
        {
            transactionService.Delete(Id);
            return Ok();
        }
    }
}
