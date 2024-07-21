using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DAN_QuanLyBanHangNongSan.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Nhà cung cấp")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class NhaCungCap : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public NhaCungCap(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}

        private string _TenNhaCungCap;
        [XafDisplayName("Tên nhà cung cấp"), Size(50)]
        public string TenNhaCungCap
        {
            get { return _TenNhaCungCap; }
            set { SetPropertyValue<string>(nameof(TenNhaCungCap), ref _TenNhaCungCap, value); }
        }


        private string _DiaChi;
        [XafDisplayName("Địa chỉ"),Size(50)]
        public string DiaChi
        {
            get { return _DiaChi; }
            set { SetPropertyValue<string>(nameof(DiaChi), ref _DiaChi, value); }
        }


        private string _SoDienThoai;
        [XafDisplayName("Số điện thoại"), Size(10)]
        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { SetPropertyValue<string>(nameof(SoDienThoai), ref _SoDienThoai, value); }
        }


        private string _Email;
        [XafDisplayName("Email"), Size(40)]
        public string Email
        {
            get { return _Email; }
            set { SetPropertyValue<string>(nameof(Email), ref _Email, value); }
        }

        [Association("NhaCungCap-NongSan")]
        public XPCollection<NongSan> NongSans
        {
            get { return GetCollection<NongSan>(nameof(NongSans)); }
        }

        [Association("NhaCungCap-PhieuNhapKho")]
        public XPCollection<PhieuNhapKho> PhieuNhapKhos
        {
            get { return GetCollection<PhieuNhapKho>(nameof(PhieuNhapKhos)); }
        }


    }
}