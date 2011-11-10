using System;
using System.Diagnostics;

namespace LoanKeeper.Core
{
	public class MountlyPayment
	{
		public Payment[] Payments { get; set; }
	}

	public class Payment
	{
		public DateTime PaymentDate { get; set; }
		public int HoursShift { get; set; }

		public decimal? Body { get; set; }
		public decimal? Interest { get; set; }

		private decimal _payAmount;
		public decimal PayAmount
		{
			get
			{
				if (Body != null && Interest != null)
					return Body.Value + Interest.Value;

				return _payAmount;
			}
			set { _payAmount = value; }
		}
	}

	public class LoanController
	{
		public void CalculateEndDate()
		{
			//const decimal startDebt = 27918.65761m;
			const decimal startDebt = 25913.02m;
			var startdate = new DateTime(2011, 10, 01);

			CalculateEndDate(startdate, startDebt, 1800);
			CalculateEndDate(startdate, startDebt, 1900);
			CalculateEndDate(startdate, startDebt, 2000);
		}

		private static void CalculateEndDate(DateTime startDate, decimal startDebt, decimal payMonthly)
		{
			const bool printDetails = true;

			decimal debt = startDebt;

			Trace.WriteLineIf(printDetails, string.Format("Pay for month {0}", payMonthly));
			Trace.WriteLineIf(printDetails, "========================================");
			

			decimal overPay = 0;
			while (debt > 0)
			{
				int daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);
				DateTime payDate = startDate.AddMonths(1);

				Trace.WriteLineIf(printDetails, string.Format("Owe for {0:dd MMMM yyyy}: {1:0.00}", payDate, debt));

				decimal interest = 12.7m / 360 * daysInMonth;

				decimal toPay = debt * interest / 100;
				overPay += toPay;

				Trace.WriteLineIf(printDetails, string.Format("Interest of bank for {1} days = {0:0.00}", toPay, daysInMonth));
				Trace.WriteLineIf(printDetails,"");
				
				debt = debt - payMonthly + toPay;

				startDate = payDate;
			}

			Trace.WriteLine(string.Format("Monthly - [{1:0.00}] \t Overpay - [{2:0.00}] \t End - [{0:yyyy MMMM}]", startDate, payMonthly, overPay));

			Trace.WriteLineIf(printDetails,"");
		}

