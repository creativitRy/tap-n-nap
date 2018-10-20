using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TapNap.Areas.Identity.Data;
using TapNap.Models;

[assembly: HostingStartup(typeof(TapNap.Areas.Identity.IdentityHostingStartup))]
namespace TapNap.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDefaultIdentity<TapNapUser>()
                    .AddEntityFrameworkStores<TapNapContext>();
            });
        }
    }
}