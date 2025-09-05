using System.Security.Claims;


namespace Ranked.Data.Security
{
	/// <summary>
	/// Policy name and associated claim used to add to authorization setup
	/// </summary>
	public class PolicyClaim
	{
		/// <summary>
		/// Name of the policy
		/// </summary>
		public string PolicyName { get; }

		/// <summary>
		/// The associated Claim
		/// </summary>
		public Claim Claim { get; }


		/// <summary>
		/// Constructor for <see cref="PolicyClaim"/>
		/// </summary>
		/// <param name="policyName">Name of the policy</param>
		/// <param name="claim">The associated Claim</param>
		public PolicyClaim(string policyName, Claim claim)
		{
			PolicyName = policyName;
			Claim = claim;
		}
	}
}
