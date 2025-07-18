using Ranked.Data.Elo.DTOs;


namespace Unit_Tests.Providers.Elo
{
	internal static class EloCalculatorTestCaseSources
	{
		public static IEnumerable<TestCaseData> Calculate1V1TestCaseSource
		{
			get
			{
				// K = 0
				yield return new TestCaseData((1500, 1500), 0, (1500, 1500));
				yield return new TestCaseData((1600, 1400), 0, (1600, 1400));
				yield return new TestCaseData((0, 0), 0, (0, 0));

				// K = 16
				yield return new TestCaseData((1500, 1500), 16, (1508, 1492));
				yield return new TestCaseData((1400, 1600), 16, (1412, 1588));
				yield return new TestCaseData((1000, 1000), 16, (1008, 992));

				// K = 32
				yield return new TestCaseData((1500, 1500), 32, (1516, 1484));
				yield return new TestCaseData((1600, 1400), 32, (1608, 1392));
				yield return new TestCaseData((1400, 1600), 32, (1424, 1576));
				yield return new TestCaseData((2000, 1800), 32, (2008, 1792));
				yield return new TestCaseData((1800, 2000), 32, (1824, 1976));
				yield return new TestCaseData((1000, 1000), 32, (1016, 984));
				yield return new TestCaseData((2500, 2400), 32, (2512, 2388));
				yield return new TestCaseData((2400, 2500), 32, (2420, 2480));
				yield return new TestCaseData((0, 0), 32, (16, 0));
				yield return new TestCaseData((0, 1500), 32, (32, 1468));
				yield return new TestCaseData((1500, 0), 32, (1500, 0));
				yield return new TestCaseData((10, 10), 32, (26, 0));
				yield return new TestCaseData((300, 50), 32, (306, 44));
				yield return new TestCaseData((100, 100), 32, (116, 84));

				// K = 64
				yield return new TestCaseData((1500, 1500), 64, (1532, 1468));
				yield return new TestCaseData((2000, 1800), 64, (2015, 1785));
				yield return new TestCaseData((0, 1500), 64, (64, 1436));
				yield return new TestCaseData((10, 10), 64, (42, 0));
			}
		}

