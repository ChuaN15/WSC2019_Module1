using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using WSC2019_Module1.Object;

namespace WSC2019_Module1.Service
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public List<Temp> DepartmentList { get; set; }
        public List<Temp> AssetGroupList { get; set; }

        public Temp SelectedDepartment { get; set; }
        public Temp SelectedAssetGroup { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now.Date;
        public DateTime EndDate { get; set; } = DateTime.Now.Date;
        public string SearchText { get; set; } = "";


        private ObservableCollection<AssetClass> _assetClassList = new ObservableCollection<AssetClass>();
        public ObservableCollection<AssetClass> AssetClassList
        {
            get { return _assetClassList; }
            set
            {
                _assetClassList = value;

                OnPropertyChanged("AssetClassList");
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
        public MainPageViewModel()
        {
            DepartmentList = new List<Temp>();
            DepartmentList.Add(new Temp("Exploration", 1));
            DepartmentList.Add(new Temp("Production", 2));
            DepartmentList.Add(new Temp("Transportation", 3));
            DepartmentList.Add(new Temp("R&D", 4));
            DepartmentList.Add(new Temp("Distribution", 5));
            DepartmentList.Add(new Temp("QHSE", 6));

            AssetGroupList = new List<Temp>();
            AssetGroupList.Add(new Temp("Hydraulic", 1));
            AssetGroupList.Add(new Temp("Electrical", 3));
            AssetGroupList.Add(new Temp("Mechanical", 4));

            service = new AssetService();
        }

        public async Task LoadDataAsync()
        {
            var response = await service.GetAssetListData(StartDate.Date.ToShortDateString(), EndDate.Date.ToShortDateString(),
                SelectedAssetGroup.ID.ToString(), SelectedDepartment.ID.ToString(), SearchText).ConfigureAwait(false);

            AssetClassList = new ObservableCollection<AssetClass>(response);
        }
    }
}
