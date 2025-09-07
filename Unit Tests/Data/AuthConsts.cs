using System.Security.Claims;


namespace Unit_Tests.Data
{
	internal class AuthConsts
	{
		public const string SUBJECT = "Subject";
		public const string PASSWORD = "password";

		public const string CLAIM_TYPE = "Claim Type";
		public const string CLAIM_VALUE = "Claim Value";

		public const string JWT_ISSUER = "Issuer";
		public const string JWT_AUDIENCE = "Audience";
		public const string JWT_SECURITY_KEY = "Security Key - This needs to be at least 128 bits long";


		public static Claim Claim = new(CLAIM_TYPE, CLAIM_VALUE);
	}
}
