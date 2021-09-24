using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    /* This will require classes to fufill promises of BOTH of these interfaces*/
    public interface IDigitalProductModel : IProductModel
    {
        int TotalDownloadsLeft { get;}
    }
}
