namespace SerialTest
{
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO.Ports;
    using System.Threading;

    class Program
    {
        private static PerformanceCounter _perfCounter;
        private static int Sleep = 1000;

        static void Main(string[] args)
        {
            Sleep = int.Parse(ConfigurationManager.AppSettings["sleep"]);

            _perfCounter = new PerformanceCounter(
                ConfigurationManager.AppSettings["perf:category"],
                ConfigurationManager.AppSettings["perf:counter"],
                ConfigurationManager.AppSettings["perf:instance"]);

            var serialPorts = SerialPort.GetPortNames();

            Console.WriteLine("Which serial port?");
            
            for(var i = 0; i < serialPorts.Length; i++)
            {
                Console.WriteLine(i + ". " + serialPorts[i]);
            }

            int portIndex;
            if(!int.TryParse(Console.ReadLine(), out portIndex))
            {
                Console.WriteLine("Invalid port");
                return;
            }
            
            
            var max = int.Parse(ConfigurationManager.AppSettings["maxValue"]);
            if (serialPorts.Length < portIndex)
            {
                Console.WriteLine("Invalid port");
                return;
            }
            
            using (var port = new SerialPort(serialPorts[portIndex], 9600))
            {
                port.Open();

                while (true)
                {
                    var usage = GetCpuUsage();
                    Console.WriteLine($"Value: {usage.ToString("F")}");

                    var outInt = Math.Min(max, max*(usage/100));
                    port.WriteLine(outInt.ToString());
                    //port.Write(bytes, 0, bytes.Length);

                    Thread.Sleep(Sleep);
                }
            }
        }

        private static double GetCpuUsage()
        {
            return _perfCounter.NextValue();
        }
    }
}
