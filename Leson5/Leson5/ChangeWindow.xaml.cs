using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Leson5
{
    /// <summary>
    /// Логика взаимодействия для ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
        public static EmployeeV2 changingEmployee;
        public static MainWindow MainWindow;
        public static ObservableCollection<Department> DepartmentList = new ObservableCollection<Department>();
        public static int employeeID;
        //
        public  string Name { get; set; }
        public  DateTime Birthday { get; set; }
        public  Gender Gender { get; set; }
        public  Department Department { get; set; }
        public  bool Locked { get; set; }
        public bool SaveButton { get; set; } = false;
        public  bool NewEmpButton { get; set; } = false;
        public ChangeWindow(MainWindow mw, EmployeeV2 emp, ObservableCollection<Department> dl, int eID)
        {
            changingEmployee = emp;
            MainWindow = mw;
            DepartmentList = dl;
            employeeID = eID;
            //
            InitializeComponent();
            //
            DepartmentComboBox.ItemsSource = DepartmentList;
            //
            NameTextBox.Text = changingEmployee.Name;
            BirthdayDataPeacker.SelectedDate = changingEmployee.Birthday;
            DepartmentComboBox.SelectedItem = changingEmployee.Department;
            GenderControlRadioButton.Gender = changingEmployee.Gender;
            blockedCheckBox.IsChecked = changingEmployee.Locked;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Name = NameTextBox.Text;
            Birthday = (DateTime)BirthdayDataPeacker.SelectedDate;
            Gender = GenderControlRadioButton.Gender;
            Department = (Department)DepartmentComboBox.SelectedItem;
            Locked = (bool)blockedCheckBox.IsChecked;
            SaveButton = true;
            DialogResult = true;
            this.Hide();
            MainWindow.Show();
        }

        private void canselButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void newEmplButton_Click(object sender, RoutedEventArgs e)
        {
            NewEmpButton = true;
            Name = NameTextBox.Text;
            Birthday = (DateTime)BirthdayDataPeacker.SelectedDate;
            Gender = GenderControlRadioButton.Gender;
            Department = (Department)DepartmentComboBox.SelectedItem;
            Locked = (bool)blockedCheckBox.IsChecked;
            DialogResult = true;
        }

        private void addDepartButton_Click(object sender, RoutedEventArgs e)
        {
            var newDep = new Department(addDepartTextBox.Text);
            Department = newDep;
            DialogResult = true;
        }
    }
}
