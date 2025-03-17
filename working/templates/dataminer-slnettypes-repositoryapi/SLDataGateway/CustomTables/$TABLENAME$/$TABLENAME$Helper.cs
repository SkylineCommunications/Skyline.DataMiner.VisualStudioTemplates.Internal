using System;

using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages;

namespace Skyline.DataMiner.Net
{
    /// <summary>
    /// Provides helper methods for managing application package content.
    /// </summary>
    public class $TABLENAME$Helper : BaseManagerHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="$TABLENAME$Helper"/> class.
        /// </summary>
        /// <param name="messageHandler">The function to handle DMS messages.</param>
        public $TABLENAME$Helper(Func<DMSMessage[], DMSMessage[]> messageHandler) : base(messageHandler)
        {
            Content = new $TABLENAME$CrudHelperComponent(messageHandler);
        }

        /// <summary>
        /// Gets or sets the CRUD helper component for managing application package content.
        /// </summary>
        public $TABLENAME$CrudHelperComponent Content { get; set; }
    }
}