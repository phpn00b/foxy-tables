#region Legal
// CasinoSystem/CasinoSystem.Cage.Business.Model/AccountTransaction.cs
// Copyright (c) 2011 - 2012 FoxHorn Solutions, LLC. All Rights Reserved.
// Information Contained Herein is Proprietary and Confidential.
//
// The document is the property of FoxHorn Solutions, LLC and may not be
// disclosed, distributed, or reproduced without the express
// written permission of FoxHorn Solutions, LLC.
// Author: Matt Van Horn
// Created: 11/27/2012 12:40 AM
#endregion
using System;
using System.Runtime.Serialization;

namespace FoxHorn.CasinoSystem.BusinessModel.Tables
{
	public class PlayerSubActivity
	{
		/// <summary>
		/// Primary key for each sub activity record
		/// </summary>
		/// <value></value>
		[DataMember(Name = "id")]
		public long PlayerSubActivityId { get; set; }

		/// <summary>
		/// ID for the given player session ie PlayerActivity can have n PlayerSubActivity
		/// </summary>
		/// <value></value>
		[DataMember(Name = "paid")]
		public long PlayerActivityId { get; set; }

		/// <summary>
		/// When it was created
		/// </summary>
		/// <value></value>
		[DataMember(Name = "cd")]
		public DateTime CreatedDate { get; set; }

		/// <summary>
		/// When the player session ended
		/// </summary>
		/// <value></value>
		[DataMember(Name = "ed")]
		public DateTime? EndedDate { get; set; }

		/// <summary>
		/// Id of the system user that created this. If you leave it 0 the system will fill it in for you. If the user calling the api has impersonate permission it will allow you to claim to be any user you want. Otherwise it will always override any value with the correct value.
		/// </summary>
		/// <value></value>
		[DataMember(Name = "cbuid")]
		public int CreatedByUserId { get; set; }

		/// <summary>
		/// The name of the user that created this. can be left blank when creating records
		/// </summary>
		/// <value></value>
		[DataMember(Name = "cbuln")]
		public string CreatedByLogonName { get; set; }

		/// <summary>
		/// The type of sub activity
		/// </summary>
		/// <value></value>
		[DataMember(Name = "type")]
		public short SubActivityTypeId { get; set; }

		/// <summary>
		/// Entity ID that this is related to. leave this null. We will likely use this field to identify the bet that a given bet is associated with down the road.
		/// </summary>
		/// <value></value>
		[DataMember(Name = "reid")]
		public long? ReferenceEntityId { get; set; }

		/// <summary>
		/// Any message you wish to associate with the record. 250 char max
		/// </summary>
		/// <value></value>
		[DataMember(Name = "d")]
		public string Details { get; set; }

		/// <summary>
		/// The id of the user that voided this. leave it null
		/// </summary>
		/// <value></value>
		[DataMember(Name = "vbuid")]
		public int? VoidedByUserId { get; set; }

		/// <summary>
		/// The user name that voided this sub activity if it was voided
		/// </summary>
		/// <value></value>
		[DataMember(Name = "vbln")]
		public string VoidedByLogonName { get; set; }

		/// <summary>
		/// If it is voided leave this as false unless you wish to call the api again to void a given sub activity which is fully supported.
		/// </summary>
		/// <value></value>
		[DataMember(Name = "iv")]
		public bool IsVoided { get; set; }

		/// <summary>
		/// A value for the activity ie for rating or bet it is the amount of the bet or average bet.
		/// </summary>
		/// <value></value>
		[DataMember(Name = "av")]
		public int? ActivityValue { get; set; }

		/// <summary>
		/// This is an id a remote system used for a equilivant record. ie our system keeps a on device database and can run without the server being up (to an extent) and when it comes back up it will sync. This is the id of the sub acitivty record issued by sqllite on the terminal.
		/// </summary>
		/// <value></value>
		[DataMember(Name = "csaid")]
		public long? ClientSubActivityId { get; set; }

		/// <summary>
		/// Date the record was voided
		/// </summary>
		/// <value></value>
		[DataMember(Name = "vd")]
		public DateTime? VoidedDate { get; set; }

		[DataMember(Name = "log")]
		public TableEventLog TableEventLog { get; set; }

		/// <summary>
		/// What enumerated type this activity is.
		/// </summary>
		/// <value></value>
		[IgnoreDataMember]
		public SubActivityType SubActivityType
		{
			get { return (SubActivityType)SubActivityTypeId; }
			set { SubActivityTypeId = (short)value; }
		}

		[IgnoreDataMember]
		public int DurationInMinutes
		{
			get
			{
				if (EndedDate.HasValue)
					return (EndedDate.Value - CreatedDate).Minutes;
				return -1;
			}
		}

		/// <summary>
		/// only populated when reading data back from the system. This is a full instance of the PlayerActivity record
		/// </summary>
		/// <value></value>
		[IgnoreDataMember]
		public TablePlayerActivity Activity { get; set; }
	}
}