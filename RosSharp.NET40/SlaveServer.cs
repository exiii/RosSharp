﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace RosSharp
{
    public class SlaveServer : MarshalByRefObject, ISlave
    {
        private RosTcpListener _listener;
        
        public SlaveServer()
        {
            _listener = new RosTcpListener();
            
            
        }

        public IObservable<Socket> Connect()
        {
            return _listener.Start(8088);
        }


        public override object InitializeLifetimeService()
        {
            return null;
        }

        public object[] GetBusStats(string callerId)
        {
            throw new NotImplementedException();
        }

        public object[] GetBusInfo(string callerId)
        {
            throw new NotImplementedException();
        }

        public object[] GetMasterUri(string callerId)
        {
            throw new NotImplementedException();
        }

        public object[] Shutdown(string callerId, string msg)
        {
            throw new NotImplementedException();
        }

        public object[] GetPid(string callerId)
        {
            throw new NotImplementedException();
        }

        public object[] GetSubscriptions(string callerId)
        {
            throw new NotImplementedException();
        }

        public object[] GetPublications(string callerId)
        {
            throw new NotImplementedException();
        }

        public object[] ParamUpdate(string callerId, string parameterKey, object parameterValue)
        {
            throw new NotImplementedException();
        }

        public object[] PublisherUpdate(string callerId, string topic, string[] publishers)
        {
            throw new NotImplementedException();
        }

        public object[] RequestTopic(string callerId, string topic, object[] protocols)
        {

            var result = new object[3]
            {
                1,
                "Protocol<TCPROS, AdvertiseAddress<192.168.11.4, 8088>>",
                new object[3]{
                    "TCPROS",
                    "192.168.11.4",
                    8088
                }
            };

            return result;
        }
    }
}
