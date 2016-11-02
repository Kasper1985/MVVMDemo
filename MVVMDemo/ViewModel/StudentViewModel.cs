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
		public StudentViewModel()
		{
			LoadStudents();
		}

		public ObservableCollection<Student> Students { get; set; }

		public void LoadStudents()
		{
			ObservableCollection<Student> students = new ObservableCollection<Student>();

			students.Add(new Student { FirstName = "Mark", LastName = "Allain" });
			students.Add(new Student { FirstName = "Allen", LastName = "Brown" });
			students.Add(new Student { FirstName = "Linda", LastName = "Hanerski" });

			Students = students;
		}
	}
}
