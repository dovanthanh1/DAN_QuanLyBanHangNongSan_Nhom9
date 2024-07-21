using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DAN_QuanLyBanHangNongSan.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Người dùng")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class NguoiDung : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public NguoiDung(Session session)
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


        private string _TenDangNhap;
        [XafDisplayName("Tên đăng nhập"), Size(50)]
        public string TenDangNhap
        {
            get { return _TenDangNhap; }
            set { SetPropertyValue<string>(nameof(TenDangNhap), ref _TenDangNhap, value); }
        }


        private string _MatKhau;
        [XafDisplayName("Mật khẩu"), Size(50)]
        public string MatKhau
        {
            get { return _MatKhau; }
            set { SetPropertyValue<string>(nameof(MatKhau), ref _MatKhau, value); }
        }


        private string _HoTen;
        [XafDisplayName("Họ tên"), Size(50)]
        public string HoTen
        {
            get { return _HoTen; }
            set { SetPropertyValue<string>(nameof(HoTen), ref _HoTen, value); }
        }


        private string _Email;
        [XafDisplayName("Email"), Size (50)]
        public string Email
        {
            get { return _Email; }
            set { SetPropertyValue<string>(nameof(Email), ref _Email, value); }
        }


        private string _SoDienThoai;
        [XafDisplayName("Số điện thoại"), Size(10)]
        public string SoDienThoai
        {
            get { return _SoDienThoai; }
            set { SetPropertyValue<string>(nameof(SoDienThoai), ref _SoDienThoai, value); }
        }


        private string _DiaChi;
        [XafDisplayName("Địa chỉ"), Size(50)]
        public string DiaChi
        {
            get { return _DiaChi; }
            set { SetPropertyValue<string>(nameof(DiaChi), ref _DiaChi, value); }
        }

        public enum VaiTro
        {
            [Description("Người dùng")]
            User,
            [Description("Khách vãng lai")]
            KhachVangLai,
            [Description("Quản trị viên")]
            Admin,
            [Description("Nhân viên")]
            NhanVien
        }

        private VaiTro _VaiTro;
        [XafDisplayName("Vai trò")]
        public VaiTro VaiTroNguoiDung
        {
            get => _VaiTro;
            set => SetPropertyValue(nameof(VaiTroNguoiDung), ref _VaiTro, value);
        }

        public void SetPassword(string plainTextPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(plainTextPassword);
                byte[] hash = sha256.ComputeHash(bytes);
                MatKhau = Convert.ToBase64String(hash);
            }
        }

        // Phương thức để kiểm tra mật khẩu
        public bool CheckPassword(string plainTextPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(plainTextPassword);
                byte[] hash = sha256.ComputeHash(bytes);
                string hashedPassword = Convert.ToBase64String(hash);
                return MatKhau == hashedPassword;
            }
        }

        [Association("NguoiDung-DonHang")]
        public XPCollection<DonHang> DonHangs
        {
            get { return GetCollection<DonHang>(nameof(DonHangs)); }
        }

        [Association("NguoiDung-PhieuNhapKhos")] // Tùy chọn, nếu bạn muốn theo dõi người lập phiếu
        public XPCollection<PhieuNhapKho> PhieuNhapKhos
        {
            get { return GetCollection<PhieuNhapKho>(nameof(PhieuNhapKhos)); }
        }

    }
}