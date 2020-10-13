﻿using System.Management.Automation;
using PnP.PowerShell.Commands.Base;
using Microsoft.SharePoint.Client;

namespace PnP.PowerShell.Commands.Site
{
    [Cmdlet(VerbsCommon.Get, "StructuralNavigationCacheSiteState")]
    public class GetStructuralNavigationCacheSiteState : PnPAdminCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipeline = true)]
        public string SiteUrl;

        protected override void ExecuteCmdlet()
        {
            var url = PnPConnection.CurrentConnection.Url;
            if (ParameterSpecified(nameof(SiteUrl)))
            {
                url = SiteUrl;
            }
            var state = this.Tenant.GetSPOStructuralNavigationCacheSiteState(url);
            ClientContext.ExecuteQueryRetry();
            WriteObject(state);
        }
    }
}