		public void VerifyInterestPayments()
		{
			decimal amount = 45100;
			decimal interest = 0;
			decimal allInterest = 0;
			const decimal interestPerHour = 12.7m / (24 * 360 * 100);

			var beginOfPeriod = new DateTime(2007, 08, 28);

			var payments =
				new[]
					{
						new MountlyPayment(),
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2007, 09, 04), Interest = 63.64m, Body = 6.36m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2007, 10, 05), PayAmount = 660,					HoursShift = 74}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2007, 11, 02), Interest = 491.61m, Body = 158.39m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2007, 12, 06), PayAmount = 650}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2008, 01, 04), PayAmount = 650}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2008, 02, 07), Interest = 485.89m, Body = 214.11m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2008, 03, 07), Interest = 452.64m, Body = 247.36m, HoursShift = 2}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2008, 04, 10), Interest = 481.20m, Body = 218.80m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2008, 05, 08), Interest = 463.54m, Body = 306.46m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2008, 06, 10), Interest = 475.68m, Body = 254.32m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2008, 07, 08), Interest = 457.72m, Body = 342.28m, HoursShift = -2}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2008, 08, 01), Interest = 469.24m, Body = 280.76m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2008, 09, 08), Interest = 465.33m, Body = 274.67m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2008, 10, 06), Interest = 448.09m, Body = 251.91m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2008, 11, 10), Interest = 460.02m, Body = 239.98m, HoursShift = -2}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2008, 12, 09), Interest = 442.96m, Body = 257.04m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2009, 01, 09), Interest = 454.86m, Body = 155.14m},
							new Payment {PaymentDate = new DateTime(2009, 01, 14), PayAmount = 222.0m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2009, 02, 9), Interest = 451.47m, Body = 159.00m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2009, 03, 6), Interest = 405.34m, Body = 294.66m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2009, 04, 10), Interest = 445.57m, Body = 154.43m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2009, 05, 08), PayAmount = 580.39m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2009, 06, 10), Interest = 442.08m, Body = 157.92m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2009, 07, 10), Interest = 426.29m, Body = 173.71m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2009, 08, 10), Interest = 438.64m, Body = 191.36m, HoursShift = 26},
							new Payment {PaymentDate = new DateTime(2009, 08, 11), PayAmount = 170.00m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2009, 09, 10), Interest = 435.41m, Body = 364.59m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2009, 10, 09), Interest = 417.43m, Body = 382.57m, HoursShift = 2}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2009, 11, 06), Interest = 427.05m, Body = 372.95m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2009, 12, 03), Interest = 408.93m, Body = 391.07m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2010, 01, 11), Interest = 417.88m, Body = 372.12m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2010, 02, 09), Interest = 414.85m, Body = 385.15m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2010, 03, 04), Interest = 370.80m, Body = 429.20m, HoursShift = -1}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2010, 04, 01), Interest = 405.08m, Body = 394.92m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2010, 05, 06), Interest = 387.40m, Body = 412.60m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2010, 06, 02), Interest = 396.53m, Body = 403.47m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2010, 07, 01), Interest = 378.91m, Body = 421.09m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2010, 08, 03), Interest = 386.78m, Body = 613.22m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2010, 09, 01), Interest = 380.51m, Body = 619.49m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2010, 10, 01), Interest = 361.26m, Body = 638.74m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2010, 11, 01), Interest = 366.32m, Body = 633.68m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2010, 12, 10), PayAmount = 400}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2011, 01, 10), Interest = 358.98m, Body = 141.02m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2011, 02, 10), Interest = 357.72m, Body = 42.28m},
							new Payment {PaymentDate = new DateTime(2011, 02, 11), PayAmount = 600.00m, HoursShift = -1}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2011, 03, 04), Interest = 318.60m, Body = 681.40m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2011, 04, 08), Interest = 343.52m, Body = 56.48m, HoursShift = 10}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2011, 05, 10), Interest = 331.29m, Body = 468.71m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2011, 06, 10), Interest = 338.54m, Body = 61.46m},
							new Payment {PaymentDate = new DateTime(2011, 06, 15), PayAmount = 600.00m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2011, 07, 04), Interest = 322.34m, Body = 677.66m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2011, 08, 01), PayAmount = 1000.00m}}},
						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2011, 09, 01), PayAmount = 1200.00m, HoursShift = -3},
							new Payment {PaymentDate = new DateTime(2011, 09, 26), PayAmount = 1000.00m, HoursShift = 2}}},

						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2011, 10, 03), Interest=293.71m, Body = 6.29m,},
							new Payment {PaymentDate = new DateTime(2011, 10, 14), PayAmount = 1000.00m}}},

						new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2011, 11, 10), PayAmount = 300.00m},
							new Payment {PaymentDate = new DateTime(2011, 11, 14), PayAmount = 0000.00m}}},

						//new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2011, 12, 10), PayAmount = 1800.00m}}},

						//new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2012, 01, 10), PayAmount = 1800.00m}}},
						//new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2012, 02, 10), PayAmount = 1800.00m}}},
						//new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2012, 03, 10), PayAmount = 1800.00m}}},
						//new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2012, 04, 10), PayAmount = 1800.00m}}},
						//new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2012, 05, 10), PayAmount = 1800.00m}}},
						//new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2012, 06, 10), PayAmount = 1800.00m}}},
						//new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2012, 07, 10), PayAmount = 1800.00m}}},
						//new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2012, 08, 10), PayAmount = 1800.00m}}},
						//new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2012, 09, 10), PayAmount = 1800.00m}}},

						//new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2012, 10, 10), PayAmount = 1800.00m}}},
						//new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2012, 11, 10), PayAmount = 1800.00m}}},
						//new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2012, 12, 10), PayAmount = 1800.00m}}},

						//new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2013, 01, 10), PayAmount = 1800.00m}}},
						//new MountlyPayment {Payments = new[] {new Payment {PaymentDate = new DateTime(2013, 02, 10), PayAmount = 1800.00m}}},
					
					};

			foreach (var mountlyPayment in payments)
			{
				decimal initialInterest = interest;

				Trace.Write(string.Format("{0,15:MMMM yyyy}\tamount: {1,8:0.00}", beginOfPeriod, amount));

				decimal nextInterest = 0;
				decimal tempPaidAmount = 0;

				if (mountlyPayment.Payments != null)
				{
					foreach (var payment in mountlyPayment.Payments)
					{
						tempPaidAmount += payment.PayAmount;
						decimal diff;
						if (payment.Interest != null && Math.Abs(diff = payment.Interest.Value - interest) >= 0.01m)
							Trace.WriteLine(string.Format("Warning!!! Interest diff is {0} on {1:yyyy MM dd}", diff, payment.PaymentDate));

						DateTime tempPaymentDate = payment.PaymentDate.Date;

						if (payment.HoursShift != 0)
							tempPaymentDate = tempPaymentDate.AddHours(payment.HoursShift);

						var hours = (decimal)(tempPaymentDate - beginOfPeriod).TotalHours;
						nextInterest += amount * interestPerHour * hours;

						if (payment.PayAmount > interest)
						{
							amount -= (payment.PayAmount - interest);
							interest = 0;
						}
						else
						{
							interest -= payment.PayAmount;
						}

						beginOfPeriod = tempPaymentDate;
					}
				}

				Trace.WriteLine(string.Format("\tpaid: {1,7:0.00}\tinterest: {2,6:0.00}\tbody: {0,7:0.00}", tempPaidAmount - initialInterest, tempPaidAmount, initialInterest));

				DateTime nextFirstDay = new DateTime(beginOfPeriod.Year, beginOfPeriod.Month, 1).AddMonths(1);
				nextInterest += amount * interestPerHour * (decimal)(nextFirstDay - beginOfPeriod).TotalHours;

				interest = Math.Round(nextInterest, 2);
				allInterest += interest;
				beginOfPeriod = nextFirstDay;
			}

			Trace.WriteLine("");
			Trace.WriteLine(string.Format("Amount: {0:0.00}\tAll interest: {1:0.00}", amount, allInterest));

		}
	}
}
