using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using HealthWare.ActiveASSIST.Repositories;
using Healthware.Core.Constants;
using Healthware.Core.Containers;
using Healthware.Core.Entities;
using Healthware.Core.MultiTenancy.Entities;
using Healthware.Core.Security;
using Healthware.Core.Web.Web.Authorization;

namespace HealthWare.ActiveASSIST.Web.Authentication.JwtBearer
{
    
    public interface IJwtHelper
    {
        public string CreateAccessToken(IEnumerable<Claim> claims, TimeSpan? expiration = null);
        public List<Claim> CreateJwtClaims(ClaimsIdentity identity, string role, long sessionId);
        public string GetEncryptedAccessToken(string accessToken);

        public List<User> ValidateEmailConfirmationToken(List<User> users);

    }
    public class JwtHelper : IJwtHelper
    {
        private readonly TokenAuthConfiguration _tokenAuthConfiguration;
        
        public JwtHelper(TokenAuthConfiguration tokenAuthConfiguration)
        {
          _tokenAuthConfiguration = tokenAuthConfiguration;
        }
        
        public string CreateAccessToken(IEnumerable<Claim> claims, TimeSpan? expiration = null)
        {
            var now = DateTime.UtcNow;

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenAuthConfiguration.Issuer,
                audience: _tokenAuthConfiguration.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(expiration ?? _tokenAuthConfiguration.Expiration),
                signingCredentials: _tokenAuthConfiguration.SigningCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
        
        public  List<Claim> CreateJwtClaims(ClaimsIdentity identity, string role, long sessionId)
        {
            var claims = identity.Claims.ToList();
            var nameIdClaim = claims.First(c => c.Type == ClaimTypes.NameIdentifier);
            var roleService = Resolve.AnImplementationOf<IRoleRepository>();
            var permissionService = Resolve.AnImplementationOf<IRolesPermissionsRepository>();
            var roleEntity = roleService.FindByNameAsync(role, CancellationToken.None).GetAwaiter().GetResult();
            var permissions = permissionService.GetRolesPermissionByRoleId(roleEntity.Id).GetAwaiter().GetResult();
            var permissionsForUser = permissions.Select(s => s.Permission).Distinct()
                .Select(x => (Permissions) Enum.Parse(typeof(Permissions), x.Name));
            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            claims.AddRange(new[]
            {   new Claim(ClaimTypes.Role, role),
                new Claim(Application.PackedPermissionClaimType, permissionsForUser.PackPermissionsIntoString()),
                new Claim(Application.SessionId, sessionId.ToString()),
                new Claim(Constants.UserId,nameIdClaim.Value),
                new Claim(JwtRegisteredClaimNames.Sub, nameIdClaim.Value),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            });

            return claims;
        }

        public string GetEncryptedAccessToken(string accessToken)
        {
            return SimpleStringCipher.Instance.Encrypt(accessToken, Application.DefaultPassPhrase);
        }

        public List<User> ValidateEmailConfirmationToken(List<User> users)
        {
            var tokenExpiredUsers = new List<User>();
            users.ForEach(s =>
            {
                

            });
            return tokenExpiredUsers;
        }
    }
}