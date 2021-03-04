#region Legal
// CasinoSystem/CasinoSystem.Cage.Business.Model/AccountTransaction.cs
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using FoxHorn.CasinoSystem.BusinessModel.Infrastructure;

namespace FoxHorn.CasinoSystem.BusinessModel.Cage.Accounts
{
    public class AccountTransaction
    {
        public AccountTransaction()
        {
            AccountTransactionDenominations = new AccountTransactionDenominationCollection();
        }

        [DataMember(Name = "id")]
        public long AccountTransactionId { get; set; }

        [DataMember]
        public short TransactionTypeId {get;set;}


        [IgnoreDataMember]
        public CageTransactionType TransType
        {
            get { return (CageTransactionType)TransactionTypeId; }
            set { TransactionTypeId = (short)value; }
        }

        [DataMember(Name = "uid")]
        public int UserId { get; set; }

        [DataMember(Name = "said")]
        public long? SourceAccountId { get; set; }

        [DataMember(Name = "sa")]
        public Account SourceAccount { get; set; }

        [DataMember(Name = "daid")]
        public long? DestinationAccountId { get; set; }

        [DataMember(Name = "da")]
        public Account DestinationAccount { get; set; }

        [DataMember(Name = "cd")]
        public DateTime CreatedDate { get; set; }

        [DataMember(Name = "eid")]
        public Guid ExternalId { get; set; }

        [DataMember(Name = "effect")]
        public decimal EffectOnBalance { get; set; }


        public AccountTransactionDenominationCollection AccountTransactionDenominations { get; set; }

        [DataMember(Name = "denoms")]
        public AccountTransactionDenomination[] Denoms
        {
            get => AccountTransactionDenominations.OfType<AccountTransactionDenomination>().ToArray();
            set => AccountTransactionDenominations = new AccountTransactionDenominationCollection(value);
        }

        [DataMember]
        public int? VoidedByUserId { get; set; }

        [DataMember]
        public DateTime? VoidedDate { get; set; }

        [DataMember]
        public long? AccountPeriodId { get; set; }

        [DataMember]
        public string CreatedByUsername { get; set; }

        [DataMember]
        public string VoidedByUsername { get; set; }

        [DataMember]
        public long? DestinationAccountPeriodId { get; set; }

        [DataMember]
        public long? SourceAccountPeriodId { get; set; }

        [DataMember]
        public decimal StartingBalance { get; set; }

        [DataMember]
        public decimal ExpectedEndingBalance { get; set; }

        [DataMember]
        public decimal ActualEndingBalance { get; set; }

        [DataMember]
        public decimal Difference { get; set; }

        public bool ShowDenomBreakDown { get; set; }

        public string PrintTitle { get; set; }

        public int? PlayerId { get; set; }

        public string PlayerName { get; set; }

        public List<Metadata> ExtraPrintData { get; set; } = new List<Metadata>();

        public List<string> SignatureLines { get; set; } = new List<string>();

        public string AccountName { get; set; }

        public class Metadata
        {
            public string Label { get; set; }
            public string Value { get; set; }
        }

        public InstrumentSummary[] InstrumentSummaries
        {
            get
            {
                if (AccountTransactionDenominations == null)
                    return new InstrumentSummary[0];
                return AccountTransactionDenominations.OfType<AccountTransactionDenomination>().GroupBy(o => o.MonetaryInstrumentName).Select(
                    o => new InstrumentSummary
                    {
                        Name = o.Key,
                        CurrencySymbol = o.First().Symbol,
                        CurrencyValue = o.Sum(d => d.TotalCurrencyValue),
                        BaseValue = o.Sum(d => d.TotalBaseValue)
                    }).ToArray();
            }
        }

        public class InstrumentSummary
        {
            public string Name { get; set; }
            public string CurrencySymbol { get; set; }
            public decimal CurrencyValue { get; set; }
            public decimal BaseValue { get; set; }
        }

        [IgnoreDataMember]
        public decimal CashValue
        {
            get
            {
                if (AccountTransactionDenominations == null)
                    return 0;
                return AccountTransactionDenominations.Where<AccountTransactionDenomination>(o => o.InstrumentType == MonetaryInstrumentType.Bills).Sum(o => o.TotalBaseValue);
            }
        }

        [IgnoreDataMember]
        public decimal TotalValue
        {
            get
            {
                if (AccountTransactionDenominations == null)
                    return 0;
                return AccountTransactionDenominations.Sum<AccountTransactionDenomination>(o => o.TotalBaseValue);
            }
        }

        [IgnoreDataMember]
        public decimal ChipValue
        {
            get
            {
                if (AccountTransactionDenominations == null)
                    return 0;
                return AccountTransactionDenominations.Where<AccountTransactionDenomination>(o => o.InstrumentType == MonetaryInstrumentType.Chips).Sum(o => o.TotalCurrencyValue);
            }
        }

        [IgnoreDataMember]
        public decimal TicketValue
        {
            get
            {
                if (AccountTransactionDenominations == null)
                    return 0;
                return AccountTransactionDenominations.Where<AccountTransactionDenomination>(o => o.InstrumentType == MonetaryInstrumentType.Tickets).Sum(o => o.TotalBaseValue);
            }
        }

        public string CardNumber { get; set; }

        public string DuplicateHash => $"{ReferenceModel.AccountTransaction}-{SourceAccountId}-{DestinationAccountId}-{PlayerId}-{TransType}|{AccountTransactionDenominations.DuplicateHash}";


    }
}