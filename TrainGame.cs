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
                        //BuyTrain(); 
                        break;
                    case "2": 
                        //AddWagon(); 
                        break;
                    case "3": 
                        //SimulateStation(); 
                        break;
                    case "4": 
                        //ShowMyTrains(); 
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
    }
}
