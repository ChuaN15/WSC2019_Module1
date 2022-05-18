using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using WSC2019_Module1.Object;

namespace WSC2019_Module1.Service
{
    class AssetRegisteringViewModel : INotifyPropertyChanged
    {
        public List<Temp> DepartmentList { get; set; }
        public List<Temp> AssetGroupList { get; set; }
        public List<Temp> LocationList { get; set; }
        public List<Temp> EmployeeList { get; set; }

        public Temp SelectedDepartment { get; set; }
        public Temp SelectedAssetGroup { get; set; }
        public Temp SelectedLocation { get; set; }
        public Temp SelectedEmployee { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now.Date;
        public DateTime EndDate { get; set; } = DateTime.Now.Date;
        public string SearchText { get; set; } = "";


        private ObservableCollection<AssetClass> _imagesList = new ObservableCollection<AssetClass>();
        public ObservableCollection<AssetClass> ImageList
        {
            get { return _imagesList; }
            set
            {
                _imagesList = value;

                OnPropertyChanged("ImageList");
            }
        }

        private bool _isVerticle = true;
        public bool IsVerticle
        {
            get { return _isVerticle; }
            set
            {
                _isVerticle = value;

                OnPropertyChanged("IsVerticle");
            }
        }

        private string _assetID = "";
        public string AssetID
        {
            get { return _assetID; }
            set
            {
                _assetID = value;

                OnPropertyChanged("AssetID");
            }
        }

        private bool _isHorizontal = false;
        public bool IsHorizontal
        {
            get { return _isHorizontal; }
            set
            {
                _isHorizontal = value;

                OnPropertyChanged("IsHorizontal");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        AssetService service;

        // Constructor
        public AssetRegisteringViewModel()
        {
            DepartmentList = new List<Temp>();
            DepartmentList.Add(new Temp("Exploration", 1));
            DepartmentList.Add(new Temp("Production", 2));
            DepartmentList.Add(new Temp("Transportation", 3));
            DepartmentList.Add(new Temp("R&D", 4));
            DepartmentList.Add(new Temp("Distribution", 5));
            DepartmentList.Add(new Temp("QHSE", 6));

            LocationList = new List<Temp>();
            LocationList.Add(new Temp("Kazan", 1));
            LocationList.Add(new Temp("Volka", 2));
            LocationList.Add(new Temp("Moscow", 3));

            AssetGroupList = new List<Temp>();
            AssetGroupList.Add(new Temp("Hydraulic", 1));
            AssetGroupList.Add(new Temp("Electrical", 3));
            AssetGroupList.Add(new Temp("Mechanical", 4));

            EmployeeList = new List<Temp>();
            EmployeeList.Add(new Temp("Martina Winegarden", 1));
            EmployeeList.Add(new Temp("Rashida Brammer", 1));
            EmployeeList.Add(new Temp("Mohamed Krall", 1));
            EmployeeList.Add(new Temp("Shante Karr", 1));
            EmployeeList.Add(new Temp("Rosaura Rames", 1));
            EmployeeList.Add(new Temp("Toi Courchesne", 1));
            EmployeeList.Add(new Temp("Precious Wismer", 1));
            EmployeeList.Add(new Temp("Josefa Otte", 1));
            EmployeeList.Add(new Temp("Afton Harrington", 1));
            EmployeeList.Add(new Temp("Daphne Morrow", 1));
            EmployeeList.Add(new Temp("Dottie Polson", 1));
            EmployeeList.Add(new Temp("Alleen Nally", 1));
            EmployeeList.Add(new Temp("Hilton Odom", 1));
            EmployeeList.Add(new Temp("Shawn Hillebrand", 1));
            EmployeeList.Add(new Temp("Lorelei Kettler", 1));
            EmployeeList.Add(new Temp("Jalisa Gossage", 1));
            EmployeeList.Add(new Temp("Germaine Sim", 1));
            EmployeeList.Add(new Temp("Suzanna Wollman", 1));
            EmployeeList.Add(new Temp("Jennette Besse", 1));
            EmployeeList.Add(new Temp("Margherita Anstine", 1));
            EmployeeList.Add(new Temp("Earleen Lambright", 1));
            EmployeeList.Add(new Temp("Lyn Valdivia", 1));
            EmployeeList.Add(new Temp("Alycia Couey", 1));
            EmployeeList.Add(new Temp("Lewis Rousey", 1));
            EmployeeList.Add(new Temp("Tanja Profitt", 1));
            EmployeeList.Add(new Temp("Cherie Whyte", 1));
            EmployeeList.Add(new Temp("Efren Leaf", 1));
            EmployeeList.Add(new Temp("Delta Darcangelo", 1));
            EmployeeList.Add(new Temp("Jess Bodnar", 1));
            EmployeeList.Add(new Temp("Sudie Parkhurst", 1));

            service = new AssetService();
        }

        public async Task LoadDataAsync()
        {
        }

        public async Task RefreshAssetID()
        {
            var response = await service.GetAssetID(SelectedDepartment.Name, SelectedAssetGroup.Name).ConfigureAwait(false);
            AssetID = "Asset SN: " + response[0].Name;
        }
    }
}
