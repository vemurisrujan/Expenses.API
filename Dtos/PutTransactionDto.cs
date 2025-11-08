using System.ComponentModel.DataAnnotations;

namespace Expenses.API.Dtos
{
    public class PutTransactionDto
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
