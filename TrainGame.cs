using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPrograYProducc
{
    internal class TrainGame
    {
        public List<trainMain> trains = new List<trainMain>();
        private int money = 50;
        private const int costTicket = 3;
        public void GameTrain()
        {
            Console.WriteLine("Simulacion de Trenes");
            bool run = true;
            while (run)
            {
                Console.WriteLine($"\nDinero: ${money} | Trenes: {trains.Count}");
                Console.WriteLine("1) Comprar tren ($30)");
                Console.WriteLine("2) Añadir vagón a tren ($15)");
                Console.WriteLine("3) Siguiente Parada");
                Console.WriteLine("4) Ver trenes");
                Console.WriteLine("5) Salir");
                Console.Write("Opción: ");
                var opt = Console.ReadLine();

                switch (opt)
                {
                    case "1": 
                        BuyTrain(); 
                        break;
                    case "2": 
                        AddWagon(); 
                        break;
                    case "3": 
                        SimulateStation(); 
                        break;
                    case "4": 
                        ShowMyTrains(); 
                        break;
                    case "5": 
                        run = false; 
                        break;
                    default: 
                        Console.WriteLine("Opción inválida."); 
                        break;
                }
            }
        }
        void BuyTrain()
        {
            const int cost = 30;
            if (money < cost) { Console.WriteLine("No tienes dinero."); return; }
            money -= cost;
            int id = trains.Count == 0 ? 1 : trains[trains.Count - 1].Id + 1;
            //trains.Add(new BasicTrain(id));
            Console.WriteLine($"Tren comprado (Id {id}).");
        }
        void AddWagon()
        {
            const int cost = 15;
            Console.Write("Id tren: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("Id inválido."); return; }
            trainMain t = trains.Find(x => x.Id == id);
            if (t == null) { Console.WriteLine("Tren no existe."); return; }
            if (money < cost) { Console.WriteLine("No tienes dinero."); return; }
            money -= cost;
            t.Wagons += 1;
            Console.WriteLine("Vagón añadido.");
        }
        void SimulateStation()
        {
            if (trains.Count == 0) { Console.WriteLine("No hay trenes."); return; }
            Console.WriteLine("Llegaste a una nueva estacion");
            foreach (trainMain t in trains)
            {
                var (boarded, left) = t.SimulateStation();
                int revenue = boarded * costTicket;
                money += revenue;
                Console.WriteLine($"Tren {t.Id}: Bajaron {left}, Subieron {boarded}. Pasajeros {t.Passengers}. +${revenue}");
            }
            Console.WriteLine($"Dinero total: ${money}");
        }
        void ShowMyTrains()
        {
            if (trains.Count == 0) { Console.WriteLine("Sin trenes."); return; }
            foreach (trainMain t in trains) Console.WriteLine(t.ShowData());
        }
    }
}
