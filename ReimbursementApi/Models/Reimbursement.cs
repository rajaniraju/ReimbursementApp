namespace ReimbursementApi.Models
{
    public class Reimbursement
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string ReceiptFileName { get; set; }  // Store filename or URL
    }
}
