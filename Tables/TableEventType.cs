using System.ComponentModel.DataAnnotations;

namespace FoxHorn.CasinoSystem.BusinessModel.Tables
{
    public enum TableEventType : byte
    {
        //[Display(Name = "TableEventType_Open", ResourceType = typeof(Resources))]
        Open = 1,

        //[Display(Name = "TableEventType_Close", ResourceType = typeof(Resources))]
        Close = 2,

        //[Display(Name = "TableEventType_BuyIn", ResourceType = typeof(Resources))]
        BuyIn = 3,

        //[Display(Name = "TableEventType_Cashout", ResourceType = typeof(Resources))]
        Cashout = 4,

        /// <summary>
        /// This is the drop done for a given player buy in.
        /// </summary>
        //[Display(Name = "TableEventType_PlayerDrop", ResourceType = typeof(Resources))]
        PlayerDrop = 5,

        //[Display(Name = "TableEventType_Credit", ResourceType = typeof(Resources))]
        Credit = 6,

        //[Display(Name = "TableEventType_Fill", ResourceType = typeof(Resources))]
        Fill = 7,

        //[Display(Name = "TableEventType_ChipExchange", ResourceType = typeof(Resources))]
        ChipExchange = 8,

        //[Display(Name = "TableEventType_Rating", ResourceType = typeof(Resources))]
        Rating = 9,

        /// <summary>
        /// This is the end of shift drop that is counted
        /// </summary>
        //[Display(Name = "TableEventType_TableDrop", ResourceType = typeof(Resources))]
        TableDrop = 10,

        /// <summary>
        /// This is if the tableshift is reopen
        /// </summary>
        //[Display(Name = "TableEventType_TableReopen", ResourceType = typeof(Resources))]
        TableReopen = 11
    }
}