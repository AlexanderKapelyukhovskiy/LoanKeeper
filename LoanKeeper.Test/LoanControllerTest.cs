using System;
using NUnit.Framework;
using LoanKeeper.Core;

namespace LoanKeeper.Test
{
	[TestFixture]
	public class LoanControllerTest
	{
		[Test]
		public void CalculationTest()
		{
			var collector = new LoanController();
			MonthPayment[] monthPayments = collector.Calculate(LoanController.Payments, new DateTime(2007, 08, 28), 45100);
			LoanController.PrintPayments(monthPayments);
		}

		[Test]
		public void CalculationWithPaymentsDetailsTest()
		{
			var collector = new LoanController();
			MonthPayment[] monthPayments = collector.Calculate(LoanController.Payments, new DateTime(2007, 08, 28), 45100);
			LoanController.PrintPayments(monthPayments, true);
		}

		[Test]
		public void CalculationWitoutInvestTest()
		{
			var collector = new LoanController();
			MonthPayment[] monthPayments = collector.Calculate(LoanController.Payments, new DateTime(2007, 08, 28), 45100, false);
			LoanController.PrintPayments(monthPayments);
		}
	}
}
