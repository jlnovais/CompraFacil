﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.17929.
// 
#pragma warning disable 1591

namespace WSTeste.ClickSMS {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="clicksmsV4Soap", Namespace="http://hm.comprafacil.pt/SIBSClick/webservice/")]
    public partial class clicksmsV4 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback getInfoOperationCompleted;
        
        private System.Threading.SendOrPostCallback getInfoCompraOperationCompleted;
        
        private System.Threading.SendOrPostCallback SaveCompraToBD1OperationCompleted;
        
        private System.Threading.SendOrPostCallback SaveCompraToBD2OperationCompleted;
        
        private System.Threading.SendOrPostCallback SaveCompraToBDValor1OperationCompleted;
        
        private System.Threading.SendOrPostCallback SaveCompraToBDValor2OperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public clicksmsV4() {
            this.Url = global::WSTeste.Properties.Settings.Default.WSTeste_ClickSMS_clicksmsV2;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event getInfoCompletedEventHandler getInfoCompleted;
        
        /// <remarks/>
        public event getInfoCompraCompletedEventHandler getInfoCompraCompleted;
        
        /// <remarks/>
        public event SaveCompraToBD1CompletedEventHandler SaveCompraToBD1Completed;
        
        /// <remarks/>
        public event SaveCompraToBD2CompletedEventHandler SaveCompraToBD2Completed;
        
        /// <remarks/>
        public event SaveCompraToBDValor1CompletedEventHandler SaveCompraToBDValor1Completed;
        
        /// <remarks/>
        public event SaveCompraToBDValor2CompletedEventHandler SaveCompraToBDValor2Completed;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://hm.comprafacil.pt/SIBSClick/webservice/getInfo", RequestNamespace="http://hm.comprafacil.pt/SIBSClick/webservice/", ResponseNamespace="http://hm.comprafacil.pt/SIBSClick/webservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool getInfo(string IDCliente, string password, string dataInicialStr, string dataFinalStr, string tipo, out string referencias, out string IDs, out string error) {
            object[] results = this.Invoke("getInfo", new object[] {
                        IDCliente,
                        password,
                        dataInicialStr,
                        dataFinalStr,
                        tipo});
            referencias = ((string)(results[1]));
            IDs = ((string)(results[2]));
            error = ((string)(results[3]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void getInfoAsync(string IDCliente, string password, string dataInicialStr, string dataFinalStr, string tipo) {
            this.getInfoAsync(IDCliente, password, dataInicialStr, dataFinalStr, tipo, null);
        }
        
        /// <remarks/>
        public void getInfoAsync(string IDCliente, string password, string dataInicialStr, string dataFinalStr, string tipo, object userState) {
            if ((this.getInfoOperationCompleted == null)) {
                this.getInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetInfoOperationCompleted);
            }
            this.InvokeAsync("getInfo", new object[] {
                        IDCliente,
                        password,
                        dataInicialStr,
                        dataFinalStr,
                        tipo}, this.getInfoOperationCompleted, userState);
        }
        
        private void OngetInfoOperationCompleted(object arg) {
            if ((this.getInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getInfoCompleted(this, new getInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://hm.comprafacil.pt/SIBSClick/webservice/getInfoCompra", RequestNamespace="http://hm.comprafacil.pt/SIBSClick/webservice/", ResponseNamespace="http://hm.comprafacil.pt/SIBSClick/webservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool getInfoCompra(string referencia, string IDCliente, string password, out bool pago, out string estado, out string dataUltimoPagamento, out int TotalPagamentos, out string error) {
            object[] results = this.Invoke("getInfoCompra", new object[] {
                        referencia,
                        IDCliente,
                        password});
            pago = ((bool)(results[1]));
            estado = ((string)(results[2]));
            dataUltimoPagamento = ((string)(results[3]));
            TotalPagamentos = ((int)(results[4]));
            error = ((string)(results[5]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void getInfoCompraAsync(string referencia, string IDCliente, string password) {
            this.getInfoCompraAsync(referencia, IDCliente, password, null);
        }
        
        /// <remarks/>
        public void getInfoCompraAsync(string referencia, string IDCliente, string password, object userState) {
            if ((this.getInfoCompraOperationCompleted == null)) {
                this.getInfoCompraOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetInfoCompraOperationCompleted);
            }
            this.InvokeAsync("getInfoCompra", new object[] {
                        referencia,
                        IDCliente,
                        password}, this.getInfoCompraOperationCompleted, userState);
        }
        
        private void OngetInfoCompraOperationCompleted(object arg) {
            if ((this.getInfoCompraCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getInfoCompraCompleted(this, new getInfoCompraCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://hm.comprafacil.pt/SIBSClick/webservice/SaveCompraToBD1", RequestNamespace="http://hm.comprafacil.pt/SIBSClick/webservice/", ResponseNamespace="http://hm.comprafacil.pt/SIBSClick/webservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SaveCompraToBD1(string origem, string IDProduto, string IDCliente, string password, int quantidade, string informacao, int IDUserBackoffice, out string referencia, out string entidade, out decimal valor, out string error) {
            object[] results = this.Invoke("SaveCompraToBD1", new object[] {
                        origem,
                        IDProduto,
                        IDCliente,
                        password,
                        quantidade,
                        informacao,
                        IDUserBackoffice});
            referencia = ((string)(results[1]));
            entidade = ((string)(results[2]));
            valor = ((decimal)(results[3]));
            error = ((string)(results[4]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SaveCompraToBD1Async(string origem, string IDProduto, string IDCliente, string password, int quantidade, string informacao, int IDUserBackoffice) {
            this.SaveCompraToBD1Async(origem, IDProduto, IDCliente, password, quantidade, informacao, IDUserBackoffice, null);
        }
        
        /// <remarks/>
        public void SaveCompraToBD1Async(string origem, string IDProduto, string IDCliente, string password, int quantidade, string informacao, int IDUserBackoffice, object userState) {
            if ((this.SaveCompraToBD1OperationCompleted == null)) {
                this.SaveCompraToBD1OperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveCompraToBD1OperationCompleted);
            }
            this.InvokeAsync("SaveCompraToBD1", new object[] {
                        origem,
                        IDProduto,
                        IDCliente,
                        password,
                        quantidade,
                        informacao,
                        IDUserBackoffice}, this.SaveCompraToBD1OperationCompleted, userState);
        }
        
        private void OnSaveCompraToBD1OperationCompleted(object arg) {
            if ((this.SaveCompraToBD1Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SaveCompraToBD1Completed(this, new SaveCompraToBD1CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://hm.comprafacil.pt/SIBSClick/webservice/SaveCompraToBD2", RequestNamespace="http://hm.comprafacil.pt/SIBSClick/webservice/", ResponseNamespace="http://hm.comprafacil.pt/SIBSClick/webservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SaveCompraToBD2(
                    string origem, 
                    string IDProduto, 
                    string IDCliente, 
                    string password, 
                    int quantidade, 
                    string informacao, 
                    string nome, 
                    string morada, 
                    string codPostal, 
                    string localidade, 
                    string NIF, 
                    string RefExterna, 
                    string telefoneContacto, 
                    string email, 
                    int IDUserBackoffice, 
                    out string referencia, 
                    out string entidade, 
                    out decimal valor, 
                    out string error) {
            object[] results = this.Invoke("SaveCompraToBD2", new object[] {
                        origem,
                        IDProduto,
                        IDCliente,
                        password,
                        quantidade,
                        informacao,
                        nome,
                        morada,
                        codPostal,
                        localidade,
                        NIF,
                        RefExterna,
                        telefoneContacto,
                        email,
                        IDUserBackoffice});
            referencia = ((string)(results[1]));
            entidade = ((string)(results[2]));
            valor = ((decimal)(results[3]));
            error = ((string)(results[4]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SaveCompraToBD2Async(string origem, string IDProduto, string IDCliente, string password, int quantidade, string informacao, string nome, string morada, string codPostal, string localidade, string NIF, string RefExterna, string telefoneContacto, string email, int IDUserBackoffice) {
            this.SaveCompraToBD2Async(origem, IDProduto, IDCliente, password, quantidade, informacao, nome, morada, codPostal, localidade, NIF, RefExterna, telefoneContacto, email, IDUserBackoffice, null);
        }
        
        /// <remarks/>
        public void SaveCompraToBD2Async(
                    string origem, 
                    string IDProduto, 
                    string IDCliente, 
                    string password, 
                    int quantidade, 
                    string informacao, 
                    string nome, 
                    string morada, 
                    string codPostal, 
                    string localidade, 
                    string NIF, 
                    string RefExterna, 
                    string telefoneContacto, 
                    string email, 
                    int IDUserBackoffice, 
                    object userState) {
            if ((this.SaveCompraToBD2OperationCompleted == null)) {
                this.SaveCompraToBD2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveCompraToBD2OperationCompleted);
            }
            this.InvokeAsync("SaveCompraToBD2", new object[] {
                        origem,
                        IDProduto,
                        IDCliente,
                        password,
                        quantidade,
                        informacao,
                        nome,
                        morada,
                        codPostal,
                        localidade,
                        NIF,
                        RefExterna,
                        telefoneContacto,
                        email,
                        IDUserBackoffice}, this.SaveCompraToBD2OperationCompleted, userState);
        }
        
        private void OnSaveCompraToBD2OperationCompleted(object arg) {
            if ((this.SaveCompraToBD2Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SaveCompraToBD2Completed(this, new SaveCompraToBD2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://hm.comprafacil.pt/SIBSClick/webservice/SaveCompraToBDValor1", RequestNamespace="http://hm.comprafacil.pt/SIBSClick/webservice/", ResponseNamespace="http://hm.comprafacil.pt/SIBSClick/webservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SaveCompraToBDValor1(string origem, string IDCliente, string password, decimal valor, string informacao, int IDUserBackoffice, out string referencia, out string entidade, out decimal valorOut, out string error) {
            object[] results = this.Invoke("SaveCompraToBDValor1", new object[] {
                        origem,
                        IDCliente,
                        password,
                        valor,
                        informacao,
                        IDUserBackoffice});
            referencia = ((string)(results[1]));
            entidade = ((string)(results[2]));
            valorOut = ((decimal)(results[3]));
            error = ((string)(results[4]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SaveCompraToBDValor1Async(string origem, string IDCliente, string password, decimal valor, string informacao, int IDUserBackoffice) {
            this.SaveCompraToBDValor1Async(origem, IDCliente, password, valor, informacao, IDUserBackoffice, null);
        }
        
        /// <remarks/>
        public void SaveCompraToBDValor1Async(string origem, string IDCliente, string password, decimal valor, string informacao, int IDUserBackoffice, object userState) {
            if ((this.SaveCompraToBDValor1OperationCompleted == null)) {
                this.SaveCompraToBDValor1OperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveCompraToBDValor1OperationCompleted);
            }
            this.InvokeAsync("SaveCompraToBDValor1", new object[] {
                        origem,
                        IDCliente,
                        password,
                        valor,
                        informacao,
                        IDUserBackoffice}, this.SaveCompraToBDValor1OperationCompleted, userState);
        }
        
        private void OnSaveCompraToBDValor1OperationCompleted(object arg) {
            if ((this.SaveCompraToBDValor1Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SaveCompraToBDValor1Completed(this, new SaveCompraToBDValor1CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://hm.comprafacil.pt/SIBSClick/webservice/SaveCompraToBDValor2", RequestNamespace="http://hm.comprafacil.pt/SIBSClick/webservice/", ResponseNamespace="http://hm.comprafacil.pt/SIBSClick/webservice/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SaveCompraToBDValor2(
                    string origem, 
                    string IDCliente, 
                    string password, 
                    decimal valor, 
                    string informacao, 
                    string nome, 
                    string morada, 
                    string codPostal, 
                    string localidade, 
                    string NIF, 
                    string RefExterna, 
                    string telefoneContacto, 
                    string email, 
                    int IDUserBackoffice, 
                    out string referencia, 
                    out string entidade, 
                    out decimal valorOut, 
                    out string error) {
            object[] results = this.Invoke("SaveCompraToBDValor2", new object[] {
                        origem,
                        IDCliente,
                        password,
                        valor,
                        informacao,
                        nome,
                        morada,
                        codPostal,
                        localidade,
                        NIF,
                        RefExterna,
                        telefoneContacto,
                        email,
                        IDUserBackoffice});
            referencia = ((string)(results[1]));
            entidade = ((string)(results[2]));
            valorOut = ((decimal)(results[3]));
            error = ((string)(results[4]));
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SaveCompraToBDValor2Async(string origem, string IDCliente, string password, decimal valor, string informacao, string nome, string morada, string codPostal, string localidade, string NIF, string RefExterna, string telefoneContacto, string email, int IDUserBackoffice) {
            this.SaveCompraToBDValor2Async(origem, IDCliente, password, valor, informacao, nome, morada, codPostal, localidade, NIF, RefExterna, telefoneContacto, email, IDUserBackoffice, null);
        }
        
        /// <remarks/>
        public void SaveCompraToBDValor2Async(string origem, string IDCliente, string password, decimal valor, string informacao, string nome, string morada, string codPostal, string localidade, string NIF, string RefExterna, string telefoneContacto, string email, int IDUserBackoffice, object userState) {
            if ((this.SaveCompraToBDValor2OperationCompleted == null)) {
                this.SaveCompraToBDValor2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveCompraToBDValor2OperationCompleted);
            }
            this.InvokeAsync("SaveCompraToBDValor2", new object[] {
                        origem,
                        IDCliente,
                        password,
                        valor,
                        informacao,
                        nome,
                        morada,
                        codPostal,
                        localidade,
                        NIF,
                        RefExterna,
                        telefoneContacto,
                        email,
                        IDUserBackoffice}, this.SaveCompraToBDValor2OperationCompleted, userState);
        }
        
        private void OnSaveCompraToBDValor2OperationCompleted(object arg) {
            if ((this.SaveCompraToBDValor2Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SaveCompraToBDValor2Completed(this, new SaveCompraToBDValor2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void getInfoCompletedEventHandler(object sender, getInfoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string referencias {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string IDs {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
        
        /// <remarks/>
        public string error {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[3]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void getInfoCompraCompletedEventHandler(object sender, getInfoCompraCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getInfoCompraCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getInfoCompraCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public bool pago {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string estado {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
        
        /// <remarks/>
        public string dataUltimoPagamento {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[3]));
            }
        }
        
        /// <remarks/>
        public int TotalPagamentos {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[4]));
            }
        }
        
        /// <remarks/>
        public string error {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[5]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void SaveCompraToBD1CompletedEventHandler(object sender, SaveCompraToBD1CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SaveCompraToBD1CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SaveCompraToBD1CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string referencia {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string entidade {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
        
        /// <remarks/>
        public decimal valor {
            get {
                this.RaiseExceptionIfNecessary();
                return ((decimal)(this.results[3]));
            }
        }
        
        /// <remarks/>
        public string error {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[4]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void SaveCompraToBD2CompletedEventHandler(object sender, SaveCompraToBD2CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SaveCompraToBD2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SaveCompraToBD2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string referencia {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string entidade {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
        
        /// <remarks/>
        public decimal valor {
            get {
                this.RaiseExceptionIfNecessary();
                return ((decimal)(this.results[3]));
            }
        }
        
        /// <remarks/>
        public string error {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[4]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void SaveCompraToBDValor1CompletedEventHandler(object sender, SaveCompraToBDValor1CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SaveCompraToBDValor1CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SaveCompraToBDValor1CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string referencia {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string entidade {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
        
        /// <remarks/>
        public decimal valorOut {
            get {
                this.RaiseExceptionIfNecessary();
                return ((decimal)(this.results[3]));
            }
        }
        
        /// <remarks/>
        public string error {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[4]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void SaveCompraToBDValor2CompletedEventHandler(object sender, SaveCompraToBDValor2CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SaveCompraToBDValor2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SaveCompraToBDValor2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string referencia {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public string entidade {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[2]));
            }
        }
        
        /// <remarks/>
        public decimal valorOut {
            get {
                this.RaiseExceptionIfNecessary();
                return ((decimal)(this.results[3]));
            }
        }
        
        /// <remarks/>
        public string error {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[4]));
            }
        }
    }
}

#pragma warning restore 1591