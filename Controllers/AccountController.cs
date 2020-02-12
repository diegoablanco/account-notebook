using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AccountingApi.Models;

namespace AccountingApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountingContext _context;

        public AccountController(AccountingContext context)
        {
            _context = context;
        }

        // GET: api
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        // GET: api/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(long id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // POST: api
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
        {
            var account = _context.Accounts.First();
            TransactionType transactionType;

            if (Enum.TryParse(transaction.Type, out transactionType) && transactionType == TransactionType.debit)
            {
                if (account.Balance < transaction.Amount)
                    return BadRequest("Account balance is unsufficient to perform the operation");

                account.Balance -= transaction.Amount;
            }
            else
                account.Balance += transaction.Amount;

            _context.Transactions.Add(transaction);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);
        }
    }
}
