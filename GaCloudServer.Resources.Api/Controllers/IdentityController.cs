// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using AutoMapper;
using GaCloudServer.Resources.Api.Configuration.Constants;
using GaCloudServer.Resources.Api.ExceptionHandling;
using GaCloudServer.Resources.Api.Resources;
using GaCloudServer.Shared.Dtos.Extended;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Skoruba.Duende.IdentityServer.Admin.BusinessLogic.Identity.Dtos.Identity;
using Skoruba.Duende.IdentityServer.Admin.BusinessLogic.Identity.Services.Interfaces;

namespace GaCloudServer.Resources.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserAllPolicy)]
    public class IdentityController<TUserDto, TRoleDto, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
            TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
            TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto> : ControllerBase
        where TUserDto : ExtendedUserDto<TKey>, new()
        where TRoleDto : RoleDto<TKey>, new()
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TUserLogin : IdentityUserLogin<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
        where TUserToken : IdentityUserToken<TKey>
        where TUsersDto : UsersDto<TUserDto, TKey>
        where TRolesDto : RolesDto<TRoleDto, TKey>
        where TUserRolesDto : UserRolesDto<TRoleDto, TKey>
        where TUserClaimsDto : UserClaimsDto<TUserClaimDto, TKey>, new()
        where TUserProviderDto : UserProviderDto<TKey>
        where TUserProvidersDto : UserProvidersDto<TUserProviderDto, TKey>
        where TUserChangePasswordDto : UserChangePasswordDto<TKey>
        where TRoleClaimsDto : RoleClaimsDto<TRoleClaimDto, TKey>
        where TUserClaimDto : UserClaimDto<TKey>
        where TRoleClaimDto : RoleClaimDto<TKey>
    {
        private readonly IIdentityService<TUserDto, TRoleDto, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
            TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
            TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto> _identityService;

        private readonly IApiErrorResources _errorResources;

        public IdentityController(IIdentityService<TUserDto, TRoleDto, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
                TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
                TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto> identityService, IApiErrorResources errorResources)
        {
            _identityService = identityService;
            _errorResources = errorResources;
        }

        [HttpGet("GetRolesAsync")]
        public async Task<ActionResult<TRoleDto>> GetRoleByIdAsync()
        {
            var role = await _identityService.GetRolesAsync();

            return Ok(role);
        }

        [HttpGet("GetRoleByIdAsync/{id}")]
        public async Task<ActionResult<TRoleDto>> GetRoleByIdAsync(TKey id)
        {
            var role = await _identityService.GetRoleAsync(id.ToString());

            return Ok(role);
        }

        [HttpGet("GetRolesByFilterAsync/{searchText}")]
        public async Task<ActionResult<TRolesDto>> GetRolesByFilterAsync(string searchText, int page = 1, int pageSize = 10)
        {
            var rolesDto = await _identityService.GetRolesAsync(searchText, page, pageSize);

            return Ok(rolesDto);
        }

        [HttpGet("GetUsersAsync")]
        public async Task<ActionResult<TUsersDto>> GetUsersAsync()
        {
            var usersDto = await _identityService.GetUsersAsync("", 1,1000);

            return Ok(usersDto);
        }

        [HttpPost("GetRolesUsersAsync")]
        public async Task<ActionResult<TUsersDto>> GetRolesUsersAsync([FromBody] string[] roles)
        {
            //Estendere selezione a + di 10 persone
            List<TUsersDto> users = new List<TUsersDto>();
            foreach (var role in roles)
            {
                var rolesFound = await _identityService.GetRolesAsync(role.ToString(),1,100);
                if (rolesFound.TotalCount > 0)
                {
                    var result = await _identityService.GetRoleUsersAsync(rolesFound.Roles.Where(x=>x.Name==role).FirstOrDefault().Id.ToString(), null,1,100);
                    users.Add(result);
                }
            }

            return Ok(users.Distinct());

        }




    }
}







