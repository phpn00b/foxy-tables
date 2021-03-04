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
using System.Diagnostics;
using System.Runtime.Serialization;

namespace FoxHorn.CasinoSystem.BusinessModel.Tables
{

    public class TablePlayerActivity
    {
        public TablePlayerActivity()
        {
            SubActivity = new List<PlayerSubActivity>();
        }

        /// <summary>
        /// Id of the activity
        /// </summary>
        /// <value></value>
        [DataMember(Name = "id")]
        public long TablePlayerActivityId { get; set; }

        /// <summary>
        /// Id of the player
        /// </summary>
        /// <value></value>
        [DataMember(Name = "pid")]
        public int PlayerId { get; set; }

        /// <summary>
        /// Name of the player.
        /// </summary>
        /// <value></value>
        [DataMember(Name = "name")]
        public string PlayerName { get; set; }

        /// <summary>
        /// The id of the game that this play happened on.
        /// </summary>
        /// <value></value>
        [DataMember(Name = "gid")]
        public int GameId { get; set; }

        /// <summary>
        /// Name of the game that the play happened on.
        /// </summary>
        /// <value></value>
        [DataMember(Name = "gn")]
        public string GameName { get; set; }

        /// <summary>
        /// Game type (ie blackjack,csp,craps etc ). This value doesn't need to be supplied when creating player activity given that each table knows its type. On read operations it will be populated.
        /// </summary>
        /// <value></value>
        [DataMember(Name = "gtid")]
        public short GameTypeId { get; set; }

        /// <summary>
        /// Game Type Name.
        /// </summary>
        /// <value></value>
        [DataMember(Name = "gtn")]
        public string GameTypeName { get; set; }

        /// <summary>
        /// The currency id of the activity record. Always use 1.
        /// </summary>
        /// <value></value>
        [DataMember(Name = "cid")]
        public short CurrencyId { get; set; }

        /// <summary>
        /// Name of the currency leave null.
        /// </summary>
        /// <value></value>
        [DataMember(Name = "cn")]
        public string CurrencyName { get; set; }

        /// <summary>
        /// Time play started
        /// </summary>
        /// <value></value>
        [DataMember(Name = "sd")]
        public virtual DateTime StartDate { get; set; }

        /// <summary>
        /// Time play ended if it has ended
        /// </summary>
        /// <value></value>
        [DataMember(Name = "ed")]
        public virtual DateTime? EndDate { get; set; }

