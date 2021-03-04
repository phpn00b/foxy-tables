using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FoxHorn.CasinoSystem.BusinessModel.Infrastructure
{
    /// <summary>
    /// this is the model that a parameter relates to.
	/// types were removed from this and will be supplied as we move forward
    /// </summary>

    public enum ReferenceModel : short
    {
        AccountTransactionDenomination = 1,
        PlayerTableActivity = 2,
        PlayerTableSubActivity = 3,
        TableEventLog = 4,
        TableShift = 5,
        AccountTransaction = 6
    }
}