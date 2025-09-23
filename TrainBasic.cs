using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrograYProducc
{
    internal class TrainBasic : TrainMain
    {
        public TrainBasic(int id) : base(id, wagons: 1, capPerWagon: 30) { }
    }
}
