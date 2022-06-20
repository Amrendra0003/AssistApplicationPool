using System;

namespace Healthware.Core.Exceptions
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Checks the permission type is correct
        /// </summary>
        /// <param name="permissionType"></param>
        public static void ThrowExceptionIfEnumIsNotCorrect(this Type permissionType)
        {
            if (!permissionType.IsEnum)
                throw new AuthPermissionsException("The permissions must be an enum");
            if (Enum.GetUnderlyingType(permissionType) != typeof(ushort))
                throw new AuthPermissionsException(
                    $"The enum permissions {permissionType.Name} should by 16 bits in size to work.\n" +
                    $"Please add ': ushort' to your permissions declaration, i.e. public enum {permissionType.Name} : ushort " + "{...};");
        }

    }
}
