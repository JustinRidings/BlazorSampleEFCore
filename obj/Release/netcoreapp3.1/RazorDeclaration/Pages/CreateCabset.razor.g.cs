#pragma checksum "Z:\repos\BangTestDemo2\Pages\CreateCabset.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c81fb52eb4da992b07c52995145e9eb343922d47"
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
#line 2 "Z:\repos\BangTestDemo2\Pages\CreateCabset.razor"
using BangTestDemo2.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "Z:\repos\BangTestDemo2\Pages\CreateCabset.razor"
using BangTestDemo2.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "Z:\repos\BangTestDemo2\Pages\CreateCabset.razor"
using System.Diagnostics;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/newcabset")]
    public partial class CreateCabset : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 21 "Z:\repos\BangTestDemo2\Pages\CreateCabset.razor"
       
    Data.Models.CabSet newCabset;
    private bool IsSuccess;
    private Stopwatch s;
    private int NewCabsetId;

    protected override async Task OnInitializedAsync()
    {
        newCabset = new Data.Models.CabSet();
        IsSuccess = false;
        s = new Stopwatch();
    }

    public async Task SubmitCabset()
    {
        newCabset.CabConfigLocation = "foo";
        newCabset.CabCount = 1;
        newCabset.CabTypes = "Usermode";
        newCabset.CreatedDate = DateTime.UtcNow;
        await context.AddNewCabset(newCabset);
        NewCabsetId = newCabset.CabsetId;
        this.StateHasChanged();

        s.Start();

        while(s.ElapsedMilliseconds <= 5000)
        {

        }

        await this.OnInitializedAsync();

    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SqlDbContext context { get; set; }
    }
}
#pragma warning restore 1591
