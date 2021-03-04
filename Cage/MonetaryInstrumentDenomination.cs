#region Legal
// CasinoSystem/CasinoSystem.Cage.Business.Model/MonetaryInstrumentDenomination.cs
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
    public class MonetaryInstrumentDenomination
    {
        [DataMember(Name = "id")]
        public virtual int MonetaryInstrumentDenominationId { get; set; }

        [DataMember(Name = "miid")]
        public virtual short MonetaryInstrumentId { get; set; }

        [DataMember(Name = "mi")]
        public MonetaryInstrument MonetaryInstrument { get; set; }

        [DataMember(Name = "nm")]
        public virtual string Name { get; set; }

        [DataMember(Name = "des")]
        public virtual string Description { get; set; }

        [DataMember(Name = "eid")]
        public virtual Guid ExternalId { get; set; }

        [DataMember(Name = "curVal")]
        public virtual decimal CurrencyValue { get; set; }

        [DataMember(Name = "si")]
        public virtual short SortIndex { get; set; }

        [DataMember(Name = "ia")]
        public virtual bool IsActive { get; set; }

        [DataMember(Name = "tum")]
        public virtual bool TrackUnitMovement { get; set; }

        [DataMember(Name = "imgPa")]
        public virtual string ImagePath { get; set; }

        [DataMember]
        public virtual bool IncludeInFillCredit { get; set; }

        [DataMember]
        public virtual bool IncludeInSlotDrop { get; set; }

        [DataMember]
        public virtual bool IncludeInTableDrop { get; set; }

        [DataMember]
        public virtual bool IncludeInTableOpenClose { get; set; }

        [DataMember]
        public virtual bool IncludeInWindowOpenClose { get; set; }

        [DataMember]
        public virtual bool IncludeInMainOpenClose { get; set; }

        public override int GetHashCode()
        {
            return MonetaryInstrumentId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            return GetHashCode() == obj.GetHashCode();
        }

        public decimal BaseCurrencyValue
        {
            get
            {
                if (MonetaryInstrument == null || MonetaryInstrument.Currency == null)
                    return 0;
                return MonetaryInstrument.Currency.BaseCurrencyMultiplier * CurrencyValue;
            }
        }

        public static void CopyChanges(MonetaryInstrumentDenomination originalEntity, MonetaryInstrumentDenomination current)
        {
            originalEntity.Name = current.Name;
            originalEntity.Description = current.Description;
            originalEntity.SortIndex = current.SortIndex;
            originalEntity.IsActive = current.IsActive;
            originalEntity.ExternalId = current.ExternalId;
            originalEntity.CurrencyValue = current.CurrencyValue;
            originalEntity.MonetaryInstrumentId = current.MonetaryInstrumentId;
            originalEntity.TrackUnitMovement = current.TrackUnitMovement;
            originalEntity.ImagePath = current.ImagePath;
            originalEntity.IncludeInFillCredit = current.IncludeInFillCredit;
            originalEntity.IncludeInSlotDrop = current.IncludeInSlotDrop;
            originalEntity.IncludeInTableDrop = current.IncludeInTableDrop;
            originalEntity.IncludeInTableOpenClose = current.IncludeInTableOpenClose;
            originalEntity.IncludeInWindowOpenClose = current.IncludeInWindowOpenClose;
            originalEntity.IncludeInMainOpenClose = current.IncludeInMainOpenClose;
        }

        [DataMember]
        public MonetaryInstrumentType InstrumentType { get; set; }

        [DataMember]
        public short CurrencyId { get; set; }

        private string _autoImage;

        [DataMember]
        public string AutoImageUrl
        {
            set => _autoImage = value;
            get
            {
                if (_autoImage != null)
                    return _autoImage;
                if (InstrumentType == MonetaryInstrumentType.Chips)
                    return $"{ConfigSettings.GlobalServerUrl}casino-system/Content/chips/{ConfigSettings.FoxHornClientIdentifier}/{CurrencyValue:F2}.png";
                string currency = CurrencyId == 2 ? "NIO" : "USD";
                return $"{ConfigSettings.GlobalServerUrl}casino-system/Content/bills/{currency}/{CurrencyValue:F0}.jpg";
            }
        }
    }
}