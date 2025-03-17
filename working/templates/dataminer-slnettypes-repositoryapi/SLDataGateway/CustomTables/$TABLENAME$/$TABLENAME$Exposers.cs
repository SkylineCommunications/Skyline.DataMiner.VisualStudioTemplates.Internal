using System;
using System.Collections.Generic;

using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.SLDataGateway.Types;

namespace Skyline.DataMiner.Net
{
    /// <summary>
    /// Provides exposers for accessing and managing properties of <see cref="$TABLENAME$"/>.
    /// </summary>
    public static class $TABLENAME$Exposers
    {
        /// <summary>
        /// Represents the exposer for the creation date and time of the content.
        /// </summary>
        public static readonly Exposer<$TABLENAME$, DateTime> CreatedAt = new SettableExposer<$TABLENAME$, DateTime>(
            x => x.CreatedAt, ($TABLENAME$ t, DateTime x) => { }, "CreatedAt");

        /// <summary>
        /// Represents the exposer for the creator of the content.
        /// </summary>
        public static readonly Exposer<$TABLENAME$, string> CreatedBy = new SettableExposer<$TABLENAME$, string>(
            x => x.CreatedBy, ($TABLENAME$ t, string x) => { }, "CreatedBy");

        /// <summary>
        /// Represents the exposer for the last modified date and time of the content.
        /// </summary>
        public static readonly Exposer<$TABLENAME$, DateTime> LastModified = new SettableExposer<$TABLENAME$, DateTime>(
            x => x.LastModified, ($TABLENAME$ t, DateTime x) => { }, "LastModified");

        /// <summary>
        /// Represents the exposer for the user who last modified the content.
        /// </summary>
        public static readonly Exposer<$TABLENAME$, string> LastModifiedBy = new SettableExposer<$TABLENAME$, string>(
            x => x.LastModifiedBy, ($TABLENAME$ t, string x) => { }, "LastModifiedBy");

        /// <summary>
        /// Represents the exposer for the unique identifier (ID) of the content.
        /// </summary>
        public static readonly Exposer<$TABLENAME$, Guid> ID = new SettableExposer<$TABLENAME$, Guid>(
            x => x.ID, ($TABLENAME$ t, Guid x) => { }, "ID");

        /// <summary>
        /// Represents the exposer for my custom data.
        /// </summary>
        public static readonly Exposer<$TABLENAME$, string> MyCustomData = new SettableExposer<$TABLENAME$, string>(
            x => x.MyCustomData, ($TABLENAME$ t, string x) => { }, "MyCustomData");

        /// <summary>
        /// The name of the table storing application package content.
        /// </summary>
        public static readonly string TableName = "c$TABLENAMELOWER$";

        /// <summary>
        /// Represents the exposer for the full object as a JSON string.
        /// </summary>
        internal static readonly FullObjectExposer<$TABLENAME$> FullObject = new FullObjectExposer<$TABLENAME$>(
            x => x.ToJson(), (x) => $TABLENAME$.FromJson(x), "FullObject");

        /// <summary>
        /// Creates the full table definition for storing and managing application package content.
        /// </summary>
        /// <returns>A <see cref="FullTableDefinition{T}"/> representing the table structure.</returns>
        public static FullTableDefinition<$TABLENAME$> CreateFullTableDefinition()
        {
            var primaryKeys = new List<Column<$TABLENAME$>>
            {
                new Column<$TABLENAME$>(QCast(ID), "id", "a")
            };

            var sortingKeys = new List<SortingKey<$TABLENAME$>>();
            primaryKeys.AddRange(sortingKeys); // SortingKeys is a subset of PrimaryKeys.

            var remainingColumns = new List<Column<$TABLENAME$>>
            {
                new Column<$TABLENAME$>(QCast(MyCustomData), "mycustomdata", "b"),

                new Column<$TABLENAME$>(QCast(CreatedAt), "createdat", "c"),
                new Column<$TABLENAME$>(QCast(CreatedBy), "createdby", "d"),

                new Column<$TABLENAME$>(QCast(LastModified), "lastmodified", "e"),
                new Column<$TABLENAME$>(QCast(LastModifiedBy), "lastmodifiedby", "f"),
            };

            var fullObjectColumn = new FullObjectColumn<$TABLENAME$>(FullObject, "fullobject", "l");
            remainingColumns.Add(fullObjectColumn);

            var tableDefinition = new FullTableDefinition<$TABLENAME$>(
                primaryKeys, sortingKeys, new List<Column<$TABLENAME$>>(), remainingColumns, TimeSpan.Zero, TableName, CustomDataModuleTag.$TABLENAME$)
            {
                DisableSuggestions = true
            };

            return tableDefinition;
        }

        /// <summary>
        /// Ensures that all static exposers are initialized.
        /// Since C# uses lazy initialization, this method guarantees their availability.
        /// </summary>
        public static void Initialize()
        {
            FieldExposer exposer = ID;

            exposer = MyCustomData;

            exposer = CreatedAt;
            exposer = CreatedBy;

            exposer = LastModified;
            exposer = LastModifiedBy;

            exposer = FullObject;
        }

        /// <summary>
        /// A helper method for casting an exposer to a settable exposer.
        /// </summary>
        /// <typeparam name="T">The type of the exposed object.</typeparam>
        /// <typeparam name="F">The type of the exposed field.</typeparam>
        /// <param name="exposer">The exposer to cast.</param>
        /// <returns>The casted <see cref="SettableExposer{T, F}"/>.</returns>
        private static SettableExposer<T, F> QCast<T, F>(Exposer<T, F> exposer)
        {
            return exposer as SettableExposer<T, F>;
        }
    }
}