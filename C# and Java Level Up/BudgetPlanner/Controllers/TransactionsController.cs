using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BudgetPlanner.Database;
using BudgetPlanner.Models;
using BudgetPlanner.Functions;

namespace BudgetPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly DBManager _context;

        public TransactionsController(DBManager context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transactions>>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }

        // GET: api/Transactions/[token] : api/Transactions/5
        [HttpGet("{token}")]
        public async Task<List<Transactions>> GetTransactionsByUser(int token)
        {
            var transactions = await _context.Transactions.Where(x => x.Token == token).ToListAsync();


            if (transactions == null)
            {
                return new List<Transactions>();
            }

            return transactions;
        }

        // GET: api/Transactions/[token][categoryID] : api/Transactions/5/1
        [HttpGet("params")]
        public async Task<List<Transactions>> GetTransactionsByUserCategory(int token, int categoryID)
        {
            var transactions = await _context.Transactions.Where(x => x.Token == token && x.CategoryID == categoryID).ToListAsync();


            if (transactions == null)
            {
                return new List<Transactions>();
            }

            return transactions;
        }

        // GET: api/Transactions/[accountID] : api/Transactions/1
        [HttpGet("params")]
        public async Task<List<Transactions>> GetTransactionsByAccount(int accountID)
        {
            var transactions = await _context.Transactions.Where(x => x.AccountID == accountID).ToListAsync();


            if (transactions == null)
            {
                return new List<Transactions>();
            }

            return transactions;
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactions(int id, Transactions transactions)
        {
            if (id != transactions.TransactionID)
            {
                return BadRequest();
            }

            _context.Entry(transactions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transactions>> PostTransactions(Transactions transactions)
        {

          // Console.WriteLine("awe");

            _context.Transactions.Add(transactions);
            await _context.SaveChangesAsync();
           // var deserialized = serializer.Deserialize<List<TheType>>(TheJson);
            //transactionsRepository trans = new transactionsRepository();
            //trans.AddTransaction(transactions.TransactionAmount, transactions.AccountID, transactions.CategoryID, transactions.Token, transactions.TransactionDate);

            return CreatedAtAction("GetTransactions", new { id = transactions.TransactionID }, transactions);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactions(int id)
        {
            var transactions = await _context.Transactions.FindAsync(id);
            if (transactions == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transactions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionsExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionID == id);
        }
    }
}
