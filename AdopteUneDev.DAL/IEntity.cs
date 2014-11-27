using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopteUneDev.DAL
{
    interface IEntity<T,U> where T:Dictionary<string,U>
        where U:struct
    {
        T Key { get; }
    }
}
