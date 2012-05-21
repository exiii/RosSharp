﻿using System;
using Common.Logging;
using Common.Logging.Simple;
using NDesk.Options;
using RosSharp.Master;

namespace RosSharp.RosCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Ros.HostName = "192.168.11.3";
            Ros.TopicTimeout = 10000;
            Ros.XmlRpcTimeout = 10000;
            int portNumber = 11311;

            var optionSet = new OptionSet()
            {
                {"p|port=", v => portNumber = int.Parse(v)}
            };

            optionSet.Parse(args);

            //LogManager.Adapter = new ConsoleOutLoggerFactoryAdapter();

            var masterServer = new MasterServer(portNumber);

            var rosout = new RosOut();
            rosout.Start();

            Console.WriteLine("ROS_MASTER_URI={0}", masterServer.MasterUri);
            Console.ReadKey();
        }
    }
}
