using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrograYProducc
{
    internal class TrainBasic : TrainMain
    {
        public override string TrainName => "[Tren Basico]";

        public TrainBasic(int id) : base(id, wagons: 1, capPerWagon: 30) { }
        public override string ShowData()
        {
            return $"[Tren Basico] Id: {Id} | Vagones: {Wagons} | Capacidad: {Capacity} | Pasajeros: {Passengers}";
        }
    }
}