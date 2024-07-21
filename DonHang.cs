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
    [System.ComponentModel.DisplayName("Đơn hàng")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class DonHang : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public DonHang(Session session)
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


        


        private DateTime _NgayDatHang;
        [XafDisplayName("Ngày đặt hàng")]
        public DateTime NgayDatHang
        {
            get { return _NgayDatHang; }
            set { SetPropertyValue<DateTime>(nameof(NgayDatHang), ref _NgayDatHang, value); }
        }


        public enum TrangThaiDonHang 
        {
            [Description("Chờ xác nhận")]
            ChoXacNhan,
            [Description("Đang xử lý")]
            DangXuLy,
            [Description("Đã giao hàng")]
            DaGiaoHang,
            [Description("Đã hủy")]
            DaHuy
        }

        private TrangThaiDonHang _TrangThai;
        [XafDisplayName("Trạng thái")]
        public TrangThaiDonHang TrangThai
        {
            get => _TrangThai;
            set => SetPropertyValue(nameof(TrangThai), ref _TrangThai, value);
        }

        private decimal _TongTien;
        [XafDisplayName("Tổng tiền")]
        public decimal TongTien
        {
            get { return _TongTien; }
            set { SetPropertyValue<decimal>(nameof(TongTien), ref _TongTien, value); }
        }


        [Association("NguoiDung-DonHang")]
        public NguoiDung NguoiDatHang
        {
            get { return GetPropertyValue<NguoiDung>(nameof(NguoiDatHang)); }
            set { SetPropertyValue(nameof(NguoiDatHang), value); }
        }

        [Association("DonHang-ChiTietDonHang")]
        public XPCollection<ChiTietDonHang> ChiTietDonHangs
        {
            get { return GetCollection<ChiTietDonHang>(nameof(ChiTietDonHangs)); }
        }
    }
}