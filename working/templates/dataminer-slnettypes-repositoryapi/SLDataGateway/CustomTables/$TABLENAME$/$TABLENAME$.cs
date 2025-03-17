using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;

using Skyline.DataMiner.Net.IManager.Objects;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages.SLDataGateway;

namespace Skyline.DataMiner.Net
{
    /// <summary>
    /// Represents the content of an application package.
    /// </summary>
    [Serializable]
    [DataContract]
    public class $TABLENAME$ : CustomDataType, IManagerIdentifiableObject<Guid>, ITrackBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="$TABLENAME$"/> class.
        /// </summary>
        static $TABLENAME$()
        {
            $TABLENAME$Exposers.Initialize();
        }

        /// <summary>
        /// Gets or sets the date and time when the content was created.
        /// </summary>
        [DataMember(Name = "CreatedAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who created the content.
        /// </summary>
        [DataMember(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        [IgnoreDataMember]
        string DataType.DataTypeID => ID.ToString();

        [IgnoreDataMember]
        bool DataType.FromMigration { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the content was last modified.
        /// </summary>
        [DataMember(Name = "LastModified")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who last modified the content.
        /// </summary>
        [DataMember(Name = "LastModifiedBy")]
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the application package content.
        /// </summary>
        /// <remarks>
        /// When creating new records, you must manually generate this GUID.
        /// </remarks>
        [DataMember(Name = "ID")]
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the my custom data.
        /// </summary>
        [DataMember(Name = "MyCustomData")]
        public string MyCustomData { get; set; }

        /// <summary>
        /// Deserializes an instance of <see cref="$TABLENAME$"/> from a JSON string.
        /// </summary>
        /// <param name="json">The JSON string representing an <see cref="$TABLENAME$"/> object.</param>
        /// <returns>An instance of <see cref="$TABLENAME$"/>.</returns>
        public static $TABLENAME$ FromJson(string json)
        {
            return JsonConvert.DeserializeObject<$TABLENAME$>(json);
        }

        /// <summary>
        /// Creates a filter for querying application package content based on its ID.
        /// </summary>
        /// <typeparam name="T">The type of the filter element.</typeparam>
        /// <returns>A filter element that can be used to query content based on its ID.</returns>
        public FilterElement<T> ToFilter<T>()
        {
            return (FilterElement<T>)$TABLENAME$Exposers.ID.Equal(this.ID);
        }

        object[] DataType.ToInterOp()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Serializes the current instance into a JSON string.
        /// </summary>
        /// <returns>A JSON-formatted string representing the current instance.</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        string[] DataType.ToStringArray()
        {
            throw new NotSupportedException();
        }

        DataType DataType.toType(string[] data)
        {
            throw new NotSupportedException();
        }
    }
}