using MVVM1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM1.ViewModel
{
    public class StudentViewModel : BindableBase
    {
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }
        public ObservableCollection<Student> Students { get; set; }
        private Student selectedStudent;
        private string fnText;
        private string lnText;

        public Student SelectedStudent
        {
            get { return selectedStudent; }

            set
            {
                selectedStudent = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public string FnText { get => fnText;
            set
            {
                if(fnText != value)
                {
                    fnText = value;
                    OnPropertyChanged("FnText");
                }
            }
        }
        public string LnText { get => lnText;
            set 
            { 
                if(lnText != value)
                {
                    lnText = value;
                    OnPropertyChanged("LnText");
                }
            } 
        }

        public StudentViewModel()
        {
            LoadStudents();

            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
        }

        public void LoadStudents()
        {
            ObservableCollection<Student> students = 
                new ObservableCollection<Student>();

            students.Add(new Student { FirstName = "Petar", LastName = "Petrovic" });
            students.Add(new Student { FirstName = "Marko", LastName = "Markovic" });
            students.Add(new Student { FirstName = "Jovan", LastName = "Jovanovic" });

            Students = students;
        }

        private void OnAdd()
        {
            Students.Add(new Student { FirstName = FnText, LastName = LnText });
        }

        private void OnDelete()
        {
            Students.Remove(SelectedStudent);
        }

        private bool CanDelete()
        {
            return SelectedStudent != null;
        }
    }
}
