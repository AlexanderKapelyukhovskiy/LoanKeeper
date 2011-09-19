using System;
using System.Diagnostics;
using NUnit.Framework;
using LoanKeeper.Core;

namespace LoanKeeper.Test
{
	[TestFixture]
	public class DataCollectorTest
	{
		[Test]
		public void VerifyTest()
		{
			DataCollector collector = new DataCollector();
			collector.VerifyPayments();
		}

		[Test]
		public void CalculateTest()
		{
			DataCollector collector = new DataCollector();
			collector.MyCreditTest();
		}
	}
}
