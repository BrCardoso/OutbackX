using System;
using OutbackX.Mobile.Config;
using Xamarin.Forms;

[assembly: Dependency(typeof(OutbackX.Mobile.Droid.Config.DbPathConfig))]
namespace OutbackX.Mobile.Droid.Config
{
    public class DbPathConfig : IDbPathConfig
    {
        private string path;

        public string Path => path ??= Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    }
}