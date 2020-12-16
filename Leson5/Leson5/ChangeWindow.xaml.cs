using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
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
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public bool Locked { get; set; }
        public bool SaveButton { get; set; } = false;
        public bool NewEmpButton { get; set; } = false;
        public bool NewDepButton { get; set; } = false;
        public DataRow DataRow { get; set; }
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
        public ChangeWindow(DataRow dataRow)
        {
            InitializeComponent();
            //
            //EmployeeListView.DataContext = dtEmp.DefaultView;

            DepartmentComboBox.ItemsSource = getDepCollection(MainWindow.dtDep.DefaultView);
            //
            DataRow = dataRow;
            //
            NameTextBox.Text = DataRow["Name"].ToString();
            BirthdayDataPeacker.SelectedDate = Convert.ToDateTime(DataRow["Birthday"]);
            DepartmentComboBox.SelectedItem = DataRow["Department"].ToString();
            GenderControlRadioButton.Gender = getGender((string)DataRow["Gender"]);
            blockedCheckBox.IsChecked = Convert.ToBoolean(DataRow["Locked"]);
        }
        public ChangeWindow() { }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Name = NameTextBox.Text;
            Birthday = (DateTime)BirthdayDataPeacker.SelectedDate;
            Gender = GenderControlRadioButton.Gender;
            Department = (Department)DepartmentComboBox.SelectedItem;
            Locked = (bool)blockedCheckBox.IsChecked;
            SaveButton = true;
            DialogResult = true;
            //this.Hide();
            //MainWindow.Show();
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
            NewDepButton = true;
            DialogResult = true;

        }
        //костыли
        private static Gender getGender(string str)
        {
            if (str == "male") return Gender.male;
            return Gender.female;
        }
        private static ObservableCollection<Department> getDepCollection(DataView dt)
        {
            ObservableCollection<Department> a = new ObservableCollection<Department>();
            foreach (DataRowView b in dt)
            {
                a.Add(new Department(Convert.ToString(b.Row.ItemArray[1])));
                //Debug.WriteLine(b.Row.ItemArray[1]);
            }
                return a;
        }
    }
}
