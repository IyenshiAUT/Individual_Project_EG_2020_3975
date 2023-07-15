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
    public partial class EditStudentVM:ObservableObject
    {
        public string StudentID2 { get; set; }
        public string FirstName2 { get; set; }
        public string LastName2 { get; set; }
        public BitmapImage Image2 { get; set; }
        public DateOnly DateofBirth2 { get; set; }
        public double GPA2 { get; set; }


        public EditStudentVM()
        {

        }
        public bool isValid()
        {
            if (StudentID2 == null)
            {
                MessageBox.Show("Student Id is Required", "Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (FirstName2 == null)
            {
                MessageBox.Show("First Name is Required", "Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (LastName2 == null)
            {
                MessageBox.Show("Last Name is Required", "Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (Image2 == null)
            {
                MessageBox.Show("Image is Required", "Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (GPA2 == 0)
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
                Image2 = new BitmapImage(new Uri(op.FileName));
            }
        }

        [RelayCommand]
        public void Save()
        {
            if (isValid())
            {
                MessageBox.Show("New Student Details were Saved", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
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
