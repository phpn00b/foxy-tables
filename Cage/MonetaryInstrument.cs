#region Legal
// CasinoSystem/CasinoSystem.Cage.Business.Model/MonetaryInstrument.cs
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
using System.Runtime.Serialization;

namespace FoxHorn.CasinoSystem.BusinessModel.Cage
{
    public class MonetaryInstrument
    {
        [DataMember(Name = "id")]
        public virtual short MonetaryInstrumentId { get; set; }

        [DataMember(Name = "cid")]
        public virtual short CurrencyId { get; set; }

        [DataMember(Name = "cu")]
        public Currency Currency { get; set; }

        [DataMember(Name = "nm")]
        public virtual string Name { get; set; }

        [DataMember(Name = "des")]
        public virtual string Description { get; set; }

        [DataMember(Name = "eid")]
        public virtual Guid ExternalId { get; set; }

        [DataMember(Name = "si")]
        public virtual short SortIndex { get; set; }

        [DataMember(Name = "ia")]
        public virtual bool IsActive { get; set; }

        [DataMember(Name = "denoms")]
        public List<MonetaryInstrumentDenomination> Denominations { get; set; }

        [DataMember(Name = "tisn")]
        public virtual bool TrackInstrumentSerialNumber { get; set; }

        [DataMember(Name = "type")]
        public byte MonetaryInstrumentTypeId { get; set; }

        [IgnoreDataMember]
        public virtual MonetaryInstrumentType InstrumentType
        {
            get => (MonetaryInstrumentType)MonetaryInstrumentTypeId;
            set => MonetaryInstrumentTypeId = (byte)value;
        }

        public static void CopyChanges(MonetaryInstrument orignalEntity, MonetaryInstrument current)
        {
            orignalEntity.Name = current.Name;
            orignalEntity.Description = current.Description;
            orignalEntity.SortIndex = current.SortIndex;
            orignalEntity.IsActive = current.IsActive;
            orignalEntity.CurrencyId = current.CurrencyId;
            orignalEntity.TrackInstrumentSerialNumber = current.TrackInstrumentSerialNumber;
            orignalEntity.InstrumentType = current.InstrumentType;
            orignalEntity.ExternalId = current.ExternalId;
        }
    }
}