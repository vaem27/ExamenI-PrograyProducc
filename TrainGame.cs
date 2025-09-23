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
        public List<TrainMain> trains = new List<TrainMain>();
        private int money = 50;
        private const int costTicket = 3;
        public void GameTrain()
        {
            Console.WriteLine("Simulacion de Trenes");
            bool run = true;
            while (run)
            {
                Console.WriteLine($"\nDinero: ${money} | Trenes: {trains.Count}");
                Console.WriteLine("1) Comprar tren (Basico: $30 - Premium: $45)");
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
            Console.WriteLine("\n1) Comprar tren Basico ($30)");
            Console.WriteLine("2) Comprar tren Premium ($45)");
            Console.Write("Opción: ");
            switch (Console.ReadLine())
            {
                case "1":
                    if (money < 30) { Console.WriteLine("No tienes dinero."); return; }
                    money -= 30;
                    int idB = trains.Count == 0 ? 1 : trains.Max(x => x.Id) + 1;
                    trains.Add(new TrainBasic(idB));
                    Console.WriteLine($"\nTren basico comprado. Id: {idB}");
                    break;
                case "2":
                    if (money < 45) { Console.WriteLine("No tienes dinero."); return; }
                    money -= 45;
                    int idP = trains.Count == 0 ? 1 : trains.Max(x => x.Id) + 1;
                    trains.Add(new TrainPremium(idP));
                    Console.WriteLine($"\nTren premium comprado. Id: {idP}");
                    break;
            }
        }
        void AddWagon()
        {
            const int cost = 15;
            Console.Write("\nId tren: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("\nId inválido."); return; }
            TrainMain t = trains.Find(x => x.Id == id);
            if (t == null) { Console.WriteLine("\nTren no existe."); return; }
            if (money < cost) { Console.WriteLine("\nNo tienes dinero."); return; }
            money -= cost;
            t.Wagons += 1;
            Console.WriteLine("Vagón añadido.");
        }
        void SimulateStation()
        {
            Console.Clear();    
            if (trains.Count == 0) { Console.WriteLine("\nNo hay trenes."); return; }
            Console.WriteLine("Llegaste a una nueva estacion");
            foreach (TrainMain t in trains)
            {
                var (boarded, left) = t.SimulateStation();
                int Gain = boarded * costTicket;
                money += Gain;
                Console.WriteLine($"{t.ShowName()} | Bajaron {left} | Subieron {boarded} | Pasajeros {t.Passengers}. +${Gain}");
            }
            Console.WriteLine($"Dinero total: ${money}");
        }
        void ShowMyTrains()
        {
            Console.Clear();
            if (trains.Count == 0) { Console.WriteLine("\nSin trenes."); return; }
            foreach (TrainMain t in trains) Console.WriteLine(t.ShowData());
        }
    }
}
