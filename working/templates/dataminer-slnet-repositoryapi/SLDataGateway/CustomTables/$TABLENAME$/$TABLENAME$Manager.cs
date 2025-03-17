using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;

using Skyline.DataMiner.Net.Exceptions;
using Skyline.DataMiner.Net.IManager.Helper;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Messages.SLDataGateway;

namespace Skyline.DataMiner.Net.$TABLENAME$
{
    internal class $TABLENAME$Manager : BaseManager
    {
        private Timer _timer;

        public $TABLENAME$Manager()
            : base("$TABLENAME$Manager")
        {
        }

        public BulkCrudComponent<$TABLENAME$, Guid> ContentCrud { get; private set; }

        public override H CreateLocalHelper<H>(Func<DMSMessage[], DMSMessage[]> p)
        {
            if (typeof(H) != typeof($TABLENAME$Helper))
            {
                throw new DataMinerException($"The wrong type of helper was requested for manager. Request: {typeof(H).FullName}, Manager: {GetManagerName()}");
            }

            return new $TABLENAME$Helper(p) as H;
        }

        public override string GetManagerName()
        {
            return ModuleID.$TABLENAME$Manager.ModuleName;
        }

        public override ModuleID GetModuleID()
        {
            return ModuleID.$TABLENAME$Manager;
        }

        protected override void OnDeinitialize()
        {
            if (CrudComponents != null)
            {
                CrudComponents.Clear();
            }

            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
            }
        }

        protected override void OnInitialize()
        {
            // Setup storage
            var storage = new $TABLENAME$Storage(Logger);
            ContentCrud = new BulkCrudComponent<$TABLENAME$, Guid>(storage) { DistinctById = false };


            // This is an example. You can add other Proxy or remove as needed.
            // Adds default debug logging to CRUD Operations
            ContentCrud.AddProxy(new CrudLoggerProxy<$TABLENAME$>(Logger, LogLevel.L3));

            // Necessary to automatically fill in last created, last updated
            ContentCrud.AddProxy(new TrackBaseProxy<$TABLENAME$>());

            // Allow everyone to read the data, but only specific permissions to set. This is currently set to the ability to perform AppPackage Installations but should be changed to what fits your use case.
            ContentCrud.AddProxy(new CheckSecurityFlagAllowReadsProxy<$TABLENAME$>(
                PermissionFlags.AgentsInstallAppPackages,
                PermissionFlags.AgentsInstallAppPackages,
                PermissionFlags.AgentsInstallAppPackages));

            CrudComponents.Add(ContentCrud);
        }
    }
}