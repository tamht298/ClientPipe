using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_pipe
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new NamedPipeServerStream("PipeOfPiece");
            Console.WriteLine("------------CLIENT-------------");
            Console.WriteLine("Client waiting connect...");
            client.WaitForConnection();
            Console.WriteLine("Client connected to server!");
            StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);
            while (true)
            {
                Console.WriteLine("CLient:");

                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input)) break;
                writer.WriteLine(input);
                writer.Flush();
                Console.WriteLine("Server:" + reader.ReadLine());
            }
        }
    }
}