﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18449
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 5.0.61118.0
// 
namespace SilverlightApplication1.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="ServiceReference1.ImageService")]
    public interface ImageService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:ImageService/DoWork", ReplyAction="urn:ImageService/DoWorkResponse")]
        System.IAsyncResult BeginDoWork(System.AsyncCallback callback, object asyncState);
        
        void EndDoWork(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:ImageService/DownLoad", ReplyAction="urn:ImageService/DownLoadResponse")]
        System.IAsyncResult BeginDownLoad(System.Uri uri, System.AsyncCallback callback, object asyncState);
        
        string EndDownLoad(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:ImageService/DownLoad1", ReplyAction="urn:ImageService/DownLoad1Response")]
        System.IAsyncResult BeginDownLoad1(System.Uri uri, System.AsyncCallback callback, object asyncState);
        
        byte[] EndDownLoad1(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ImageServiceChannel : SilverlightApplication1.ServiceReference1.ImageService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DownLoadCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public DownLoadCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DownLoad1CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public DownLoad1CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public byte[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ImageServiceClient : System.ServiceModel.ClientBase<SilverlightApplication1.ServiceReference1.ImageService>, SilverlightApplication1.ServiceReference1.ImageService {
        
        private BeginOperationDelegate onBeginDoWorkDelegate;
        
        private EndOperationDelegate onEndDoWorkDelegate;
        
        private System.Threading.SendOrPostCallback onDoWorkCompletedDelegate;
        
        private BeginOperationDelegate onBeginDownLoadDelegate;
        
        private EndOperationDelegate onEndDownLoadDelegate;
        
        private System.Threading.SendOrPostCallback onDownLoadCompletedDelegate;
        
        private BeginOperationDelegate onBeginDownLoad1Delegate;
        
        private EndOperationDelegate onEndDownLoad1Delegate;
        
        private System.Threading.SendOrPostCallback onDownLoad1CompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public ImageServiceClient() {
        }
        
        public ImageServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ImageServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ImageServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ImageServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("无法设置 CookieContainer。请确保绑定包含 HttpCookieContainerBindingElement。");
                }
            }
        }
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> DoWorkCompleted;
        
        public event System.EventHandler<DownLoadCompletedEventArgs> DownLoadCompleted;
        
        public event System.EventHandler<DownLoad1CompletedEventArgs> DownLoad1Completed;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SilverlightApplication1.ServiceReference1.ImageService.BeginDoWork(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDoWork(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void SilverlightApplication1.ServiceReference1.ImageService.EndDoWork(System.IAsyncResult result) {
            base.Channel.EndDoWork(result);
        }
        
        private System.IAsyncResult OnBeginDoWork(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((SilverlightApplication1.ServiceReference1.ImageService)(this)).BeginDoWork(callback, asyncState);
        }
        
        private object[] OnEndDoWork(System.IAsyncResult result) {
            ((SilverlightApplication1.ServiceReference1.ImageService)(this)).EndDoWork(result);
            return null;
        }
        
        private void OnDoWorkCompleted(object state) {
            if ((this.DoWorkCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DoWorkCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DoWorkAsync() {
            this.DoWorkAsync(null);
        }
        
        public void DoWorkAsync(object userState) {
            if ((this.onBeginDoWorkDelegate == null)) {
                this.onBeginDoWorkDelegate = new BeginOperationDelegate(this.OnBeginDoWork);
            }
            if ((this.onEndDoWorkDelegate == null)) {
                this.onEndDoWorkDelegate = new EndOperationDelegate(this.OnEndDoWork);
            }
            if ((this.onDoWorkCompletedDelegate == null)) {
                this.onDoWorkCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDoWorkCompleted);
            }
            base.InvokeAsync(this.onBeginDoWorkDelegate, null, this.onEndDoWorkDelegate, this.onDoWorkCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SilverlightApplication1.ServiceReference1.ImageService.BeginDownLoad(System.Uri uri, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDownLoad(uri, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string SilverlightApplication1.ServiceReference1.ImageService.EndDownLoad(System.IAsyncResult result) {
            return base.Channel.EndDownLoad(result);
        }
        
        private System.IAsyncResult OnBeginDownLoad(object[] inValues, System.AsyncCallback callback, object asyncState) {
            System.Uri uri = ((System.Uri)(inValues[0]));
            return ((SilverlightApplication1.ServiceReference1.ImageService)(this)).BeginDownLoad(uri, callback, asyncState);
        }
        
        private object[] OnEndDownLoad(System.IAsyncResult result) {
            string retVal = ((SilverlightApplication1.ServiceReference1.ImageService)(this)).EndDownLoad(result);
            return new object[] {
                    retVal};
        }
        
        private void OnDownLoadCompleted(object state) {
            if ((this.DownLoadCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DownLoadCompleted(this, new DownLoadCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DownLoadAsync(System.Uri uri) {
            this.DownLoadAsync(uri, null);
        }
        
        public void DownLoadAsync(System.Uri uri, object userState) {
            if ((this.onBeginDownLoadDelegate == null)) {
                this.onBeginDownLoadDelegate = new BeginOperationDelegate(this.OnBeginDownLoad);
            }
            if ((this.onEndDownLoadDelegate == null)) {
                this.onEndDownLoadDelegate = new EndOperationDelegate(this.OnEndDownLoad);
            }
            if ((this.onDownLoadCompletedDelegate == null)) {
                this.onDownLoadCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDownLoadCompleted);
            }
            base.InvokeAsync(this.onBeginDownLoadDelegate, new object[] {
                        uri}, this.onEndDownLoadDelegate, this.onDownLoadCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SilverlightApplication1.ServiceReference1.ImageService.BeginDownLoad1(System.Uri uri, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDownLoad1(uri, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        byte[] SilverlightApplication1.ServiceReference1.ImageService.EndDownLoad1(System.IAsyncResult result) {
            return base.Channel.EndDownLoad1(result);
        }
        
        private System.IAsyncResult OnBeginDownLoad1(object[] inValues, System.AsyncCallback callback, object asyncState) {
            System.Uri uri = ((System.Uri)(inValues[0]));
            return ((SilverlightApplication1.ServiceReference1.ImageService)(this)).BeginDownLoad1(uri, callback, asyncState);
        }
        
        private object[] OnEndDownLoad1(System.IAsyncResult result) {
            byte[] retVal = ((SilverlightApplication1.ServiceReference1.ImageService)(this)).EndDownLoad1(result);
            return new object[] {
                    retVal};
        }
        
        private void OnDownLoad1Completed(object state) {
            if ((this.DownLoad1Completed != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DownLoad1Completed(this, new DownLoad1CompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DownLoad1Async(System.Uri uri) {
            this.DownLoad1Async(uri, null);
        }
        
        public void DownLoad1Async(System.Uri uri, object userState) {
            if ((this.onBeginDownLoad1Delegate == null)) {
                this.onBeginDownLoad1Delegate = new BeginOperationDelegate(this.OnBeginDownLoad1);
            }
            if ((this.onEndDownLoad1Delegate == null)) {
                this.onEndDownLoad1Delegate = new EndOperationDelegate(this.OnEndDownLoad1);
            }
            if ((this.onDownLoad1CompletedDelegate == null)) {
                this.onDownLoad1CompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDownLoad1Completed);
            }
            base.InvokeAsync(this.onBeginDownLoad1Delegate, new object[] {
                        uri}, this.onEndDownLoad1Delegate, this.onDownLoad1CompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override SilverlightApplication1.ServiceReference1.ImageService CreateChannel() {
            return new ImageServiceClientChannel(this);
        }
        
        private class ImageServiceClientChannel : ChannelBase<SilverlightApplication1.ServiceReference1.ImageService>, SilverlightApplication1.ServiceReference1.ImageService {
            
            public ImageServiceClientChannel(System.ServiceModel.ClientBase<SilverlightApplication1.ServiceReference1.ImageService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginDoWork(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("DoWork", _args, callback, asyncState);
                return _result;
            }
            
            public void EndDoWork(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("DoWork", _args, result);
            }
            
            public System.IAsyncResult BeginDownLoad(System.Uri uri, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = uri;
                System.IAsyncResult _result = base.BeginInvoke("DownLoad", _args, callback, asyncState);
                return _result;
            }
            
            public string EndDownLoad(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("DownLoad", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginDownLoad1(System.Uri uri, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = uri;
                System.IAsyncResult _result = base.BeginInvoke("DownLoad1", _args, callback, asyncState);
                return _result;
            }
            
            public byte[] EndDownLoad1(System.IAsyncResult result) {
                object[] _args = new object[0];
                byte[] _result = ((byte[])(base.EndInvoke("DownLoad1", _args, result)));
                return _result;
            }
        }
    }
}
