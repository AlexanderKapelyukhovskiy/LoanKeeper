using NUnit.Framework;
using LoanKeeper.Core;

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
		public void CalculateTest()
		{
			var collector = new LoanController();
			collector.CalculateEndDate();
		}
	}
}
