using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrograYProducc
{
    internal class TrainPremium : TrainMain
    {
        public TrainPremium(int id) : base(id, wagons: 2, capPerWagon: 45) { }
        public override (int boarded, int left) SimulateStation()
        {
            var (boarded, left) = base.SimulateStation();
            int extra = new Random().Next(3, 6);
            int space = Capacity - Passengers;
            int bonus = Math.Min(extra, space);
            Passengers += bonus;
            return (boarded + bonus, left);
        }
    }
}
