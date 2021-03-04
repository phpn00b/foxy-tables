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
using FoxHorn.CasinoSystem.BusinessModel.Cage.Accounts;

namespace FoxHorn.CasinoSystem.BusinessModel.Tables
{
    public class TableShift
    {
        public enum Action
        {
            Open,
            Close,
            Fill,
            Credit,
            Reopen
        }
        public int TableShiftId { get; set; }
        public int GameId { get; set; }
        public int StartedByUserId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal StartChipValue { get; set; }
        public int? EndedByUserId { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? EndChipValue { get; set; }
        public virtual decimal? CashDrop { get; set; }
        public virtual decimal? TicketDrop { get; set; }
        public decimal? NetWin { get; set; }
        public string GameName { get; set; }
        public string GameTypeName { get; set; }
        public string StartedByUsername { get; set; }
        public string EndedByUsername { get; set; }
        public decimal ChipsCredit { get; set; }
        public decimal ChipsFill { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<TableEventLog> ShiftEvents { get; set; }
        public List<TablePlayerActivity> PlayerSessions { get; set; }

        public AccountTransaction AccountTransaction { get; set; }

        public Action CurrentAction { get; set; }
        public decimal? CountedDrop { get; set; }
    }
}