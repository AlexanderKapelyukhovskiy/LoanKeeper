using System;

namespace LoanKeeper.Core
{
	public class Payment : ICloneable
	{
		public DateTime PaymentDate { get; set; }
		public int HoursShift { get; set; }

		public decimal? Body { get; set; }
		public decimal? Interest { get; set; }

		private decimal _invest;
		public decimal Invest
		{
			get
			{
				if (_invest == 0 && Rate != 0)
					return InvestGrn/Rate;

				return _invest;
			}
			set { _invest = value; }
		}

		public decimal InvestGrn { get; set; }

		public decimal Rate { get; set; }

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

		public bool DebtReturn { get; set; }

		public DateTime PaymentDateWithShift
		{
			get
			{
				DateTime paymentdate = PaymentDate.Date;

				if (HoursShift != 0)
					paymentdate = paymentdate.AddHours(HoursShift);

				return paymentdate;
			}
		}

		public Payment Clone()
		{
			return MemberwiseClone() as Payment;
		}

		object ICloneable.Clone()
		{
			return Clone();
		}
	}
}