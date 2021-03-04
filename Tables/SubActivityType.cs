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
namespace FoxHorn.CasinoSystem.BusinessModel.Tables
{
    /// <summary>
    /// This is an enumeration of different types of sub events that can happen
    /// </summary>
    public enum SubActivityType : short
    {
        /// <summary>
        /// The system can force a rating at the end of each hour so that you can get a more uniform data structure for running reports on a hourly basis. Most clients don't use this.
        /// </summary>
        AutomaticEndOfHourRating = 1,

        /// <summary>
        /// User entered rating
        /// </summary>
        ManualRating = 2,

        /// <summary>
        /// When a player buys in either the first time or a rebuy in.
        /// </summary>
        BuyIn = 3,

        /// <summary>
        /// When a player cashes out either partial or full.
        /// </summary>
        Cashout = 4,

        /// <summary>
        /// Not currently used
        /// </summary>
        Payout = 5,

        /// <summary>
        /// When a player exchanges chips "colors up"
        /// </summary>
        ChipExchange = 6,

        /// <summary>
        /// Used to track a single bet being placed
        /// </summary>
        BetPlaced = 7,

        /// <summary>
        /// Automated rating. ie a rating made by some non user processes.
        /// </summary>
        AutomatedRating = 8,

        /// <summary>
        /// Not currently used but here to track end of a given hand
        /// </summary>
        HandStart = 9,

        /// <summary>
        /// Not currently used but here to track end of a given hand
        /// </summary>
        HandEnd = 10,

        /// <summary>
        /// Could be the results of a hand or hand played. not currently used
        /// </summary>
        GameMetaEvent = 11
    }
}