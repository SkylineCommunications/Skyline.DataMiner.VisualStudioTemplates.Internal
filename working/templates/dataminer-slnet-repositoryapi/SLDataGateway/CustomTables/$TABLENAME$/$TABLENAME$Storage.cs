using System;

using Skyline.DataMiner.Net.Apps.Utils;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.SLDataGateway.Types;

namespace Skyline.DataMiner.Net.$TABLENAME$
{
    /// <summary>
    /// Intended for elastic or staas.
    /// </summary>
    internal class $TABLENAME$Storage : CustomDataRepositoryStorage<$TABLENAME$, Guid>
    {
        public $TABLENAME$Storage(ILoggerWrapper logger)
        : base(
            $TABLENAME$Exposers.CreateFullTableDefinition,
            id => $TABLENAME$Exposers.ID.Equal(id),
            err => logger.LogError(err, nameof($TABLENAME$Storage)),
            log => logger.Log(log, nameof($TABLENAME$Storage))
        )
        {
        }

        public $TABLENAME$Storage(Func<FullTableDefinition<$TABLENAME$>> fullTableDefinitionFactory, Func<Guid, FilterElement<$TABLENAME$>> filterFactory, Action<string> errorLogger, Action<string> logger, CustomDataRepositoryOptions options = null) : base(fullTableDefinitionFactory, filterFactory, errorLogger, logger, options)
        {
        }
    }
}