using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LivrariaWeb.Models;

[assembly: PreApplicationStartMethod(typeof(UnityWebActivator), nameof(UnityWebActivator.Start))]

namespace LivrariaWeb.Models
{
    public static class UnityWebActivator
    {
        public static void Shutdown()
        {
            UnityConfig.GetConfiguredContainer().Dispose();
        }

        public static void Start()
        {
            DependencyResolver.SetResolver(new UnityDependencyResolver.Lib.UnityMVCDependencyResolver(UnityConfig.GetConfiguredContainer()));
        }
    }
}