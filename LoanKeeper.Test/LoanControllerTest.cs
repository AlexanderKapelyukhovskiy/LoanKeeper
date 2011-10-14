using NUnit.Framework;
using LoanKeeper.Core;
using System.Text.RegularExpressions;

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

		[Test]
		public void t1()
		{
			string xml = @"<Messages xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns='http://tempuri.net/Wonga.Payments' xmlns:baseType='Wonga.Api.Command'>
  <CreateFixedTermLoanApplication>
    <AccountId>4e941811-e588-409d-9af8-3392c0a8192d</AccountId>
    <ApplicationId>4e941821-8ba4-4380-8ce2-3392c0a8192d</ApplicationId>
    <PaymentCardId>4e941821-69a8-46e2-b48f-3392c0a8192d</PaymentCardId>
    <BankAccountId>4e941821-5d8c-4f1c-bb7f-3392c0a8192d</BankAccountId>
    <Currency>ZAR</Currency>
    <PromiseDate>2011-10-21T00:00:00</PromiseDate>
    <LoanAmount>1000</LoanAmount>
    <PromoCodeId>null</PromoCodeId>
    <AffiliateId />
    <CreatedOn>2011-10-11T10:19:05.206655Z</CreatedOn>
    <ClientId>4e8343eb-ed84-4b71-a6f7-197d1dd30a57</ClientId>
  </CreateFixedTermLoanApplication>
</Messages>";
			string pattern = string.Format("<ClientId>{0}</ClientId>", ".*");
			xml = Regex.Replace(xml, pattern, "");

			
			System.Diagnostics.Trace.WriteLine(xml);

		}
	}
}
