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
    [System.ComponentModel.DisplayName("Phiếu nhập kho")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class PhieuNhapKho : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public PhieuNhapKho(Session session)
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


        private DateTime _NgayNhap;
        [XafDisplayName("Ngày nhập")]
        public DateTime NgayNhap
        {
            get { return _NgayNhap; }
            set { SetPropertyValue<DateTime>(nameof(NgayNhap), ref _NgayNhap, value); }
        }

        public decimal TongTien { get; set; }

        [Association("NhaCungCap-PhieuNhapKho")]
        public NhaCungCap NhaCungCap
        {
            get { return GetPropertyValue<NhaCungCap>(nameof(NhaCungCap)); }
            set { SetPropertyValue(nameof(NhaCungCap), value); }
        }

        public enum TrangThaiPhieuNhap
        {
            [Description("Chờ xác nhận")] 
            ChoXacNhan,
            [Description("Đã nhập kho")]
            DaNhapKho,
            [Description("Đã hủy")]
            DaHuy
        }
        private TrangThaiPhieuNhap _TrangThai;
        [XafDisplayName("Trạng thái")]
        public TrangThaiPhieuNhap TrangThai
        {
            get => _TrangThai;
            set => SetPropertyValue(nameof(TrangThai), ref _TrangThai, value);
        }



        [Association("PhieuNhapKho-ChiTietPhieuNhap")]
        public XPCollection<ChiTietPhieuNhap> ChiTietPhieuNhaps
        {
            get { return GetCollection<ChiTietPhieuNhap>(nameof(ChiTietPhieuNhaps)); }
        }

        [Association("NguoiDung-PhieuNhapKhos")]
        public NguoiDung NguoiLapPhieu
        {
            get => GetPropertyValue<NguoiDung>(nameof(NguoiLapPhieu));
            set => SetPropertyValue(nameof(NguoiLapPhieu), value);
        }

    }
}