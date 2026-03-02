namespace $CLASS_NAME_PLACEHOLDER$Bpa
{
	using System;
	using Skyline.DataMiner.BpaLib;

	/// <summary>
	/// $BPA_DESCRIPTION$
	/// </summary>
#if (IsCorrectiveBpa)
	public class $CLASS_NAME_PLACEHOLDER$TestEntry : ABpaCorrectiveTest
#else
	public class $CLASS_NAME_PLACEHOLDER$TestEntry : ABpaTest
#endif
	{
		public override string Name => "$BPA_PROJECT_NAME$";
		public override string Description => "$BPA_DESCRIPTION$";
		public override string Author => "$BPA_AUTHOR$";

		// This class is where the test actually happens, all test code should go here.

		// see the BpaTests/Examples solution for more options that can be overridden:
		// - ExecuteConditions (e.g. Cassandra, Failover, ...)
		// - Flags (e.g. CanRunOnOfflineAgent or RequireSLNet)
		// - MaxVersions
		// - MinVersions
		// - RunMode (e.g. Cluster)
		// - DefaultSchedule (BPA test will run every x time)

		/// <summary>
		/// This is the main entry point of the test.
		/// When the test is run this function will be called.
#if (IsCorrectiveBpa)
		/// The result is then used to decide if <see cref="CorrectiveAction"/> will be called.
#endif
		/// </summary>
		/// <param name="context">The execution context .</param>
		/// <returns>The result of the test execution.</returns>
#if (IsCorrectiveBpa)
		protected override ABpaTestResult Verify(BpaExecuteContext context)
#else
		public override ABpaTestResult Run(BpaExecuteContext context)
#endif
		{
			// Your test code goes here.
			// For more information on how to implement a BPA, refer to https://aka.dataminer.services/BPADev.
			// For more information on how to run a BPA in the standalone executor, refer to https://aka.dataminer.services/BPAStandaloneExecutor.

			return new $CLASS_NAME_PLACEHOLDER$Result
			{
				// At the very least, provide an outcome and a result message
				Outcome = BpaTestOutcome.NoIssues,
				ResultMessage = "No issues detected",

				// For issues, it is advised to provide an impact and info on corrective actions in the result
				Impact = String.Empty,
				CorrectiveAction = String.Empty,

				// A JSON serializable object can be provided with further details.
				// - In its simplest format, this is a string.
				// - A list of string can be provided through:
				//      BpaResultHelper.BuildStringListDetails(string[])
				// - A custom JSON object tree can also be provided.
				// See the examples in BpaTests/Examples for more info
				DetailedJsonResult = "Detailed results",
			};
		}
#if (IsCorrectiveBpa)
	
		/// <summary>
		/// This function will be called if the verify function fails and the BPA is allowed to perform corrective actions
		/// </summary>
		/// <param name="context">The execution context .</param>
		/// <returns>Indication of whether the corrective action succeeded.</returns>
		protected override bool CorrectiveAction(BpaExecuteContext context)
		{
			// Your code for correcting the issue goes here.
			return true;
		}
#endif
	}
}
