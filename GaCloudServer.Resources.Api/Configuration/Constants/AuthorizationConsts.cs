// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

namespace GaCloudServer.Resources.Api.Configuration.Constants
{
    public class AuthorizationConsts
    {
        public const string AdministrationPolicy = "RequireAdministratorRole";
        public const string UserPolicy = "RequireUserRole";
        public const string AdminOrUserPolicy = "RequireAdministratorRoleOrUserRole";
        public const string AdminOrUserEcPolicy = "RequireAdministratorRoleOrUserEcRole";
        public const string AdminOrUserFoPolicy = "RequireAdministratorRoleOrUserFoRole";
        public const string AdminOrUserAllPolicy = "RequireAdministratorRoleOrUserAllRole";
    }
}







