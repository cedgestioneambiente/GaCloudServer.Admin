// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GaCloudServer.Admin.Api.Configuration.Constants;
using GaCloudServer.Admin.Api.Dtos.Roles;
using GaCloudServer.Admin.Api.Dtos.Users;
using GaCloudServer.Admin.Api.ExceptionHandling;
using GaCloudServer.Admin.Api.Helpers.Localization;
using GaCloudServer.Admin.Api.Resources;
using Skoruba.Duende.IdentityServer.Admin.BusinessLogic.Identity.Dtos.Identity;
using Skoruba.Duende.IdentityServer.Admin.BusinessLogic.Identity.Services.Interfaces;
using GaCloudServer.Shared.Dtos.Extended;
using GaCloudServer.Shared.Dtos.Identity;
using System.Linq;

namespace GaCloudServer.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdminOrUserPolicy)]
    public class UsersController<TUserDto, TRoleDto, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
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
        private readonly IGenericControllerLocalizer<UsersController<TUserDto, TRoleDto, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
            TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
            TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto>> _localizer;

        private readonly IMapper _mapper;
        private readonly IApiErrorResources _errorResources;

        public UsersController(IIdentityService<TUserDto, TRoleDto, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
                TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
                TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto> identityService,
            IGenericControllerLocalizer<UsersController<TUserDto, TRoleDto, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
                TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
                TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto>> localizer, IMapper mapper, IApiErrorResources errorResources)
        {
            _identityService = identityService;
            _localizer = localizer;
            _mapper = mapper;
            _errorResources = errorResources;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TUserDto>> Get(TKey id)
        {
            var user = await _identityService.GetUserAsync(id.ToString());

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<TUsersDto>> Get(string searchText, int page = 1, int pageSize = 10)
        {
            var usersDto = await _identityService.GetUsersAsync(searchText, page, pageSize);

            return Ok(usersDto);
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<TUserDto>> Post([FromBody]TUserDto user)
        {
            if (!EqualityComparer<TKey>.Default.Equals(user.Id, default))
            {
                return BadRequest(_errorResources.CannotSetId());
            }

            var (identityResult, userId) = await _identityService.CreateUserAsync(user);
            var createdUser = await _identityService.GetUserAsync(userId.ToString());

            return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]TUserDto user)
        {
            await _identityService.GetUserAsync(user.Id.ToString());
            await _identityService.UpdateUserAsync(user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(TKey id)
        {
            if (IsDeleteForbidden(id))
                return StatusCode((int)System.Net.HttpStatusCode.Forbidden);

            var user = new TUserDto { Id = id };

            await _identityService.GetUserAsync(user.Id.ToString());
            await _identityService.DeleteUserAsync(user.Id.ToString(), user);

            return Ok();
        }

        private bool IsDeleteForbidden(TKey id)
        {
            var userId = User.FindFirst(JwtClaimTypes.Subject);

            return userId == null ? false : userId.Value == id.ToString();
        }

        [HttpGet("{id}/Roles")]
        public async Task<ActionResult<UserRolesApiDto<TRoleDto>>> GetUserRoles(TKey id, int page = 1, int pageSize = 10)
        {
            var userRoles = await _identityService.GetUserRolesAsync(id.ToString(), page, pageSize);
            var userRolesApiDto = _mapper.Map<UserRolesApiDto<TRoleDto>>(userRoles);

            return Ok(userRolesApiDto);
        }

        [HttpPost("Roles")]
        public async Task<IActionResult> PostUserRoles([FromBody]UserRoleApiDto<TKey> role)
        {
            var userRolesDto = _mapper.Map<TUserRolesDto>(role);

            await _identityService.GetUserAsync(userRolesDto.UserId.ToString());
            await _identityService.GetRoleAsync(userRolesDto.RoleId.ToString());
            
            await _identityService.CreateUserRoleAsync(userRolesDto);

            return Ok();
        }

        [HttpDelete("Roles")]
        public async Task<IActionResult> DeleteUserRoles([FromBody]UserRoleApiDto<TKey> role)
        {
            var userRolesDto = _mapper.Map<TUserRolesDto>(role);

            await _identityService.GetUserAsync(userRolesDto.UserId.ToString());
            await _identityService.GetRoleAsync(userRolesDto.RoleId.ToString());

            await _identityService.DeleteUserRoleAsync(userRolesDto);

            return Ok();
        }

        [HttpGet("{id}/Claims")]
        public async Task<ActionResult<UserClaimsApiDto<TKey>>> GetUserClaims(TKey id, int page = 1, int pageSize = 10)
        {
            var claims = await _identityService.GetUserClaimsAsync(id.ToString(), page, pageSize);

            var userClaimsApiDto = _mapper.Map<UserClaimsApiDto<TKey>>(claims);

            return Ok(userClaimsApiDto);
        }

        [HttpPost("Claims")]
        public async Task<IActionResult> PostUserClaims([FromBody]UserClaimApiDto<TKey> claim)
        {
            var userClaimDto = _mapper.Map<TUserClaimsDto>(claim);

            if (!userClaimDto.ClaimId.Equals(default))
            {
                return BadRequest(_errorResources.CannotSetId());
            }

            await _identityService.CreateUserClaimsAsync(userClaimDto);

            return Ok();
        }

        [HttpPut("Claims")]
        public async Task<IActionResult> PutUserClaims([FromBody]UserClaimApiDto<TKey> claim)
        {
            var userClaimDto = _mapper.Map<TUserClaimsDto>(claim);

            await _identityService.GetUserClaimAsync(userClaimDto.UserId.ToString(), userClaimDto.ClaimId);
            await _identityService.UpdateUserClaimsAsync(userClaimDto);

            return Ok();
        }

        [HttpDelete("{id}/Claims")]
        public async Task<IActionResult> DeleteUserClaims([FromRoute]TKey id, int claimId)
        {
            var userClaimsDto = new TUserClaimsDto
            {
                ClaimId = claimId,
                UserId = id
            };

            await _identityService.GetUserClaimAsync(id.ToString(), claimId);
            await _identityService.DeleteUserClaimAsync(userClaimsDto);

            return Ok();
        }

        [HttpGet("{id}/Providers")]
        public async Task<ActionResult<UserProvidersApiDto<TKey>>> GetUserProviders(TKey id)
        {
            var userProvidersDto = await _identityService.GetUserProvidersAsync(id.ToString());
            var userProvidersApiDto = _mapper.Map<UserProvidersApiDto<TKey>>(userProvidersDto);

            return Ok(userProvidersApiDto);
        }

        [HttpDelete("Providers")]
        public async Task<IActionResult> DeleteUserProviders([FromBody]UserProviderDeleteApiDto<TKey> provider)
        {
            var providerDto = _mapper.Map<TUserProviderDto>(provider);

            await _identityService.GetUserProviderAsync(providerDto.UserId.ToString(), providerDto.ProviderKey);
            await _identityService.DeleteUserProvidersAsync(providerDto);

            return Ok();
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> PostChangePassword([FromBody]UserChangePasswordApiDto<TKey> password)
        {
            var userChangePasswordDto = _mapper.Map<TUserChangePasswordDto>(password);

            await _identityService.UserChangePasswordAsync(userChangePasswordDto);

            return Ok();
        }

		[HttpGet("{id}/RoleClaims")]
		public async Task<ActionResult<RoleClaimsApiDto<TKey>>> GetRoleClaims(TKey id, string claimSearchText, int page = 1, int pageSize = 10)
		{
			var roleClaimsDto = await _identityService.GetUserRoleClaimsAsync(id.ToString(), claimSearchText, page, pageSize);
			var roleClaimsApiDto = _mapper.Map<RoleClaimsApiDto<TKey>>(roleClaimsDto);

			return Ok(roleClaimsApiDto);
		}

        [HttpGet("ClaimType/{claimType}/ClaimValue/{claimValue}")]
        public async Task<ActionResult<TUsersDto>> GetClaimUsers(string claimType, string claimValue, int page = 1, int pageSize = 10)
        {
            var usersDto = await _identityService.GetClaimUsersAsync(claimType, claimValue, page, pageSize);

            return Ok(usersDto);
        }

        [HttpGet("ClaimType/{claimType}")]
        public async Task<ActionResult<TUsersDto>> GetClaimUsers(string claimType, int page = 1, int pageSize = 10)
        {
            var usersDto = await _identityService.GetClaimUsersAsync(claimType, null, page, pageSize);

            return Ok(usersDto);
        }

        [HttpGet("GetUserProfileByUserId/{userId}")]
        public async Task<IActionResult> GetUserProfileByUserId(string userId)
        {
            var user = await _identityService.GetUserAsync(userId);
            var userProfile = new UserProfileApiDto();
            userProfile.UserId = user.Id;
            userProfile.UserName = user.UserName;
            userProfile.FirstName = user.FirstName;
            userProfile.LastName = user.LastName;
            userProfile.Email = user.Email;
            userProfile.DateOfBirth = user.DateOfBirth;
            userProfile.PhoneNumber = user.PhoneNumber;
            userProfile.OfficePhoneNumber = user.OfficePhoneNumber;

            return Ok(userProfile);

        }

        [HttpPost("UpdateUserProfile")]
        public async Task<ActionResult<TUserDto>> UpdateUserProfile([FromBody] UserProfileApiDto userProfile)
        {
            TUserDto user=await _identityService.GetUserAsync(userProfile.UserId.ToString());
            user.FirstName = userProfile.FirstName;
            user.LastName = userProfile.LastName;
            user.DateOfBirth = userProfile.DateOfBirth;
            user.OfficePhoneNumber = userProfile.OfficePhoneNumber;
            user.PhoneNumber = userProfile.PhoneNumber;
            await _identityService.UpdateUserAsync(user);

            IdentityUserClaimsDto claim = new IdentityUserClaimsDto();
            claim.ClaimId = 0;
            claim.ClaimType = "given_name";
            claim.ClaimValue = user.FirstName;
            claim.UserId = user.Id.ToString();

            var claims = await _identityService.GetUserClaimsAsync(user.Id.ToString());
            if (claims.Claims.Where(x => x.ClaimType == "given_name").Count() > 0)
            {

                var claimToFind = claims.Claims.Where(x => x.ClaimType == "given_name").FirstOrDefault();
                var claimToDelete = await _identityService.GetUserClaimAsync(user.Id.ToString(), claimToFind.ClaimId);
                await _identityService.DeleteUserClaimAsync(claimToDelete);
                await _identityService.CreateUserClaimsAsync(claim as TUserClaimsDto);
            }
            else
            {
                await _identityService.CreateUserClaimsAsync(claim as TUserClaimsDto);
            }


            claim.ClaimId = 0;
            claim.ClaimType = "family_name";
            claim.ClaimValue = user.LastName;
            claim.UserId = user.Id.ToString();

            if (claims.Claims.Where(x => x.ClaimType == "family_name").Count() > 0)
            {
                var claimToFind = claims.Claims.Where(x => x.ClaimType == "family_name").FirstOrDefault();
                var claimToDelete = await _identityService.GetUserClaimAsync(user.Id.ToString(), claimToFind.ClaimId);
                await _identityService.DeleteUserClaimAsync(claimToDelete);
                await _identityService.CreateUserClaimsAsync(claim as TUserClaimsDto);
            }
            else
            {
                await _identityService.CreateUserClaimsAsync(claim as TUserClaimsDto);
            }

            return Ok(user);

        }

        
    }
}







