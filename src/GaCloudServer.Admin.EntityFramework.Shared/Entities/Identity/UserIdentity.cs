// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Microsoft.AspNetCore.Identity;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Identity
{
	public class UserIdentity : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName { get; set; }
	}
}







