using Microsoft.Win32;
using Project_Teacher.Command;
using Project_Teacher.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Project_Teacher.ViewModel
{
    public class WindowViewModel : INotifyPropertyChanged
    {
        #region Interface Implemntation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        private Teacher _selectedTeacher;
        public Teacher SelectedTeacher
        {
            get { return _selectedTeacher; }
            set
            {
                try
                {
                    _selectedTeacher = value;
                    OnPropertyChanged("SelectedTeacher");
                    _itemInEditMode.ID = _selectedTeacher.ID;
                    _itemInEditMode.Name = _selectedTeacher.Name;
                    _itemInEditMode.Age = _selectedTeacher.Age;
                    _itemInEditMode.Salary = _selectedTeacher.Salary;
                    _itemInEditMode.Subject = _selectedTeacher.Subject;
                    _itemInEditMode.Image = _selectedTeacher.Image;
                    OnPropertyChanged("ItemInEditMode");
                }
                catch (NullReferenceException)
                {
                }
            }
        }
        #region Constructors
        public WindowViewModel()
        {
            TeachList = new ObservableCollection<Teacher>() { new Teacher() { ID = 30102, Name ="Ahmed Ali",
            Age = 30 , Subject = "Math" , Salary = 20000 , Image ="/Images/fgfgf.jpeg" } , new Teacher() { ID = 40260, Name ="Sarah Fouad",
            Age = 27 , Subject = "Physics",Image ="/Images/teacher.jpg" , Salary = 30000  }, new Teacher () { ID = 50620, Name ="Yassin Buno",
            Age = 35 , Subject = "Computer Science" ,Image ="/Images/index.jpeg", Salary = 40000} };

            RemoveTeacher = new MyCommand(RemoveTeacherToList, CanRemoveTeacherToList);
            AddNew = new MyCommand(AddNewTeacher, CanAddNewTeacher);
            SaveNew = new MyCommand(SaveNewTeacher, CanSaveNewTeacher);
            UploadPhoto = new MyCommand(UploadPhotoTeacher, CanUploadPhotoTeacher);
        }
        #endregion
        public ObservableCollection<Teacher> TeachList { get; private set; }

        private Teacher _itemInEditMode = new Teacher();
        public Teacher ItemInEditMode
        {
            get { return _itemInEditMode; }
            set { _itemInEditMode = value; }
        }

        public MyCommand AddNew { get; set; }
        public MyCommand RemoveTeacher { get; set; }
        public MyCommand SaveNew { get; set; }
        public MyCommand UploadPhoto { get; set; }

        public void AddNewTeacher(Object parameter)
        {
            SelectedTeacher = null;
            ItemInEditMode.Name = "";
            ItemInEditMode.ID = null;
            ItemInEditMode.Salary = null;
            ItemInEditMode.Age = null;
            ItemInEditMode.Image = "";
            ItemInEditMode.Subject = "";
            OnPropertyChanged("ItemInEditMode");
            OnPropertyChanged("SelectedTeacher");
        }
        public bool CanAddNewTeacher(Object parameter)

        {
            return true;
        }
        public void SaveNewTeacher(Object parameter)
        {
            Teacher teacherr = new Teacher();
            teacherr.ID = ItemInEditMode.ID;
            teacherr.Name = ItemInEditMode.Name;
            teacherr.Subject = ItemInEditMode.Subject;
            teacherr.Salary = ItemInEditMode.Salary;
            teacherr.Image = ItemInEditMode.Image;
            teacherr.Age = ItemInEditMode.Age;
            TeachList.Add(teacherr);
            SelectedTeacher = teacherr;
            OnPropertyChanged("ItemInEditMode");
            OnPropertyChanged("SelectedTeacher");
            MessageBox.Show($" {teacherr.Name} added successfully");

        }
        public bool CanSaveNewTeacher(Object parameter)

        {
            return true;
        }
        public void UploadPhotoTeacher(Object parameter)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                ItemInEditMode.Image = (new BitmapImage(new Uri(op.FileName))).ToString();
                OnPropertyChanged("ItemInEditMode");

            }
        }
        public bool CanUploadPhotoTeacher(Object parameter)

        {
            return true;
        }

        public void RemoveTeacherToList(object parameter)
        {
            TeachList.Remove((Teacher)parameter);
            SelectedTeacher = null;
            _itemInEditMode.ID = null;
            _itemInEditMode.Name = "";
            _itemInEditMode.Age = null;
            _itemInEditMode.Salary = null;
            _itemInEditMode.Subject = null;
            _itemInEditMode.Image = null;
            OnPropertyChanged("ItemInEditMode");
            MessageBox.Show($" {((Teacher)parameter).Name} Removed successfully");

        }

        public bool CanRemoveTeacherToList(object parameter)
        {
            if ((Teacher)parameter != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
