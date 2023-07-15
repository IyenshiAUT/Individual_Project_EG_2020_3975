using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagementSystem.Model;
using StudentManagementSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;

namespace StudentManagementSystem.ViewModel
{
    public partial class MainWindowVM:ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;

        [ObservableProperty]
        public Student selectedStudent;

        public MainWindowVM()
        {
           Students= new ObservableCollection<Student>();

            Students.Add(new Student("3975", "Taneesha", "Iyenshi", new BitmapImage(new Uri("D:\\Taneesha\\3rd Semester\\GUI Programming\\Assignment 02\\Attempt1\\New1\\StudentManagementSystem\\Images\\1.jfif")), new DateOnly(2000, 11, 29), 3.56));
        }

        [RelayCommand]
        public void Add()
        {
            AddNewStudentVM addNewStudentVM = new AddNewStudentVM();
            AddNewStudentxaml addNewStudentxaml = new AddNewStudentxaml
            {
                DataContext = addNewStudentVM
            };
            
            if(addNewStudentxaml.ShowDialog()==true)
            {
                Student s = new Student
                {
                    StudentID = addNewStudentVM.StudentID1,
                    FirstName = addNewStudentVM.FirstName1,
                    LastName = addNewStudentVM.LastName1,
                    Image = addNewStudentVM.Image1,
                    DateofBirth = addNewStudentVM.DateofBirth1,
                    GPA=addNewStudentVM.GPA1, 
                    
                };
                
                if(addNewStudentVM.isValid() )
                {
                    Students.Add(s);
                }
            }
        }

        [RelayCommand]
        public void Edit()
        {
            if(SelectedStudent==null)
            {
                MessageBox.Show("First Select a Student!", "");
            }
            else
            {
                EditStudentVM editStudentVM = new EditStudentVM
                {
                    StudentID2=selectedStudent.StudentID,
                    FirstName2=selectedStudent.FirstName,
                    LastName2=selectedStudent.LastName,
                    Image2=selectedStudent.Image,
                    DateofBirth2=selectedStudent.DateofBirth,
                    GPA2=selectedStudent.GPA

                };

                EditStudent editStudent = new EditStudent
                {
                    DataContext = editStudentVM
                };

                if(editStudent.ShowDialog()==true)
                {
                    selectedStudent.StudentID = editStudentVM.StudentID2;
                    selectedStudent.FirstName = editStudentVM.FirstName2;
                    selectedStudent.LastName = editStudentVM.LastName2;
                    selectedStudent.Image=editStudentVM.Image2;
                    selectedStudent.DateofBirth = editStudentVM.DateofBirth2;
                    selectedStudent.GPA=editStudentVM.GPA2;

                    Students=new ObservableCollection<Student>(Students);

                }
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("First Select a Student!", "");
            }
            else
            {
                var Result = MessageBox.Show($"Are you sure to delete {SelectedStudent.FirstName}","Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (Result == MessageBoxResult.Yes) 
                { 
                    Students.Remove(SelectedStudent);
                }
            }
        }
        
    }
}
