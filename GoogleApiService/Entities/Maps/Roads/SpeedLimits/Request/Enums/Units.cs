using System.Runtime.Serialization;

namespace GoogleApiService.Entities.Maps.Roads.SpeedLimits.Request.Enums
{
    /// <summary>
    /// Speed Units
    /// </summary>
    [DataContract]
    public enum Units
    {
        /// <summary>
        /// Miles per hour.
        /// </summary>
        [EnumMember(Value = "MPH")]
        Mph,
        /// <summary>
        /// Kilometers per hour.
        /// </summary>
        [EnumMember(Value = "KPH")]
        Kph,
    }
}