using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace StudentManagementSystem.ViewModel
{
    public partial class AddNewStudentVM:ObservableObject
    {
        public string StudentID1 { get; set; }
        public string FirstName1 { get; set; }
        public string LastName1 { get; set;}
        public BitmapImage Image1 { get; set;}

        [ObservableProperty]
        public string image2;
        public DateOnly DateofBirth1 { get; set; }
        public double GPA1 { get; set; }

        public AddNewStudentVM()
        {

        }

        public bool isValid()
        {
            if(StudentID1 == null) 
            { 
                MessageBox.Show("Student Id is Required","Failed",MessageBoxButton.OK,MessageBoxImage.Warning);
                return false;
            }
            if (FirstName1 == null)
            {
                MessageBox.Show("First Name is Required", "Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (LastName1 == null)
            {
                MessageBox.Show("Last Name is Required", "Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if(Image1 == null)
            {
                MessageBox.Show("Image is Required", "Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if(GPA1==0)
            {
                MessageBox.Show("GPA is Required", "Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        [RelayCommand]
        public void Load()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Image2 = op.FileName;
                Image1 = new BitmapImage(new Uri(op.FileName));
                
            }
        }

        [RelayCommand]
        public void Save()
        {
            if(isValid())
            {
                MessageBox.Show("New Student was Added", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                CloseWindow();
            }
            
        }

        [RelayCommand]
        public void Close()
        {
            
            CloseWindow();
        }


        private void CloseWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.DialogResult = true;
                    window.Close();
                }
            }
        }

    }
}
