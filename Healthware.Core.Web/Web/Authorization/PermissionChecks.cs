using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using Healthware.Core.Constants;
using Healthware.Core.Entities;

[assembly: InternalsVisibleTo("Test")]
namespace Healthware.Core.Web.Web.Authorization
{
    public static class PermissionChecks
    {

        /// <summary>
        /// This returns true if the current user has the permission
        /// </summary>
        /// <param name="user"></param>
        /// <param name="permissionToCheck"></param>
        /// <returns></returns>
        public static bool HasPermission<TEnumPermissions>(this ClaimsPrincipal user, TEnumPermissions permissionToCheck)
            where TEnumPermissions : Enum
        {
            var packedPermissions = user.GetPackedPermissionsFromUser();
            if (packedPermissions == null)
                return false;
            var permissionAsChar = (char)Convert.ChangeType(permissionToCheck, typeof(char));
            return packedPermissions.IsThisPermissionAllowed(permissionAsChar);
        }

        /// <summary>
        /// This is used by the policy provider to check the permission name string
        /// </summary>
        /// <param name="packedPermissions"></param>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        public static bool ThisPermissionIsAllowed(this string packedPermissions, string permissionName)
        {
            var usersPermissions = packedPermissions.UnpackPermissionsFromString().ToArray();

            if (!Enum.TryParse(permissionName, true, out Permissions permissionToCheck))
                throw new InvalidEnumArgumentException($"{permissionName} could not be converted to a {nameof(Permissions)}.");

            return usersPermissions.Contains(permissionToCheck);
        }


        //-------------------------------------------------------
        //private methods

        private static bool IsThisPermissionAllowed(this string packedPermissions, char permissionAsChar)
        {
            return packedPermissions.Contains(permissionAsChar) ||
                   packedPermissions.Contains(Application.PackedAccessAllPermission);
        }

        /// <summary>
        /// This returns the AuthP packed permissions. Can be null if no user, or not packed permissions claims
        /// </summary>
        /// <param name="user">The current ClaimsPrincipal user</param>
        /// <returns>The packed permissions, or null if not logged in</returns>
        public static string GetPackedPermissionsFromUser(this ClaimsPrincipal user)
        {
            return user?.Claims.SingleOrDefault(x => x.Type == Application.PackedPermissionClaimType)?.Value;
        }
    }
}
