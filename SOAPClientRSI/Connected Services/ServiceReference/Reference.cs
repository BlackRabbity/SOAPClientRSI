﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://WS/", ConfigurationName="ServiceReference.CinemaImpl")]
    public interface CinemaImpl
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WS/CinemaImpl/getShowingsRequest", ReplyAction="http://WS/CinemaImpl/getShowingsResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference.getShowingsResponse> getShowingsAsync(ServiceReference.getShowingsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WS/CinemaImpl/getLogoRequest", ReplyAction="http://WS/CinemaImpl/getLogoResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference.getLogoResponse> getLogoAsync(ServiceReference.getLogoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WS/CinemaImpl/echoRequest", ReplyAction="http://WS/CinemaImpl/echoResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ServiceReference.echoResponse> echoAsync(ServiceReference.echoRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://WS/")]
    public partial class showing
    {
        
        private film filmField;
        
        private System.DateTime dateField;
        
        private bool dateFieldSpecified;
        
        private room roomField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public film film
        {
            get
            {
                return this.filmField;
            }
            set
            {
                this.filmField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public System.DateTime date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dateSpecified
        {
            get
            {
                return this.dateFieldSpecified;
            }
            set
            {
                this.dateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public room room
        {
            get
            {
                return this.roomField;
            }
            set
            {
                this.roomField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://WS/")]
    public partial class film
    {
        
        private string titleField;
        
        private string directorField;
        
        private string[] actorsField;
        
        private string descriptionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string director
        {
            get
            {
                return this.directorField;
            }
            set
            {
                this.directorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("actors", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=2)]
        public string[] actors
        {
            get
            {
                return this.actorsField;
            }
            set
            {
                this.actorsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://WS/")]
    public partial class seat
    {
        
        private int rowField;
        
        private int columnField;
        
        private string reservationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int row
        {
            get
            {
                return this.rowField;
            }
            set
            {
                this.rowField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public int column
        {
            get
            {
                return this.columnField;
            }
            set
            {
                this.columnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string reservation
        {
            get
            {
                return this.reservationField;
            }
            set
            {
                this.reservationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://WS/")]
    public partial class room
    {
        
        private seat[] seatsField;
        
        private int maxSeatsField;
        
        private int freeSeatsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("seats", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true, Order=0)]
        public seat[] seats
        {
            get
            {
                return this.seatsField;
            }
            set
            {
                this.seatsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public int maxSeats
        {
            get
            {
                return this.maxSeatsField;
            }
            set
            {
                this.maxSeatsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public int freeSeats
        {
            get
            {
                return this.freeSeatsField;
            }
            set
            {
                this.freeSeatsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getShowings", WrapperNamespace="http://WS/", IsWrapped=true)]
    public partial class getShowingsRequest
    {
        
        public getShowingsRequest()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getShowingsResponse", WrapperNamespace="http://WS/", IsWrapped=true)]
    public partial class getShowingsResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://WS/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ServiceReference.showing[] @return;
        
        public getShowingsResponse()
        {
        }
        
        public getShowingsResponse(ServiceReference.showing[] @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getLogo", WrapperNamespace="http://WS/", IsWrapped=true)]
    public partial class getLogoRequest
    {
        
        public getLogoRequest()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getLogoResponse", WrapperNamespace="http://WS/", IsWrapped=true)]
    public partial class getLogoResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://WS/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="base64Binary")]
        public byte[] @return;
        
        public getLogoResponse()
        {
        }
        
        public getLogoResponse(byte[] @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="echo", WrapperNamespace="http://WS/", IsWrapped=true)]
    public partial class echoRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://WS/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg0;
        
        public echoRequest()
        {
        }
        
        public echoRequest(string arg0)
        {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="echoResponse", WrapperNamespace="http://WS/", IsWrapped=true)]
    public partial class echoResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://WS/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string @return;
        
        public echoResponse()
        {
        }
        
        public echoResponse(string @return)
        {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface CinemaImplChannel : ServiceReference.CinemaImpl, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class CinemaImplClient : System.ServiceModel.ClientBase<ServiceReference.CinemaImpl>, ServiceReference.CinemaImpl
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public CinemaImplClient() : 
                base(CinemaImplClient.GetDefaultBinding(), CinemaImplClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.CinemaImplPort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CinemaImplClient(EndpointConfiguration endpointConfiguration) : 
                base(CinemaImplClient.GetBindingForEndpoint(endpointConfiguration), CinemaImplClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CinemaImplClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(CinemaImplClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CinemaImplClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(CinemaImplClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CinemaImplClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference.getShowingsResponse> ServiceReference.CinemaImpl.getShowingsAsync(ServiceReference.getShowingsRequest request)
        {
            return base.Channel.getShowingsAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.getShowingsResponse> getShowingsAsync()
        {
            ServiceReference.getShowingsRequest inValue = new ServiceReference.getShowingsRequest();
            return ((ServiceReference.CinemaImpl)(this)).getShowingsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference.getLogoResponse> ServiceReference.CinemaImpl.getLogoAsync(ServiceReference.getLogoRequest request)
        {
            return base.Channel.getLogoAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.getLogoResponse> getLogoAsync()
        {
            ServiceReference.getLogoRequest inValue = new ServiceReference.getLogoRequest();
            return ((ServiceReference.CinemaImpl)(this)).getLogoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference.echoResponse> ServiceReference.CinemaImpl.echoAsync(ServiceReference.echoRequest request)
        {
            return base.Channel.echoAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.echoResponse> echoAsync(string arg0)
        {
            ServiceReference.echoRequest inValue = new ServiceReference.echoRequest();
            inValue.arg0 = arg0;
            return ((ServiceReference.CinemaImpl)(this)).echoAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.CinemaImplPort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.CinemaImplPort))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:9999/ws/CinemaImpl");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return CinemaImplClient.GetBindingForEndpoint(EndpointConfiguration.CinemaImplPort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return CinemaImplClient.GetEndpointAddress(EndpointConfiguration.CinemaImplPort);
        }
        
        public enum EndpointConfiguration
        {
            
            CinemaImplPort,
        }
    }
}
