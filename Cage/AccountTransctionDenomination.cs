#region Legal
// CasinoSystem/CasinoSystem.Cage.Business.Model/AccountTransactionDenomination.cs
// Copyright (c) 2011 - 2012 FoxHorn Solutions, LLC. All Rights Reserved.
// Information Contained Herein is Proprietary and Confidential.
//
// The document is the property of FoxHorn Solutions, LLC and may not be
// disclosed, distributed, or reproduced without the express
// written permission of FoxHorn Solutions, LLC.
//
// Author: Matt Van Horn
// Created: 11/27/2012 12:40 AM
#endregion
using System.Runtime.Serialization;
using FoxHorn.CasinoSystem.BusinessModel.Infrastructure;

namespace FoxHorn.CasinoSystem.BusinessModel.Cage.Accounts
{
    public class AccountTransactionDenomination
    {
        [DataMember(Name = "id")]
        public long AccountTransactionDenominationId { get; set; }

        [DataMember(Name = "atid")]
        public long AccountTransactionId { get; set; }

        [DataMember(Name = "miid")]
        public short MonetaryInstrumentId { get; set; }

        [DataMember(Name = "midid")]
        public int? MonetaryInstrumentDenominationId { get; set; }

        [DataMember(Name = "num")]
        public int Quantity { get; set; }

        [DataMember(Name = "cValue")]
        public decimal CurrencyValue { get; set; }

        [DataMember]
        public decimal TotalCurrencyValue { get; set; }

        [DataMember(Name = "bValue")]
        public decimal BaseValue { get; set; }

        [DataMember]
        public decimal TotalBaseValue { get; set; }

        [DataMember(Name = "iuid")]
        public string ItemUniqueId { get; set; }

        [DataMember(Name = "mitid")]
        public byte MonetaryInstrumentTypeId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember]
        public string MonetaryInstrumentName { get; set; }

        [DataMember]
        public string Symbol { get; set; }

        [DataMember]
        public decimal UnitCurrencyValue { get; set; }

        public string OrderBy => $"{Symbol.PadLeft(3, '0')}{UnitCurrencyValue.ToString("N2").PadLeft(8, '0')}";

        [IgnoreDataMember]
        public MonetaryInstrumentType InstrumentType
        {
            get { return (MonetaryInstrumentType)MonetaryInstrumentTypeId; }
            set { MonetaryInstrumentTypeId = (byte)value; }
        }

        public string InstrumentTypeCurrencyGrouping => $"{Symbol}|{InstrumentType}";



        public string DuplicateHash => $"{ReferenceModel.AccountTransactionDenomination}-{MonetaryInstrumentId}-{MonetaryInstrumentDenominationId}-{Quantity}-{TotalCurrencyValue}";

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{(Symbol + " " + UnitCurrencyValue.ToString("N2")).PadLeft(14, ' ')}  x {(Quantity.ToString("N0").PadLeft(5, ' '))} ={(Symbol + " " + TotalCurrencyValue.ToString("N2")).PadLeft(15, ' ')}{(TotalBaseValue.ToString("N2")).PadLeft(16, ' ')}";
        }
    }
}