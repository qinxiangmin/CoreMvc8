using Abp.Authorization;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMvc8.Authorization
{
    public class BookAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Book_See, L("BookList"));
        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CoreMvc8Consts.LocalizationSourceName);
        }

    }
}
