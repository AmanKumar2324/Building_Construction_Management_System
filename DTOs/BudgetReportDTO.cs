namespace Building_Construction_Management_System.DTOs
{
    public class BudgetReportDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public decimal Budget { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal RemainingBudget { get; set; }
    }
}
