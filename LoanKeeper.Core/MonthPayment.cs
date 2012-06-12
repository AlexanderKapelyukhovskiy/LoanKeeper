using System;

namespace LoanKeeper.Core
{
	public class MonthPayment
	{
		public DateTime Date { get; set; }
		public decimal Interest { get; set; }
		public decimal Paid { get; set; }
		public decimal Debt { get; set; }
		public decimal Invest { get; set; }
		public decimal InvestGrn { get; set; }
		public Payment[] Payments { get; set; }

		public bool InvalidCalculation { get; set; }
	}
}