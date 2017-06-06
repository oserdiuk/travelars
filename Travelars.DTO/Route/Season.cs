using System;

namespace Travelars.DTO.Route
{
    [Flags]
    public enum Season
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December,
        Winter = January | December | February,
        Summer = June | July | August,
        Autumn = September | October | November,
        Spring = March | April | May
    }
}