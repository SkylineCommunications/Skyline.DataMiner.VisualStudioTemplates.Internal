using WixToolset.Dtf.WindowsInstaller;

namespace $InstallerName$.CA.Actions
{
	public static class CleanupOnRemoveActions
	{
		[CustomAction]
		public static ActionResult MyImmediateCustomAction(Session session)
		{
			// Perform some operations
			// Immediate custom actions are meant to gather information or set properties that will be used by deferred custom actions.
			// Actual changes to services, system state,... Should happen in the deferred actions, since these can be undone with a rollback action if something goes wrong.
			// The main advantage for these immediate actions, is that they can access properties and session variables, while deferred actions can only access the CustomActionData property bag.
			// So if you need to access a property in a deferred action, you should access it in an immediate action and pass it to the deferred action through the CustomActionData property bag.
			var installFolderProperty = session["INSTALLFOLDER"];
			var reinstallModeProperty = session["REINSTALLMODE"];

			// This is how you pass data from an immediate custom action to a deferred custom action.
			// You set a session variable **with the same name as the deferred custom action**. The data you want to pass should be formatted as a string of key-value pairs,
			// where the key is the name of the property you want to access in the deferred custom action, and the value is the value you want to pass.
			// Each key-value pair is separated by a semicolon.
			session["MyDeferredCustomAction"] = $"InstallFolderProperty={installFolderProperty};ReinstallModeProperty={reinstallModeProperty}";

			// Rollback custom actions are a special kind of deferred custom actions.
			// Passing properties happens in the same way.
			// e.g. you could pass the install location of a custom file here, which will allow the rollback custom action to delete that file if something goes wrong.
			session["RollbackMyDeferredCustomAction"] = $"InstallFolderProperty={installFolderProperty}";

			// Commit custom actions are another special kind of deferred custom actions.
			// These are executed after the installation has been successfully completed, and cannot be rolled back. They are meant to perform some final operations that should only happen if the installation was successful.
			// e.g. to cleanup some temp files you created during the installation, or to perform some operations that should only happen if the installation was successful.
			session["MyCommitCustomAction"] = $"InstallFolderProperty={installFolderProperty}";

			return ActionResult.Success;
		}

		[CustomAction]
		public static ActionResult RollbackMyDeferredCustomAction(Session session)
		{

			var installFolder = session.CustomActionData["InstallFolderProperty"];

			// Undo the operations performed in the MyDeferredCustomAction method, using the installFolder variable to know which folder to clean up.

			return ActionResult.Success;
		}

		[CustomAction]
		public static ActionResult MyDeferredCustomAction(Session session)
		{
			var installFolder = session.CustomActionData["InstallFolderProperty"];
			var reinstallMode = session.CustomActionData["ReinstallModeProperty"];

			// now you can use the installFolder and reinstallMode variables to perform some operations which modify the system state.
			// e.g. to create a kind of 

			return ActionResult.Success;
		}

		[CustomAction]
		public static ActionResult MyCommitCustomAction(Session session)
		{
			var installFolder = session.CustomActionData["InstallFolderProperty"];

			// now you can use the installFolder variable to perform some operations which should only happen if the installation was successful, and that cannot be rolled back.

			return ActionResult.Success;
		}
	}
}
