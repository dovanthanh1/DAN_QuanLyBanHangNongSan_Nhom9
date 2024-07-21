using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraCharts.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DAN_QuanLyBanHangNongSan.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Nông sản")] 
    //[ImageName("BO_Contact")]
   // [DefaultProperty("TenSP")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("NongSan")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class NongSan : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public NongSan(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }



        private string _TenSp;
        [XafDisplayName("Tên sản phẩm"), Size(50)]
        public string TenSp
        {
            get { return _TenSp; }
            set { SetPropertyValue<string>(nameof(TenSp), ref _TenSp, value); }
        }


        private string _MoTa;
        [XafDisplayName("Mô tả"), Size(100)]
        public string MoTa
        {
            get { return _MoTa; }
            set { SetPropertyValue<string>(nameof(MoTa), ref _MoTa, value); }
        }


        private decimal _GiaBan;
        [XafDisplayName("Giá bán")]
        public decimal GiaBan
        {
            get => _GiaBan;
            set => SetPropertyValue(nameof(GiaBan), ref _GiaBan, value);
        }

        private decimal _GiaNhap; 
        [XafDisplayName("Giá nhập")]
        public decimal GiaNhap 
        {
            get => _GiaNhap;
            set => SetPropertyValue(nameof(GiaNhap), ref _GiaNhap, value);
        }

        private int _SoLuongTon;
        [XafDisplayName("Số lượng tồn"), Size(10)]
        public int SoLuongTon
        {
            get { return _SoLuongTon; }
            set { SetPropertyValue<int>(nameof(SoLuongTon), ref _SoLuongTon, value); }
        }


        private string _Dvt;
        [XafDisplayName("Đơn vị tính"), Size(10)]
        public string Dvt
        {
            get { return _Dvt; }
            set { SetPropertyValue<string>(nameof(Dvt), ref _Dvt, value); }
        }


        private string _XuatXu;
        [XafDisplayName("Xuất xứ"), Size(50)]
        public string XuatXu
        {
            get { return _XuatXu; }
            set { SetPropertyValue<string>(nameof(XuatXu), ref _XuatXu, value); }
        }


        private DateTime _NgayThuHoach;
        [XafDisplayName("Ngày thu hoạch")]
        public DateTime NgayThuHoach
        {
            get { return _NgayThuHoach; }
            set { SetPropertyValue<DateTime>(nameof(NgayThuHoach), ref _NgayThuHoach, value); }
        }

        private DateTime _HanSuDung;
        [XafDisplayName("Hạn sử dụng")]
        public DateTime HanSuDung
        {
            get { return _HanSuDung; }
            set { SetPropertyValue(nameof(HanSuDung), ref _HanSuDung, value); }
        }

        public enum TrangThaiNongSan
        {
            [Description("Còn hàng")]
            ConHang,
            [Description("Hết hàng")]
            HetHang,
            [Description("Ngừng kinh doanh")]
            NgungKinhDoanh
        }

        private TrangThaiNongSan _trangThai; 
        [XafDisplayName("Trạng thái")]
        public TrangThaiNongSan TrangThai 
        {
            get => _trangThai;
            set => SetPropertyValue(nameof(TrangThai), ref _trangThai, value); 
        }

        [PersistentAlias("_GiaBan - _GiaNhap")]
        public decimal LoiNhuan
        {
            get { return (decimal)EvaluateAlias(nameof(LoiNhuan)); }
        }

        public void CapNhatSoLuongTon(int soLuongThayDoi)
        {
            SoLuongTon += soLuongThayDoi;
        }

        public bool KiemTraHanSuDung()
        {
            return HanSuDung < DateTime.Now;
        }

        [Association("DanhMuc-NongSans")]
        public DanhMuc DanhMuc { get; set; }

        [Association("NongSan-LoaiNongSan")]
        public XPCollection<LoaiNongSan> LoaiNongSans
        {
            get { return GetCollection<LoaiNongSan>(nameof(LoaiNongSans)); }
        }

        [Association("NongSan-ChiTietDonHang")]
        public XPCollection<ChiTietDonHang> ChiTietDonHangs
        {
            get { return GetCollection<ChiTietDonHang>(nameof(ChiTietDonHangs)); }
        }

        [Association("NhaCungCap-NongSan")]
        public NhaCungCap NhaCungCap
        {
            get { return GetPropertyValue<NhaCungCap>(nameof(NhaCungCap)); }
            set { SetPropertyValue(nameof(NhaCungCap), value); }
        }

        [Association("NongSan-ChiTietPhieuNhap")]
        public XPCollection<ChiTietPhieuNhap> ChiTietPhieuNhaps
        {
            get { return GetCollection<ChiTietPhieuNhap>(nameof(ChiTietPhieuNhaps)); }
        }
    }

}