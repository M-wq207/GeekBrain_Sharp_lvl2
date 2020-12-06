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

            changingEmployee.Name = NameTextBox.Text;
            changingEmployee.Birthday = (DateTime)BirthdayDataPeacker.SelectedDate;
            changingEmployee.Gender = GenderControlRadioButton.Gender;
            changingEmployee.Department = (Department)DepartmentComboBox.SelectedItem;
            changingEmployee.Locked = (bool)blockedCheckBox.IsChecked;
            //MainWindow.EmployeeList[employeeID] = changingEmployee;
            //MainWindow.EmployeeListView.ItemsSource = null;
            //MainWindow.EmployeeListView.ItemsSource = MainWindow.PmployeeList;
            this.Hide();
            MainWindow.Show();
        }

        private void canselButton_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow.EmployeeListView.ItemsSource = null;
            //MainWindow.EmployeeListView.ItemsSource = MainWindow.PmployeeList;
            this.Hide();
            MainWindow.Show();
        }

        private void newEmplButton_Click(object sender, RoutedEventArgs e)
        {
            var addingEmployee = new EmployeeV2();
            addingEmployee.Name = NameTextBox.Text;
            addingEmployee.Birthday = (DateTime)BirthdayDataPeacker.SelectedDate;
            addingEmployee.Gender = GenderControlRadioButton.Gender;
            addingEmployee.Department = (Department)DepartmentComboBox.SelectedItem;
            changingEmployee.Locked = (bool)blockedCheckBox.IsChecked;
            MainWindow.PmployeeList.Add(addingEmployee);
            //EmployeeListView.ItemsSource = null;
            //MainWindow.EmployeeListView.ItemsSource = MainWindow.PmployeeList;
            this.Hide();
            MainWindow.Show();
        }

        private void addDepartButton_Click(object sender, RoutedEventArgs e)
        {
            var newDep = new Department(addDepartTextBox.Text);
            MainWindow.DepartmentList.Add(newDep);
            //DepartmentComboBox.ItemsSource = null;
            //DepartmentComboBox.ItemsSource = MainWindow.DepartmentList;
        }
    }
}
