#pragma checksum "Z:\repos\BangTestDemo2\Pages\NewRun.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "059209bd6f527c71300274962b34cba5739afccc"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BangTestDemo2.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "Z:\repos\BangTestDemo2\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "Z:\repos\BangTestDemo2\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "Z:\repos\BangTestDemo2\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "Z:\repos\BangTestDemo2\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "Z:\repos\BangTestDemo2\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "Z:\repos\BangTestDemo2\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "Z:\repos\BangTestDemo2\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "Z:\repos\BangTestDemo2\_Imports.razor"
using BangTestDemo2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "Z:\repos\BangTestDemo2\_Imports.razor"
using BangTestDemo2.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "Z:\repos\BangTestDemo2\Pages\NewRun.razor"
using BangTestDemo2.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "Z:\repos\BangTestDemo2\Pages\NewRun.razor"
using BangTestDemo2.Data.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/newrun")]
    public partial class NewRun : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 34 "Z:\repos\BangTestDemo2\Pages\NewRun.razor"
       
    private Data.Models.Run newRun;

    protected override async Task OnInitializedAsync()
    {
        newRun = new Data.Models.Run();
    }

    private async Task SubmitNewRun()
    {
        if (!string.IsNullOrEmpty(newRun.BasePackageName) && !string.IsNullOrEmpty(newRun.ComparisonPackageName) && !string.IsNullOrEmpty(newRun.CabsetName))
        {
            newRun.BasePackageId = await context.GetPackageIdByName(newRun.BasePackageName);
            newRun.ComparisonPackageId = await context.GetPackageIdByName(newRun.ComparisonPackageName);
            newRun.SubmissionTime = DateTime.UtcNow;
            newRun.CabsetId = await context.GetCabsetIdByName(newRun.CabsetName);
            newRun.TotalCabCount = await context.GetCabsetCount(newRun.CabsetName);
            newRun.IsCompleted = false;
            newRun.CabsCompleted = 0;

            if (await context.AddNewRun(newRun) != false)
            {
                return;
            }
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SqlDbContext context { get; set; }
    }
}
#pragma warning restore 1591
