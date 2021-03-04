
namespace FoxHorn.CasinoSystem.BusinessModel.Cage
{
    /// <summary>
    /// This enumerates the different type of transactions
    /// </summary>
    public enum CageTransactionType : short
    {
        None = 0,
        /// <summary>
        /// Used to create an account
        /// </summary>
        CreateAccount = 1,

        /// <summary>
        /// this is the last thing that is done to an account
        /// </summary>
        CloseAccount = 2,

        /// <summary>
        /// legacy DO NOT USE
        /// </summary>
        ProgressivePlayerBuyIn = 3,

        /// <summary>
        /// legacy DO NOT USE
        /// </summary>
        ProgressivePlayerCashout = 4,

        /// <summary>
        /// legacy DO NOT USE
        /// </summary>
        ProgressivePlayerContributeToProgressive = 5,

        /// <summary>
        /// legacy DO NOT USE
        /// </summary>
        ProgressivePayWinner = 6,

        /// <summary>
        /// Used for a fill on slot coins
        /// </summary>
        SlotFill = 7,

        /// <summary>
        /// Used for a slot bill drop
        /// </summary>
        SlotBillDrop = 8,

        /// <summary>
        /// used when dropping slot coins
        /// </summary>
        SlotCoinDrop = 9,

        /// <summary>
        /// Used for recording a ticket printed at a slot
        /// </summary>
        SlotTicketPrinted = 10,

        /// <summary>
        /// Used when a slot accepts a ticket
        /// </summary>
        SlotTicketAccepted = 11,

        /// <summary>
        /// Used when the cage pays a ticket
        /// </summary>
        CageTickedPaidSystem = 12,

        /// <summary>
        /// used when a player buys in on a table
        /// </summary>
        TablePlayerBuyIn = 13,

        /// <summary>
        /// Used when a player cashes out on a table
        /// </summary>
        TablePlayerCashout = 14,

        /// <summary>
        /// Used when a player exchanges chips with the table ie color up
        /// </summary>
        TablePlayerChipExchange = 15,

        /// <summary>
        /// This is the game open count
        /// </summary>
        TableGameOpen = 16,

        /// <summary>
        /// This is the game close count
        /// </summary>
        TableGameClose = 17,

        /// <summary>
        /// This is done when chips are sent to the game
        /// </summary>
        TableGameFill = 18,

        /// <summary>
        /// This is done when chips are sent away from the game
        /// </summary>
        TableGameCredit = 19,

        /// <summary>
        /// This is when the money is dropped from a table game
        /// </summary>
        TableGameDrop = 20,

        /// <summary>
        /// This is when we accept a ticket on a table game
        /// </summary>
        TableTicketAccepted = 21,

        OpenAccountPeriod = 22,
        CloseAccountPeriod = 23,
        SlotPayNonProgressiveJackpot = 24,
        SlotPayProgressiveJackpot = 25,
        SlotPayHandPaidCanceledCredits = 26,
        SlotTicketPrintedManuallyEntered = 27,
        PaidPointTransaction = 28,
        PaidPromotionAssignment = 29,
        FundedPlayerQuickCash = 30,
        CreditCardToQuickCash = 31,
        CreditCardToCash = 32,
        CreditCardToChips = 33,
        CageHandPayPaidManual = 34,
        CashOutPlayerQuickCash = 35,
        FillCageWindow = 36,
        Buy = 37,
        EvenExchange = 38,
        Transfer = 39,
        PaidIn = 40,
        PaidOut = 41,
        ChipExchangeIn = 42,
        ChipExchangeOut = 43,
        CreditCageWindow = 44,
        MeteredBillsAccepted = 45,
        MeteredAftIn = 46,
        MeteredAftOut = 47,
        MeteredTicketIn = 48,
        MeteredTicketOut = 49,
        MeteredCoinIn = 50,
        MeteredHandPaid = 51,
        MeteredWon = 52,
        SlotHandPaySystem = 53,
        SlotHandPayManuallyEntered = 54,
        CageHandPayPaidSystem = 55,
        CageTickedPaidManual = 56,
        SlotDownloadFromQuickCash = 57,
        SlotUploadToQuickCash = 58,
        SlotUploadToQuickCashCashoutDevice = 59,
        PayKioskHostCashOutTicket = 60,
        RetentionOnPayment = 61,
        SlotPayNonProgressiveJackpotToQuickCash = 62,
        SlotPayProgressiveJackpotToQuickCash = 63,
        SlotPayHandPaidCanceledCreditsToQuickCash = 64,
        OpenMainBank = 65,
        CloseMainBank = 66,
        OpenCageWindow = 67,
        CloseCageWindow = 68,
        OpenFloatAccount = 69,
        CloseFloatAccount = 70,
        OpenTableGame = 71,
        CloseTableGame = 72,
        Differences = 73
    }
}