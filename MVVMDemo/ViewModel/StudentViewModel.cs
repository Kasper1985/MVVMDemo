using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using MVVMDemo.Model;

namespace MVVMDemo.ViewModel
{
	class StudentViewModel
	{
        public ObservableCollection<Student> Students { get; set; }
        private Student _selectedStudent;
        public MyICommand DeleteCommand { get; set; }

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public StudentViewModel()
		{
			LoadStudents();
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
		}

		public void LoadStudents()
		{
			ObservableCollection<Student> students = new ObservableCollection<Student>();

			students.Add(new Student { FirstName = "Mark", LastName = "Allain" });
			students.Add(new Student { FirstName = "Allen", LastName = "Brown" });
			students.Add(new Student { FirstName = "Linda", LastName = "Hanerski" });

			Students = students;
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
