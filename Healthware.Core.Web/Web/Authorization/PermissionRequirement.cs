﻿using System;
using Microsoft.AspNetCore.Authorization;

namespace Healthware.Core.Web.Web.Authorization
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement(string permissionName)
        {
            PermissionName = permissionName ?? throw new ArgumentNullException(nameof(permissionName));
        }

        public string PermissionName { get; set; }
    }
}