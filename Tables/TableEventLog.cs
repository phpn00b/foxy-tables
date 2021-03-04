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
using System.Runtime.Serialization;
using FoxHorn.CasinoSystem.BusinessModel.Cage.Accounts;

namespace FoxHorn.CasinoSystem.BusinessModel.Tables
{
    public class TableEventLog
    {
        [DataMember(Name = "id")]
        public long TableEventLogId { get; set; }

        [DataMember(Name = "type")]
        public byte EventType { get; set; }

        [DataMember(Name = "gid")]
        public int GameId { get; set; }

        [DataMember(Name = "gn")]
        public string GameName { get; set; }

        [DataMember(Name = "cd")]
        public DateTime CreatedDate { get; set; }

        [DataMember(Name = "cbuid")]
        public int CreatedByUserId { get; set; }

        [DataMember(Name = "cbun")]
        public string CreatedByLogonName { get; set; }

        [DataMember(Name = "ctid")]
        public long? CageTransactionId { get; set; }

        [DataMember(Name = "duid")]
        public int? DealerUserId { get; set; }

        [DataMember(Name = "dun")]
        public string DealerLogonName { get; set; }


        [DataMember(Name = "amt")]
        public decimal Amount { get; set; }

        [DataMember(Name = "pid")]
        public int? PlayerId { get; set; }

        [DataMember(Name = "pname")]
        public string PlayerName { get; set; }

        [DataMember(Name = "vbuid")]
        public int? VoidedByUserId { get; set; }

        [DataMember(Name = "vbun")]
        public string VoidedByLogonName { get; set; }

        [DataMember(Name = "vd")]
        public DateTime? VoidedDate { get; set; }

        [DataMember(Name = "void")]
        public bool IsVoided { get; set; }

        [DataMember(Name = "at")]
        public AccountTransaction AccountTransaction { get; set; }

        [DataMember(Name = "tsid")]
        public int TableShiftId { get; set; }

        [DataMember(Name = "dlid")]
        public string DocumentLogId { get; set; }

        [DataMember(Name = "rdlid")]
        public bool RequestDocumentLogId { get; set; }

        [IgnoreDataMember]
        public TableEventType Type
        {
            get { return (TableEventType)EventType; }
            set { EventType = (byte)value; }
        }


        [DataMember]
        public bool PrintInternally { get; set; }

        [IgnoreDataMember]
        public bool IsPlayerEvent
        {
            get
            {
                switch (Type)
                {
                    case TableEventType.Open:
                    case TableEventType.Close:
                    case TableEventType.TableDrop:
                    case TableEventType.Credit:
                    case TableEventType.Fill:
                    case TableEventType.TableReopen:
                        return false;
                    default:
                        return true;
                }
            }
        }

        public short PrinterId { get; set; }
        public short CurrencyId { get; set; }
        public decimal BaseCurrencyValue { get; set; }
        public decimal CurrencyValue { get; set; }
        public string CurrencySymbol { get; set; }


        public static implicit operator TableEventLog(TableShift model)
        {
            if (model == null)
                return null;
            switch (model.CurrentAction)
            {
                case TableShift.Action.Open:

                    return new TableEventLog
                    {
                        CreatedDate = DateTime.Now,
                        AccountTransaction = model.AccountTransaction,
                        Type = TableEventType.Close,
                        GameId = model.GameId,
                        Amount = model.AccountTransaction.TotalValue,
                        PrintInternally = true
                    };
                case TableShift.Action.Close:
                    return new TableEventLog
                    {
                        CreatedDate = DateTime.Now,
                        AccountTransaction = model.AccountTransaction,
                        Type = TableEventType.Open,
                        GameId = model.GameId,
                        Amount = model.AccountTransaction.TotalValue,
                        PrintInternally = true
                    };
                case TableShift.Action.Fill:

                    return new TableEventLog
                    {
                        TableShiftId = model.TableShiftId,
                        CreatedDate = DateTime.Now,
                        AccountTransaction = model.AccountTransaction,
                        Type = TableEventType.Fill,
                        GameId = model.GameId,
                        Amount = model.AccountTransaction.TotalValue,
                        PrintInternally = true
                    };
                case TableShift.Action.Credit:

                    return new TableEventLog
                    {
                        TableShiftId = model.TableShiftId,
                        CreatedDate = DateTime.Now,
                        AccountTransaction = model.AccountTransaction,
                        Type = TableEventType.Credit,
                        GameId = model.GameId,
                        Amount = model.AccountTransaction.TotalValue,
                        PrintInternally = true
                    };
                case TableShift.Action.Reopen:
                    return new TableEventLog
                    {
                        TableShiftId = model.TableShiftId,

                        CreatedDate = DateTime.Now,
                        AccountTransaction = model.AccountTransaction,
                        Type = TableEventType.TableReopen,
                        GameId = model.GameId,
                        Amount = 0, //because i'm only opening the shift again this is always going to be 0
                        PrintInternally = true
                    };
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}