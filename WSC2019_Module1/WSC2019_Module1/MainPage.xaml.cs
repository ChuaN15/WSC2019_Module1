using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSC2019_Module1.Object;
using WSC2019_Module1.Service;
using Xamarin.Forms;

namespace WSC2019_Module1
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm;
        double width, height;
        StackOrientation Orientation;
        public MainPage()
        {
            InitializeComponent();
            vm = new MainPageViewModel();
            this.BindingContext = vm;

            DeptPicker.SelectedIndex = 0;
            AssetPicker.SelectedIndex = 0;
            vm.LoadDataAsync();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    //Horizontal
                    vm.IsHorizontal = true;
                    vm.IsVerticle = false;
                }
                else
                {
                    //Vertical
                    vm.IsVerticle = true;
                    vm.IsHorizontal = false;
                }
            }
        }

        void StartDateTapped(object sender, EventArgs args)
        {
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            vm.SearchText = searchEditor.Text;
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if(vm.EndDate < vm.StartDate)
            {
                DisplayAlert("Alert", "End date must be after or same date with start date", "OK");
                
            }
            else
            {
                vm.StartDate = e.NewDate;
                vm.LoadDataAsync();
            }
        }

        private void DatePicker_EndDateSelected(object sender, DateChangedEventArgs e)
        {
            if (vm.EndDate < vm.StartDate)
            {
                DisplayAlert("Alert", "End date must be after or same date with start date", "OK");
            }
            else
            {
                vm.EndDate = e.NewDate;
                vm.LoadDataAsync();
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage();
            App.Current.MainPage.Navigation.PushAsync(new AssetRegisteringPage());
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            vm.SelectedDepartment = (Temp)DeptPicker.SelectedItem;
            vm.SelectedAssetGroup = (Temp)AssetPicker.SelectedItem;
            vm.LoadDataAsync();
        }

        
    }
}
