using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrograYProducc
{
    abstract class TrainMain
    {
        protected static readonly Random rnd = new Random();
        public abstract string TrainName { get; }
        public int Id { get; }
        public int Wagons { get; set; }
        public int CapacityW { get; protected set; }
        public int Capacity => Wagons * CapacityW;
        public int Passengers { get; protected set; }

        public TrainMain(int id, int wagons, int capPerWagon)
        {
            this.Id = id;
            this.Wagons = wagons;
            this.CapacityW = capPerWagon;
            Passengers = 0;
        }
        public virtual (int boarded, int left) SimulateStation()
        {
            int leave = Passengers == 0 ? 0 : rnd.Next(1, 5);
            leave = Math.Min(leave, Passengers);
            Passengers -= leave;

            int boarding = rnd.Next(7, 12);
            int space = Capacity - Passengers;
            int boarded = Math.Min(boarding, space);
            Passengers += boarded;

            return (boarded, leave);
        }

        public virtual string ShowData() =>
            $"{GetType().Name} Id {Id} | Vagones {Wagons} | Cap {Capacity} | Pasajeros {Passengers}";
        public virtual string ShowName() =>
            $"{TrainName} Id {Id}";
    }
}
