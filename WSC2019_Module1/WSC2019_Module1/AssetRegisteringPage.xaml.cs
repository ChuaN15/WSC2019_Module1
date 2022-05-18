using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSC2019_Module1.Object;
using WSC2019_Module1.Service;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WSC2019_Module1
{
    public partial class AssetRegisteringPage : ContentPage
    {
        AssetRegisteringViewModel vm;
        double width, height;
        StackOrientation Orientation;
        string PhotoPath;
        public AssetRegisteringPage()
        {
            InitializeComponent();
            vm = new AssetRegisteringViewModel();
            this.BindingContext = vm;

            DeptPicker.SelectedIndex = 0;
            AssetPicker.SelectedIndex = 0;
            LocationPicker.SelectedIndex = 0;
            EmployeePicker.SelectedIndex = 0;
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

        async Task TakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature is not supported on the device
            }
            catch (PermissionException pEx)
            {
                // Permissions not granted
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }
            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            PhotoPath = newFile;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
           
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            TakePhotoAsync();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            vm.SelectedDepartment = (Temp)DeptPicker.SelectedItem;
            vm.SelectedAssetGroup = (Temp)AssetPicker.SelectedItem;
            vm.RefreshAssetID();
        }

        
    }
}
