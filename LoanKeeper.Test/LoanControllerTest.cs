using System.ComponentModel;
using NUnit.Framework;
using LoanKeeper.Core;
using System;
using System.Diagnostics;

namespace LoanKeeper.Test
{
	[TestFixture]
	public class LoanControllerTest
	{
		[Test]
		public void VerifyTest()
		{
			var collector = new LoanController();
			collector.VerifyInterestPayments();
		}

		[Test]
		public void VerifyWithoutInvestTest()
		{
			var collector = new LoanController();
			collector.VerifyInterestPayments(true);
		}

		[Test]
		public void CalculateTest()
		{
			var collector = new LoanController();
			collector.CalculateEndDate();
		}

		[Test]
		public void CalculationTest()
		{
			var collector = new LoanController();

			var payments =
				new[]
					{
						new Payment {PaymentDate = new DateTime(2007, 09, 04), Interest = 63.64m, Body = 6.36m},
						new Payment {PaymentDate = new DateTime(2007, 10, 05),		PayAmount = 660, HoursShift = 74},
						new Payment {PaymentDate = new DateTime(2007, 11, 02), Interest = 491.61m, Body = 158.39m},
						new Payment {PaymentDate = new DateTime(2007, 12, 06),		PayAmount = 650},
						new Payment {PaymentDate = new DateTime(2008, 01, 04),		PayAmount = 650},
						new Payment {PaymentDate = new DateTime(2008, 02, 07), Interest = 485.89m, Body = 214.11m},
						new Payment {PaymentDate = new DateTime(2008, 03, 07), Interest = 452.64m, Body = 247.36m, HoursShift = 2},
						new Payment {PaymentDate = new DateTime(2008, 04, 10), Interest = 481.20m, Body = 218.80m},
						new Payment {PaymentDate = new DateTime(2008, 05, 08), Interest = 463.54m, Body = 306.46m},
						new Payment {PaymentDate = new DateTime(2008, 06, 10), Interest = 475.68m, Body = 254.32m},
						new Payment {PaymentDate = new DateTime(2008, 07, 08), Interest = 457.72m, Body = 342.28m, HoursShift = -2},
						new Payment {PaymentDate = new DateTime(2008, 08, 01), Interest = 469.24m, Body = 280.76m},
						new Payment {PaymentDate = new DateTime(2008, 09, 08), Interest = 465.33m, Body = 274.67m},
						new Payment {PaymentDate = new DateTime(2008, 10, 06), Interest = 448.09m, Body = 251.91m},
						new Payment {PaymentDate = new DateTime(2008, 11, 10), Interest = 460.02m, Body = 239.98m, HoursShift = -2},
						new Payment {PaymentDate = new DateTime(2008, 12, 09), Interest = 442.96m, Body = 257.04m},
						new Payment {PaymentDate = new DateTime(2009, 01, 09), Interest = 454.86m, Body = 155.14m},
						new Payment {PaymentDate = new DateTime(2009, 01, 14),		PayAmount = 222.0m},
						new Payment {PaymentDate = new DateTime(2009, 02, 09), Interest = 451.47m, Body = 159.00m},
						new Payment {PaymentDate = new DateTime(2009, 03, 06), Interest = 405.34m, Body = 294.66m},
						new Payment {PaymentDate = new DateTime(2009, 04, 10), Interest = 445.57m, Body = 154.43m},
						new Payment {PaymentDate = new DateTime(2009, 05, 08),		PayAmount = 580.39m},
						new Payment {PaymentDate = new DateTime(2009, 06, 10), Interest = 442.08m, Body = 157.92m},
						new Payment {PaymentDate = new DateTime(2009, 07, 10), Interest = 426.29m, Body = 173.71m},
						new Payment {PaymentDate = new DateTime(2009, 08, 10), Interest = 438.64m, Body = 191.36m, HoursShift = 26},
						new Payment {PaymentDate = new DateTime(2009, 08, 11),		PayAmount = 170.00m},
						new Payment {PaymentDate = new DateTime(2009, 09, 10), Interest = 435.41m, Body = 364.59m},
						new Payment {PaymentDate = new DateTime(2009, 10, 09), Interest = 417.43m, Body = 382.57m, HoursShift = 2},
						new Payment {PaymentDate = new DateTime(2009, 11, 06), Interest = 427.05m, Body = 372.95m},
						new Payment {PaymentDate = new DateTime(2009, 12, 03), Interest = 408.93m, Body = 391.07m},
						new Payment {PaymentDate = new DateTime(2010, 01, 11), Interest = 417.88m, Body = 372.12m},
						new Payment {PaymentDate = new DateTime(2010, 02, 09), Interest = 414.85m, Body = 385.15m},
						new Payment {PaymentDate = new DateTime(2010, 03, 04), Interest = 370.80m, Body = 429.20m, HoursShift = -1},
						new Payment {PaymentDate = new DateTime(2010, 04, 01), Interest = 405.08m, Body = 394.92m},
						new Payment {PaymentDate = new DateTime(2010, 05, 06), Interest = 387.40m, Body = 412.60m},
						new Payment {PaymentDate = new DateTime(2010, 06, 02), Interest = 396.53m, Body = 403.47m},
						new Payment {PaymentDate = new DateTime(2010, 07, 01), Interest = 378.91m, Body = 421.09m},
						new Payment {PaymentDate = new DateTime(2010, 08, 03), Interest = 386.78m, Body = 613.22m},
						new Payment {PaymentDate = new DateTime(2010, 09, 01), Interest = 380.51m, Body = 619.49m},
						new Payment {PaymentDate = new DateTime(2010, 10, 01), Interest = 361.26m, Body = 638.74m},
						new Payment {PaymentDate = new DateTime(2010, 11, 01), Interest = 366.32m, Body = 633.68m},
						new Payment {PaymentDate = new DateTime(2010, 12, 10),		PayAmount = 400},
						new Payment {PaymentDate = new DateTime(2011, 01, 10), Interest = 358.98m, Body = 141.02m},
						new Payment {PaymentDate = new DateTime(2011, 02, 10), Interest = 357.72m, Body = 42.28m},
						new Payment {PaymentDate = new DateTime(2011, 02, 11),		PayAmount = 600.00m, HoursShift = -1},
						new Payment {PaymentDate = new DateTime(2011, 03, 04), Interest = 318.60m, Body = 681.40m},
						new Payment {PaymentDate = new DateTime(2011, 04, 08), Interest = 343.52m, Body = 56.48m, HoursShift = 10},
						new Payment {PaymentDate = new DateTime(2011, 05, 10), Interest = 331.29m, Body = 468.71m},
						new Payment {PaymentDate = new DateTime(2011, 06, 10), Interest = 338.54m, Body = 61.46m},
						new Payment {PaymentDate = new DateTime(2011, 06, 15),		PayAmount = 600.00m},
						new Payment {PaymentDate = new DateTime(2011, 07, 04), Interest = 322.34m, Body = 677.66m},
						new Payment {PaymentDate = new DateTime(2011, 08, 01),		PayAmount = 1000.00m},
						new Payment {PaymentDate = new DateTime(2011, 09, 01),		PayAmount = 1200.00m, HoursShift = -3},
						new Payment {PaymentDate = new DateTime(2011, 09, 26),		PayAmount = 1000.00m, HoursShift = 2},
						new Payment {PaymentDate = new DateTime(2011, 10, 03), Interest = 293.71m, Body = 6.29m},
						new Payment {PaymentDate = new DateTime(2011, 10, 14),		PayAmount = 1000.00m},
						new Payment {PaymentDate = new DateTime(2011, 11, 10), Interest = 287.98m, Body = 12.02m},
						new Payment {PaymentDate = new DateTime(2011, 11, 17),		PayAmount = 1100.00m},
						new Payment {PaymentDate = new DateTime(2011, 12, 09), Interest = 268.72m, Body = 31.28m, HoursShift = -2},
						new Payment {PaymentDate = new DateTime(2011, 12, 20),		PayAmount = 1100.00m },
						new Payment {PaymentDate = new DateTime(2012, 01, 04), Interest = 266.31m, Body = 33.69m},
						new Payment {PaymentDate = new DateTime(2012, 01, 19),		PayAmount = 1300.00m},
						new Payment {PaymentDate = new DateTime(2012, 02, 08), Interest = 252.56m, Body = 47.44m, HoursShift = 2},
						new Payment {PaymentDate = new DateTime(2012, 02, 17), PayAmount = 1600.00m},
						new Payment {PaymentDate = new DateTime(2012, 03, 02), Interest = 220.81m, Body = 79.19m},
						new Payment {PaymentDate = new DateTime(2012, 03, 15), PayAmount = 1900.00m},
						new Payment {PaymentDate = new DateTime(2012, 04, 05), Interest = 214.02m, Body = 85.98m},
						new Payment {PaymentDate = new DateTime(2012, 04, 18), PayAmount = 700.00m},
						new Payment {PaymentDate = new DateTime(2012, 05, 04), Interest = 194.01m, Body = 105.99m},
						new Payment {PaymentDate = new DateTime(2012, 05, 07), PayAmount = 2000.00m},
						new Payment {PaymentDate = new DateTime(2012, 06, 08), Interest = 177.33m, Body = 330.77m, InvestGrn = 5000m, Rate = 8.105m},

						new Payment {PaymentDate = new DateTime(2012, 07, 10), PayAmount = 1800.00m, Invest= 500},
						new Payment {PaymentDate = new DateTime(2012, 08, 10), PayAmount = 1800.00m, Invest= 500},
						new Payment {PaymentDate = new DateTime(2012, 09, 10), PayAmount = 1800.00m, Invest= 500},
						
						new Payment {PaymentDate = new DateTime(2012, 10, 10), PayAmount = 1800.00m, Invest= 500},
						new Payment {PaymentDate = new DateTime(2012, 11, 10), PayAmount = 1800.00m, Invest= 500},
						new Payment {PaymentDate = new DateTime(2012, 12, 10), PayAmount = 1800.00m, Invest= 500},
						
						new Payment {PaymentDate = new DateTime(2013, 01, 10), PayAmount = 2000.00m, Invest= 500},
						new Payment {PaymentDate = new DateTime(2013, 02, 10), PayAmount = 2000.00m, Invest= 500},
						new Payment {PaymentDate = new DateTime(2013, 03, 10), PayAmount = 2000.00m, Invest= 500}

					};

			MonthPayment[] monthPayments = collector.Calculate(payments, new DateTime(2007, 08, 28), 45100);

			MonthPayment prev = null;
			bool todayPrined = false;
			decimal totalInterest = 0;
			decimal totalPaid = 0;

			foreach (var m in monthPayments)
			{
				decimal body = prev != null ? m.Paid - prev.Interest : 0;
				decimal interest = prev != null ? prev.Interest : 0;
				decimal debt = prev != null ? m.Debt - m.Paid + prev.Interest : 41500;

				if (m.Date > DateTime.Today && todayPrined == false)
				{
					Trace.WriteLine("");
					Trace.WriteLine("For today:");
					Trace.WriteLine("----------");
					Trace.WriteLine(string.Format("Total paid:\t\t{0,12:0.00}\nTotal body:\t\t{1,12:0.00}\nTotal interest:\t{2,12:0.00}", totalPaid, totalPaid - totalInterest, totalInterest));
					Trace.WriteLine("");
					todayPrined = true;
				}

				totalInterest += interest;
				totalPaid += m.Paid;

				Trace.WriteLine(
					string.Format(
						"{0,15:MMMM yyyy} {1,12:0.00} {2,9:0.00} {3,9:0.00} {4,9:0.00} {5}",
						m.Date, debt, interest, body, m.Paid, m.InvalidCalculation ? "+" : ""));

				prev = m;
			}
		}
	}
}
