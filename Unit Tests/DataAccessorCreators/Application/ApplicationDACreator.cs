using NSubstitute;
using Ranked.Data.Application.Requests.Interfaces;
using Ranked.Data.Common.DTOs;
using Ranked.DataAccessors.Application.Interfaces;
using TestRig.Extensions;


namespace Unit_Tests.DataAccessorCreators.Application
{
	using Data;


	internal static class ApplicationDACreator
	{
		public static IApplicationDA CreateApplicationDA()
		{
			var da = Substitute.For<IApplicationDA>();

			da.Create(Arg.Any<ICreateApplicationRequest>())
				.Returns(true);

			da.Read()
				.Returns(new List<NameGuidDTO>()
				{
					new()
					{
						Name = AppConsts.APP_NAME,
						Guid = new Guid(AppConsts.APP_GUID)
					}
				}.AsEFTestQueryable());

			return da;
		}
	}
}
