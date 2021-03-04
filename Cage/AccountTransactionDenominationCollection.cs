#region Legal
// CasinoSystem/CasinoSystem.Cage.Business.Model/AccountTransactionDenominationCollection.cs
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
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FoxHorn.CasinoSystem.BusinessModel.Cage.Accounts
{
    /// <summary>
    /// Additional SQL interaction code was stripped out of this class.
    /// </summary>
    public class AccountTransactionDenominationCollection : List<AccountTransactionDenomination>
    {
        public AccountTransactionDenominationCollection()
        {
        }

        public AccountTransactionDenominationCollection(IEnumerable<AccountTransactionDenomination> items)
        {
            items.ToList().ForEach(Add);
        }

        public string DuplicateHash => $"{Count}|{(string.Join("|", ((List<AccountTransactionDenomination>)this).Select(o => o.DuplicateHash)))}";
    }
}