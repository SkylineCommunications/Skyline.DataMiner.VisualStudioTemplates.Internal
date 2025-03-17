using System;

using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net
{
    /// <summary>
    /// Provides CRUD operations for managing application package content.
    /// </summary>
    public class $TABLENAME$CrudHelperComponent : BulkCrudHelperComponent<$TABLENAME$, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="$TABLENAME$CrudHelperComponent"/> class.
        /// </summary>
        /// <param name="messageHandler">The function to handle DMS messages.</param>
        internal $TABLENAME$CrudHelperComponent(Func<DMSMessage[], DMSMessage[]> messageHandler) : base(messageHandler, null) { }
    }
}