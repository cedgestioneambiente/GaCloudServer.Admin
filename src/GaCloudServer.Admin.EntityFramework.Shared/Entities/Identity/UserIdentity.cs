// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Microsoft.AspNetCore.Identity;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Identity
{
	public class UserIdentity : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get; set; }
		public string OfficePhoneNumber { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public bool ShowInContacts { get; set; }
		public bool ShowEmailInContacts { get; set; }
		public bool ShowInApp { get; set; }

	}
}