		public static IEnumerable<TestCaseData> CalculateElosTestCaseSource
		{
			get
			{
				// K = 8
				yield return new TestCaseData(
					new List<UserEloDTO> { new() { User = "User1", Elo = 2000 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 1800 } },
					8,
					new List<UserEloDTO> { new() { User = "User1", Elo = 2002 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 1798 } });

				// K = 16
				yield return new TestCaseData(
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1300 },
						new() { User = "User2", Elo = 1350 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 1100 },
					},
					16,
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1303 },
						new() { User = "User2", Elo = 1353 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 1097 },
					});

				// K = 24
				yield return new TestCaseData(
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 900 },
						new() { User = "User2", Elo = 1100 },
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 1200 },
						new() { User = "User4", Elo = 1200 },
						new() { User = "User5", Elo = 1200 }
					},
					24,
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 918 },
						new() { User = "User2", Elo = 1118 },
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 1182 },
						new() { User = "User4", Elo = 1182 },
						new() { User = "User5", Elo = 1182 }
					});


				// K = 32
				yield return new TestCaseData(
					new List<UserEloDTO> { },
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1200 },
						new() { User = "User2", Elo = 1200 }
					},
					32,
					new List<UserEloDTO> { },
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1200 },
						new() { User = "User2", Elo = 1200 }
					});

				yield return new TestCaseData(
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1200 },
						new() { User = "User2", Elo = 1200 }
					},
					new List<UserEloDTO> { },
					32,
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1200 },
						new() { User = "User2", Elo = 1200 }
					},
					new List<UserEloDTO> { });

				yield return new TestCaseData(
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1200 },
						new() { User = "User2", Elo = 1200 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 1200 },
						new() { User = "User4", Elo = 1200 }
					},
					32,
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1216 },
						new() { User = "User2", Elo = 1216 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 1184 },
						new() { User = "User4", Elo = 1184 }
					});

				yield return new TestCaseData(
					new List<UserEloDTO> { new() { User = "User1", Elo = 1500 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 1000 } },
					32,
					new List<UserEloDTO> { new() { User = "User1", Elo = 1502 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 998 } });

				yield return new TestCaseData(
					new List<UserEloDTO> { new() { User = "User1", Elo = 1000 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 1500 } },
					32,
					new List<UserEloDTO> { new() { User = "User1", Elo = 1030 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 1470 } });

				yield return new TestCaseData(
					new List<UserEloDTO> { new() { User = "User1", Elo = 0 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 0 } },
					32,
					new List<UserEloDTO> { new() { User = "User1", Elo = 16 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 0 } });

				yield return new TestCaseData(
					new List<UserEloDTO> { new() { User = "User1", Elo = 3000 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 2500 } },
					32,
					new List<UserEloDTO> { new() { User = "User1", Elo = 3002 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 2498 } });

				// K = 48
				yield return new TestCaseData(
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1000 },
						new() { User = "User2", Elo = 1200 },
						new() { User = "User3", Elo = 1400 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User4", Elo = 1300 },
						new() { User = "User5", Elo = 1300 },
					},
					48,
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1031 },
						new() { User = "User2", Elo = 1231 },
						new() { User = "User3", Elo = 1431 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User4", Elo = 1269 },
						new() { User = "User5", Elo = 1269 },
					});

				// K = 64
				yield return new TestCaseData(
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1000 },
						new() { User = "User2", Elo = 1000 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 1000 },
						new() { User = "User4", Elo = 1000 }
					},
					64,
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1032 },
						new() { User = "User2", Elo = 1032 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 968 },
						new() { User = "User4", Elo = 968 }
					});
			}
		}

		public static IEnumerable<TestCaseData> CalculateWeightedElosTestCaseSource
		{
			get
			{
				// K = 8
				yield return new TestCaseData(
					new List<UserEloDTO> { new() { User = "User1", Elo = 2000 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 1800 } },
					8,
					new List<UserEloDTO> { new() { User = "User1", Elo = 2002 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 1798 } });

				// K = 16
				yield return new TestCaseData(
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1300 },
						new() { User = "User2", Elo = 1350 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 1100 },
					},
					16,
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1300 },
						new() { User = "User2", Elo = 1350 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 1100 },
					});

				// K = 24
				yield return new TestCaseData(
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 900 },
						new() { User = "User2", Elo = 1100 },
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 1200 },
						new() { User = "User4", Elo = 1200 },
						new() { User = "User5", Elo = 1200 }
					},
					24,
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 923 },
						new() { User = "User2", Elo = 1123 },
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 1177 },
						new() { User = "User4", Elo = 1177 },
						new() { User = "User5", Elo = 1177 }
					});


				// K = 32
				yield return new TestCaseData(
					new List<UserEloDTO> { },
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1200 },
						new() { User = "User2", Elo = 1200 }
					},
					32,
					new List<UserEloDTO> { },
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1200 },
						new() { User = "User2", Elo = 1200 }
					});

				yield return new TestCaseData(
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1200 },
						new() { User = "User2", Elo = 1200 }
					},
					new List<UserEloDTO> { },
					32,
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1200 },
						new() { User = "User2", Elo = 1200 }
					},
					new List<UserEloDTO> { });

				yield return new TestCaseData(
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1200 },
						new() { User = "User2", Elo = 1200 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 1200 },
						new() { User = "User4", Elo = 1200 }
					},
					32,
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1216 },
						new() { User = "User2", Elo = 1216 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 1184 },
						new() { User = "User4", Elo = 1184 }
					});

				yield return new TestCaseData(
					new List<UserEloDTO> { new() { User = "User1", Elo = 1500 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 1000 } },
					32,
					new List<UserEloDTO> { new() { User = "User1", Elo = 1502 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 998 } });

				yield return new TestCaseData(
					new List<UserEloDTO> { new() { User = "User1", Elo = 1000 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 1500 } },
					32,
					new List<UserEloDTO> { new() { User = "User1", Elo = 1030 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 1470 } });

				yield return new TestCaseData(
					new List<UserEloDTO> { new() { User = "User1", Elo = 0 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 0 } },
					32,
					new List<UserEloDTO> { new() { User = "User1", Elo = 16 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 0 } });

				yield return new TestCaseData(
					new List<UserEloDTO> { new() { User = "User1", Elo = 3000 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 2500 } },
					32,
					new List<UserEloDTO> { new() { User = "User1", Elo = 3002 } },
					new List<UserEloDTO> { new() { User = "User2", Elo = 2498 } });

				// K = 48
				yield return new TestCaseData(
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1000 },
						new() { User = "User2", Elo = 1200 },
						new() { User = "User3", Elo = 1400 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User4", Elo = 1300 },
						new() { User = "User5", Elo = 1300 },
					},
					48,
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1006 },
						new() { User = "User2", Elo = 1206 },
						new() { User = "User3", Elo = 1406 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User4", Elo = 1294 },
						new() { User = "User5", Elo = 1294 },
					});

				// K = 64
				yield return new TestCaseData(
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1000 },
						new() { User = "User2", Elo = 1000 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 1000 },
						new() { User = "User4", Elo = 1000 }
					},
					64,
					new List<UserEloDTO>
					{
						new() { User = "User1", Elo = 1032 },
						new() { User = "User2", Elo = 1032 }
					},
					new List<UserEloDTO>
					{
						new() { User = "User3", Elo = 968 },
						new() { User = "User4", Elo = 968 }
					});
			}
		}
	}
}