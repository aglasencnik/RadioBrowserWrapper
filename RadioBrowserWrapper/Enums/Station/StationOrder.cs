namespace RadioBrowserWrapper.Enums
{
    /// <summary>
    /// Represents the order of stations.
    /// </summary>
    public enum StationOrder
    {
        [EnumMemberValue("name")]
        Name,

        [EnumMemberValue("url")]
        Url,

        [EnumMemberValue("homepage")]
        Homepage,

        [EnumMemberValue("favicon")]
        Favicon,

        [EnumMemberValue("tags")]
        Tags,

        [EnumMemberValue("country")]
        Country,

        [EnumMemberValue("state")]
        State,

        [EnumMemberValue("language")]
        Language,

        [EnumMemberValue("votes")]
        Votes,

        [EnumMemberValue("codec")]
        Codec,

        [EnumMemberValue("bitrate")]
        Bitrate,

        [EnumMemberValue("lastcheckok")]
        LastCheckOk,

        [EnumMemberValue("lastchecktime")]
        LastCheckTime,

        [EnumMemberValue("clicktimestamp")]
        ClickTimestamp,

        [EnumMemberValue("clickcount")]
        ClickCount,

        [EnumMemberValue("clicktrend")]
        ClickTrend,

        [EnumMemberValue("changetimestamp")]
        ChangeTimestamp,

        [EnumMemberValue("stationuuid")]
        Random
    }
}
