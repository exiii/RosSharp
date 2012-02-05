﻿using System;
using System.Reactive.Linq;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CookComputing.XmlRpc.Moles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RosSharp.Moles;

namespace RosSharp.Tests
{
    [TestClass]
    public class SlaveClientTest
    {


        [TestMethod]
        [HostType("Moles")]
        public void GetBusInfo_Success()
        {
            var result = new object[3]
            {
                1,
                "bus info",
                new object[0]
            };

            MXmlRpcClientProtocol.AllInstances.UrlSetString = (t1, t2) => { };
            MSlaveProxy.AllInstances.BeginGetBusInfoStringAsyncCallbackObject = (t1, t2, t3, t4) => { t3(null); return null; };
            MSlaveProxy.AllInstances.EndGetBusInfoIAsyncResult = (t1, t2) => result;

            var client = new SlaveClient(new Uri("http://localhost"));

            client.GetBusInfoAsync("/test").First().Is(25346);
        }


        [TestMethod]
        [HostType("Moles")]
        public void GetPid_Success()
        {
            var result = new object[3]
            {
                1,
                "PID: 25346",
                25346
            };

            MXmlRpcClientProtocol.AllInstances.UrlSetString = (t1, t2) => { };
            MSlaveProxy.AllInstances.BeginGetPidStringAsyncCallbackObject = (t1, t2, t3, t4) => { t3(null); return null; };
            MSlaveProxy.AllInstances.EndGetPidIAsyncResult = (t1, t2) => result;

            var client = new SlaveClient(new Uri("http://localhost"));

            client.GetPidAsync("/test").First().Is(25346);
        }

        [TestMethod]
        [HostType("Moles")]
        public void GetMasterUri_Success()
        {
            var result = new object[3]
            {
                1,
                "",
                "http://localhost:11311"
            };

            MXmlRpcClientProtocol.AllInstances.UrlSetString = (t1, t2) => { };
            MSlaveProxy.AllInstances.BeginGetMasterUriStringAsyncCallbackObject = (t1, t2, t3, t4) => { t3(null); return null; };
            MSlaveProxy.AllInstances.EndGetBusInfoIAsyncResult = (t1, t2) => result;

            var client = new SlaveClient(new Uri("http://localhost"));

            client.GetMasterUriAsync("/test").First().Is(new Uri("http://localhost:11311"));
        }



        [TestMethod]
        [HostType("Moles")]
        public void RequestTopic_Success()
        {
            var result = new object[3]
            {
                1,
                "Protocol<TCPROS, AdvertiseAddress<192.168.11.4, 38939>>",
                new object[3]{
                    "TCPROS",
                    "192.168.11.4",
                    38939
                }
            };

            MXmlRpcClientProtocol.AllInstances.UrlSetString = (t1, t2) => { };
            MSlaveProxy.AllInstances.BeginRequestTopicStringStringObjectArrayAsyncCallbackObject = (t1, t2, t3, t4, t5, t6) => { t5(null); return null; };
            MSlaveProxy.AllInstances.EndRequestTopicIAsyncResult = (t1, t2) => result;

            var client = new SlaveClient(new Uri("http://localhost"));

            var topics = client.RequestTopicAsync("/test", "/rosout", new object[1] { new string[1] { "TCPROS" } }).First();


        }

        [TestMethod]
        [HostType("Moles")]
        public void RequestTopic_NoSupportedProtocol()
        {
            var result = new object[3]
            {
                -1,
                "No supported protocols specified.",
                "null"
            };

            MXmlRpcClientProtocol.AllInstances.UrlSetString = (t1, t2) => { };
            MSlaveProxy.AllInstances.BeginRequestTopicStringStringObjectArrayAsyncCallbackObject = (t1, t2, t3, t4, t5, t6) => { t5(null); return null; };
            MSlaveProxy.AllInstances.EndRequestTopicIAsyncResult = (t1, t2) => result;

            var client = new SlaveClient(new Uri("http://localhost"));

            var topics = client.RequestTopicAsync("/test", "/rosout", new object[1] { new string[1] { "UDPROS" } }).First();

        }

        [TestMethod]
        [HostType("Moles")]
        public void RequestTopic_NoPublisher()
        {
            var result = new object[3]
            {
                -1,
                "No publishers for topic: /chatter",
                "null"
            };

            MXmlRpcClientProtocol.AllInstances.UrlSetString = (t1, t2) => { };
            MSlaveProxy.AllInstances.BeginRequestTopicStringStringObjectArrayAsyncCallbackObject = (t1, t2, t3, t4, t5, t6) => { t5(null); return null; };
            MSlaveProxy.AllInstances.EndRequestTopicIAsyncResult = (t1, t2) => result;

            var client = new SlaveClient(new Uri("http://localhost"));

            var topics = client.RequestTopicAsync("/test", "/chatter", new object[1] { new string[1] { "TCPROS" } }).First();

        }
    }
}