        /// <summary>
        /// Date the activity record was created.
        /// </summary>
        /// <value></value>
        [DataMember(Name = "cd")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The id of the user that created this. Will be set via the API call.
        /// </summary>
        /// <value></value>
        [DataMember(Name = "cbuid")]
        public int CreatedByUserId { get; set; }

        /// <summary>
        /// Username that created this.
        /// </summary>
        /// <value></value>
        [DataMember(Name = "cbln")]
        public string CreatedByLogonName { get; set; }

        /// <summary>
        /// THis is the position of the player at the table ie 1-n. this is useful for camera reviews or to better track when a player has multiple hands in play so that you could track each hand seperatly.
        /// </summary>
        /// <value></value>
        [DataMember(Name = "si")]
        public virtual byte TablePlayerSeqeunce { get; set; }

        /// <summary>
        /// leave blank.
        /// </summary>
        /// <value></value>
        [DataMember(Name = "bcm")]
        public decimal BaseCurrencyMultiplier { get; set; }

        /// <summary>
        /// Total of cash buy in. the server will sum  this up based on sub activity if using real time tracking otherwise you can supply it
        /// </summary>
        /// <value></value>
        [DataMember(Name = "inCash")]
        public virtual int BuyInCash { get; set; }

        /// <summary>
        /// Total of chips buy in. the server will sum  this up based on sub activity if using real time tracking otherwise you can supply it
        /// </summary>
        /// <value></value>
        [DataMember(Name = "inChip")]
        public virtual int BuyInChips { get; set; }

        /// <summary>
        /// Total of chips buy in via slot ticket if you will allow this. the server will sum  this up based on sub activity if using real time tracking otherwise you can supply it
        /// </summary>
        /// <value></value>
        [DataMember(Name = "inTick")]
        public int BuyInTicket { get; set; }

        /// <summary>
        /// Total of cash out. the server will sum  this up based on sub activity if using real time tracking otherwise you can supply it
        /// </summary>
        /// <value></value>
        [DataMember(Name = "out")]
        public virtual int Cashout { get; set; }

        /// <summary>
        /// Net win amount
        /// </summary>
        /// <value></value>
        [DataMember(Name = "win")]
        public int NetWin { get; set; }

        /// <summary>
        /// Card level of player you can leave this blank.
        /// </summary>
        /// <value></value>
        public string MembershipLevelName { get; set; }

        /// <summary>
        /// Flag for if this record was edited after being saved. leave it as false.
        /// </summary>
        /// <value></value>
        public bool IsEdited { get; set; }

        /// <summary>
        /// If you want to associate this with a given table shift.
        /// </summary>
        /// <value></value>
        public int? TableShiftId { get; set; }

        public string DisplayBuyInCash
        {
            get
            {
                if (BuyInCash / BaseCurrencyMultiplier == BuyInCash)
                    return BuyInCash.ToString("N0");
                return $"{(BuyInCash / BaseCurrencyMultiplier).ToString("N0")} ({BuyInCash.ToString("N0")})";
            }
        }

        public string DisplayBuyInChips
        {
            get
            {
                if (BuyInChips / BaseCurrencyMultiplier == BuyInChips)
                    return BuyInChips.ToString("N0");
                return $"{(BuyInChips / BaseCurrencyMultiplier).ToString("N0")} ({BuyInChips.ToString("N0")})";
            }
        }

        public string DisplayBuyInTicket
        {
            get
            {
                if (BuyInTicket / BaseCurrencyMultiplier == BuyInTicket)
                    return BuyInTicket.ToString("N0");
                return $"{(BuyInTicket / BaseCurrencyMultiplier).ToString("N0")} ({BuyInTicket.ToString("N0")})";
            }
        }

        public string DisplayCashout
        {
            get
            {
                if (Cashout / BaseCurrencyMultiplier == Cashout)
                    return Cashout.ToString("N0");
                return $"{(Cashout / BaseCurrencyMultiplier).ToString("N0")} ({Cashout.ToString("N0")})";
            }
        }

        public string DisplayNetWin
        {
            get
            {
                if (NetWin / BaseCurrencyMultiplier == NetWin)
                    return NetWin.ToString("N0");
                return $"{(NetWin / BaseCurrencyMultiplier).ToString("N0")} ({NetWin.ToString("N0")})";
            }
        }

        [DataMember(Name = "iv")]
        public bool IsVoided { get; set; }

        [DataMember(Name = "vbuid")]
        public int? VoidedByUserId { get; set; }

        [DataMember(Name = "vbln")]
        public string VoidedByLogonName { get; set; }

        [DataMember(Name = "vd")]
        public DateTime? VoidedDate { get; set; }

        [DataMember(Name = "src")]
        public byte ItemSourceId { get; set; }

        [DataMember(Name = "caid")]
        public long? ClientActivityId { get; set; }

        [DataMember(Name = "open")]
        public bool IsOpen { get; set; }

        [DataMember(Name = "update")]
        public DateTime? LastUpdate { get; set; }

        [DataMember(Name = "avg")]
        public virtual int AverageBet { get; set; }

        [DataMember(Name = "sub")]
        public List<PlayerSubActivity> SubActivity { get; set; }

        [DataMember(Name = "card")]
        public string CardNumber { get; set; }

        [DataMember(Name = "thumb")]
        public string ThumbnailPath { get; set; }


        [IgnoreDataMember]
        public decimal NetWinCalc
        {
            get
            {
                return BuyInCash + BuyInChips + BuyInTicket - Cashout;
            }
        }

        //this is not a database field
        public bool IsTableShiftOpen { get; set; }
    }
}