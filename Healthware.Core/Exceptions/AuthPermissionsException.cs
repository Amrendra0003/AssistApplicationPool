﻿using System;

namespace Healthware.Core.Exceptions
{
    /// <summary>
    /// A AuthPermissions for internal errors
    /// </summary>
    public class AuthPermissionsException : Exception
    {
        /// <summary>
        /// Must contain a message
        /// </summary>
        /// <param name="message"></param>
        public AuthPermissionsException(string message)
            : base(message)
        { }
    }
}
