#region Legal
// CasinoSystem/CasinoSystem.Cage.Business.Model/Currency.cs
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
using System.Runtime.Serialization;

namespace FoxHorn.CasinoSystem.BusinessModel.Cage
{
    public class Currency
    {
        [DataMember]
        public short CurrencyId { get; set; }
        [DataMember]
        public virtual string Name { get; set; }
        [DataMember]
        public virtual string Description { get; set; }
        [DataMember]
        public bool AllowsFractions { get; set; }
        [DataMember]
        public virtual bool IsActive { get; set; }
        [DataMember]
        public bool IsBaseCurrency { get; set; }
        [DataMember]
        public virtual decimal BaseCurrencyMultiplier { get; set; }
        [DataMember]
        public Guid ExternalId { get; set; }
        [DataMember]
        public virtual string Symbol { get; set; }
        [DataMember]
        public string Iso4217Code { get; set; }
        [DataMember]
        public short Iso4217Number { get; set; }
        [DataMember]
        public byte SignificantDigits { get; set; }
        [DataMember]
        public virtual short SortIndex { get; set; }
        [DataMember]
        public virtual bool RequireDenominationValuesOnBillDrop { get; set; }

        public static void CopyChanges(Currency originalEntity, Currency current)
        {
            originalEntity.Name = current.Name;
            originalEntity.Description = current.Description;
            originalEntity.AllowsFractions = current.AllowsFractions;
            originalEntity.IsActive = current.IsActive;
            originalEntity.IsBaseCurrency = current.IsBaseCurrency;
            originalEntity.BaseCurrencyMultiplier = current.BaseCurrencyMultiplier;
            originalEntity.ExternalId = current.ExternalId;
            originalEntity.Symbol = current.Symbol;
            originalEntity.Iso4217Code = current.Iso4217Code;
            originalEntity.Iso4217Number = current.Iso4217Number;
            originalEntity.SignificantDigits = current.SignificantDigits;
            originalEntity.SortIndex = current.SortIndex;
            originalEntity.RequireDenominationValuesOnBillDrop = current.RequireDenominationValuesOnBillDrop;
        }
    }
}