﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="KhachHang_Ent", Namespace="http://schemas.datacontract.org/2004/07/Entities")]
    [System.SerializableAttribute()]
    public partial class KhachHang_Ent : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime Date_of_birthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Gioi_tinhField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string HoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Id_khachField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Quoc_tichField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string So_cmndField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SodienthoaiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TenField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date_of_birth {
            get {
                return this.Date_of_birthField;
            }
            set {
                if ((this.Date_of_birthField.Equals(value) != true)) {
                    this.Date_of_birthField = value;
                    this.RaisePropertyChanged("Date_of_birth");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Gioi_tinh {
            get {
                return this.Gioi_tinhField;
            }
            set {
                if ((object.ReferenceEquals(this.Gioi_tinhField, value) != true)) {
                    this.Gioi_tinhField = value;
                    this.RaisePropertyChanged("Gioi_tinh");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Ho {
            get {
                return this.HoField;
            }
            set {
                if ((object.ReferenceEquals(this.HoField, value) != true)) {
                    this.HoField = value;
                    this.RaisePropertyChanged("Ho");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id_khach {
            get {
                return this.Id_khachField;
            }
            set {
                if ((this.Id_khachField.Equals(value) != true)) {
                    this.Id_khachField = value;
                    this.RaisePropertyChanged("Id_khach");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Quoc_tich {
            get {
                return this.Quoc_tichField;
            }
            set {
                if ((object.ReferenceEquals(this.Quoc_tichField, value) != true)) {
                    this.Quoc_tichField = value;
                    this.RaisePropertyChanged("Quoc_tich");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string So_cmnd {
            get {
                return this.So_cmndField;
            }
            set {
                if ((object.ReferenceEquals(this.So_cmndField, value) != true)) {
                    this.So_cmndField = value;
                    this.RaisePropertyChanged("So_cmnd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sodienthoai {
            get {
                return this.SodienthoaiField;
            }
            set {
                if ((object.ReferenceEquals(this.SodienthoaiField, value) != true)) {
                    this.SodienthoaiField = value;
                    this.RaisePropertyChanged("Sodienthoai");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Ten {
            get {
                return this.TenField;
            }
            set {
                if ((object.ReferenceEquals(this.TenField, value) != true)) {
                    this.TenField = value;
                    this.RaisePropertyChanged("Ten");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="KhachHang_Wcf.IKhachHang_WCF")]
    public interface IKhachHang_WCF {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKhachHang_WCF/GetKhachHangs", ReplyAction="http://tempuri.org/IKhachHang_WCF/GetKhachHangsResponse")]
        QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent[] GetKhachHangs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKhachHang_WCF/GetKhachHangs", ReplyAction="http://tempuri.org/IKhachHang_WCF/GetKhachHangsResponse")]
        System.Threading.Tasks.Task<QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent[]> GetKhachHangsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKhachHang_WCF/ThemKhachHang", ReplyAction="http://tempuri.org/IKhachHang_WCF/ThemKhachHangResponse")]
        bool ThemKhachHang(QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent kh_ent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKhachHang_WCF/ThemKhachHang", ReplyAction="http://tempuri.org/IKhachHang_WCF/ThemKhachHangResponse")]
        System.Threading.Tasks.Task<bool> ThemKhachHangAsync(QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent kh_ent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKhachHang_WCF/CapNhatKhachHang", ReplyAction="http://tempuri.org/IKhachHang_WCF/CapNhatKhachHangResponse")]
        bool CapNhatKhachHang(QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent kh_ent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKhachHang_WCF/CapNhatKhachHang", ReplyAction="http://tempuri.org/IKhachHang_WCF/CapNhatKhachHangResponse")]
        System.Threading.Tasks.Task<bool> CapNhatKhachHangAsync(QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent kh_ent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKhachHang_WCF/TimKiem_KhachHang_by_CMND", ReplyAction="http://tempuri.org/IKhachHang_WCF/TimKiem_KhachHang_by_CMNDResponse")]
        QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent[] TimKiem_KhachHang_by_CMND(string CMND);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKhachHang_WCF/TimKiem_KhachHang_by_CMND", ReplyAction="http://tempuri.org/IKhachHang_WCF/TimKiem_KhachHang_by_CMNDResponse")]
        System.Threading.Tasks.Task<QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent[]> TimKiem_KhachHang_by_CMNDAsync(string CMND);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKhachHang_WCF/GetKhachHang_byCMND", ReplyAction="http://tempuri.org/IKhachHang_WCF/GetKhachHang_byCMNDResponse")]
        QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent GetKhachHang_byCMND(string CMND);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKhachHang_WCF/GetKhachHang_byCMND", ReplyAction="http://tempuri.org/IKhachHang_WCF/GetKhachHang_byCMNDResponse")]
        System.Threading.Tasks.Task<QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent> GetKhachHang_byCMNDAsync(string CMND);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IKhachHang_WCFChannel : QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.IKhachHang_WCF, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class KhachHang_WCFClient : System.ServiceModel.ClientBase<QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.IKhachHang_WCF>, QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.IKhachHang_WCF {
        
        public KhachHang_WCFClient() {
        }
        
        public KhachHang_WCFClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public KhachHang_WCFClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KhachHang_WCFClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KhachHang_WCFClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent[] GetKhachHangs() {
            return base.Channel.GetKhachHangs();
        }
        
        public System.Threading.Tasks.Task<QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent[]> GetKhachHangsAsync() {
            return base.Channel.GetKhachHangsAsync();
        }
        
        public bool ThemKhachHang(QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent kh_ent) {
            return base.Channel.ThemKhachHang(kh_ent);
        }
        
        public System.Threading.Tasks.Task<bool> ThemKhachHangAsync(QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent kh_ent) {
            return base.Channel.ThemKhachHangAsync(kh_ent);
        }
        
        public bool CapNhatKhachHang(QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent kh_ent) {
            return base.Channel.CapNhatKhachHang(kh_ent);
        }
        
        public System.Threading.Tasks.Task<bool> CapNhatKhachHangAsync(QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent kh_ent) {
            return base.Channel.CapNhatKhachHangAsync(kh_ent);
        }
        
        public QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent[] TimKiem_KhachHang_by_CMND(string CMND) {
            return base.Channel.TimKiem_KhachHang_by_CMND(CMND);
        }
        
        public System.Threading.Tasks.Task<QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent[]> TimKiem_KhachHang_by_CMNDAsync(string CMND) {
            return base.Channel.TimKiem_KhachHang_by_CMNDAsync(CMND);
        }
        
        public QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent GetKhachHang_byCMND(string CMND) {
            return base.Channel.GetKhachHang_byCMND(CMND);
        }
        
        public System.Threading.Tasks.Task<QUANLYKHACHSAN_PHANTAN.KhachHang_Wcf.KhachHang_Ent> GetKhachHang_byCMNDAsync(string CMND) {
            return base.Channel.GetKhachHang_byCMNDAsync(CMND);
        }
    }
}
