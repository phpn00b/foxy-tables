using System.Runtime.Serialization;

namespace FoxHorn.CasinoSystem.BusinessModel.Cage
{
    /// <summary>
    /// This is the different core type of monetary insturments. We can create any monetary instruments as we want but they should all fall into one of these classes
    /// </summary>
    public enum MonetaryInstrumentType : byte
    {
        //[Display(Name = "MonetaryInstrumentType_Bills", ResourceType = typeof(Resources))]
        [EnumMember]
        Bills = 1,

        //[Display(Name = "MonetaryInstrumentType_Coins", ResourceType = typeof(Resources))]
        [EnumMember]
        Coins = 2,

        //[Display(Name = "MonetaryInstrumentType_Tokens", ResourceType = typeof(Resources))]
        [EnumMember]
        Tokens = 3,

        //[Display(Name = "MonetaryInstrumentType_Tickets", ResourceType = typeof(Resources))]
        [EnumMember]
        Tickets = 4,

        //[Display(Name = "MonetaryInstrumentType_Chips", ResourceType = typeof(Resources))]
        [EnumMember]
        Chips = 5
    }
}