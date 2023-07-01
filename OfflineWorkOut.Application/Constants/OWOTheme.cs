using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineWorkOut.Application.Constants
{
    public static class OWOTheme
    {
        public static MudTheme DefaultTheme = new MudTheme()
        {
            Palette = new PaletteLight()
            {
                Primary = Colors.Blue.Darken4,
                Secondary = Colors.Green.Accent4,
                //Define other properties here.  
            },

        };
    }
}
