#region Legal
// CasinoSystem/CasinoSystem.Cage.Business.Model/Account.cs
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
using FoxHorn.CasinoSystem.BusinessModel.Infrastructure;

namespace FoxHorn.CasinoSystem.BusinessModel.Cage.Accounts
{
    public class Account
    {
        [DataMember]
        public long AccountId { get; set; }
        [DataMember]
        public long? ParentAccountId { get; set; }
        [DataMember]
        public Account ParentAccount { get; set; }
        [DataMember]
        public short AccountTypeId { get; set; }

        public ReferenceModel AccountType
        {
            get { return (ReferenceModel)AccountTypeId; }
            set { AccountTypeId = (short)value; }
        }

        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public DateTime LastTransation { get; set; }
        [DataMember]
        public decimal BalanceOnHand { get; set; }
        [DataMember]
        public Guid ExternalId { get; set; }
        [DataMember]
        public long? ReferenceId { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsUserVisible { get; set; }

        [DataMember]
        public long? ActiveAccountPeriodId { get; set; }
    }
}