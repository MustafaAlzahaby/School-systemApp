using Project_Teacher.Command;
using Students.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Students.ViewModel
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

        #region Constructors
        public WindowViewModel()
        {
            StudList = new ObservableCollection<Subject>()
            {

                new Subject()  { SubName =" " },

                new Subject() { SubName ="Physics",
                stud1="Ahmed Ashraf",stud2="Marwa Hossam",stud3="Yassin Ali",stud4="Nourhan Abdullah"} ,

                new Subject() { SubName ="Mathematics",
                stud1 = "Yassin Youseef" ,stud2="Marwa Hossam" },

                new Subject () { SubName = "Computer Science", stud1 ="Nourhan Abdullah",stud2="Ahmed Youseef",
                    stud3="Adel Hany"
                }
            };

                AddSubject = new MyCommand(AddSubjectToList, CandAddSubjectToList);
                RemoveSubject = new MyCommand(RemoveSubjectToList, CanRemoveSubjectToList);
        }
        #endregion

        #region Properties
        private Subject _selectedSubject;
        public Subject SelectedSubject
        {
            get { return _selectedSubject; }
            set
            {
                try
                {
                    _selectedSubject = value;
                    OnPropertyChanged("SelectedSubject");
                    _itemInEditMode.SubName = _selectedSubject.SubName;
                    _itemInEditMode.stud1 = _selectedSubject.stud1;
                    _itemInEditMode.stud2 = _selectedSubject.stud2;
                    _itemInEditMode.stud3 = _selectedSubject.stud3;
                    _itemInEditMode.stud4 = _selectedSubject.stud4;
                    _itemInEditMode.Image = _selectedSubject.Image;
                    OnPropertyChanged("ItemInEditMode");
                }
                catch (NullReferenceException)
                {
                }

            }
        }
        public MyCommand AddTeacher { get; set; }
        public MyCommand RemoveTeacher { get; set; }

        public ObservableCollection <Subject> StudList { get; private set; }

        private Subject _itemInEditMode = new Subject();
        public Subject ItemInEditMode
        {
            get { return _itemInEditMode; }
            set { _itemInEditMode = value; }
        }
        public MyCommand AddSubject { get; set; }
        public MyCommand RemoveSubject { get; set; }
        #endregion

        #region Methods

        public void AddSubjectToList(object parameter)
        {

            StudList.Add(new Subject() { SubName = "Soft Skills", stud1 = "Sarah Ali", stud2 = "Ibrahim EL Abud", stud3 = "Franc holision" });
        }
        public bool CandAddSubjectToList(object parameter)
        {
            return true;
        }

        public void RemoveSubjectToList(object parameter)
        {
            StudList.Remove((Subject)parameter);
            SelectedSubject = null;
            _itemInEditMode.SubName = null;
            _itemInEditMode.stud1 = "";
            _itemInEditMode.stud2 = null;
            _itemInEditMode.stud3 = null;
            _itemInEditMode.stud4 = null;
            OnPropertyChanged("ItemInEditMode");
        }

        public bool CanRemoveSubjectToList(object parameter)
        {
            if ((Subject)parameter != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
