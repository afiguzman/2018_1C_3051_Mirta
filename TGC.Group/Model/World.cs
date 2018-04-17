using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.Core.Geometry;

namespace TGC.Group.Model
{
    public class World
    {
        //piso del mapa
        public TgcPlane Floor { get; set; }
        //longitud de cada lado del mapa
        public int MapLength { get; set; }


    }
}
