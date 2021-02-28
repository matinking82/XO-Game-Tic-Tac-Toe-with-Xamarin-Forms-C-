using System;
using System.Collections.Generic;
using System.Text;

namespace XO.Utilities
{
    public interface IShowToast
    {
        void ShowLong(string message);
        void ShowShort(string message);
    }
}
