﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.


using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.Text;

namespace WcfService
{
    public class TcpSoap11WSA10TestServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            TcpSoap11WSA10TestServiceHost serviceHost = new TcpSoap11WSA10TestServiceHost(serviceType, baseAddresses);
            return serviceHost;
        }
    }
    public class TcpSoap11WSA10TestServiceHost : TestServiceHostBase<IWcfService>
    {
        protected override string Address { get { return "tcp-Soap11WSA10"; } }

        protected override Binding GetBinding()
        {
            return new CustomBinding(new TextMessageEncodingBindingElement(MessageVersion.Soap11WSAddressing10, Encoding.UTF8), new TcpTransportBindingElement() { PortSharingEnabled = false });
        }

        public TcpSoap11WSA10TestServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }
    }
}
