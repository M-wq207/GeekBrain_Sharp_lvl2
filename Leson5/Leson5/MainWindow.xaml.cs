using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Leson5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //создаем списки содержащие Работников и Департаменты
        public static List<Employee> EmployeeList = new List<Employee>();
        public static List<Department> DepartmentList = new List<Department>();
        public static Employee transitEmployee = new Employee();
        public static int SelectedPersonID;
        public MainWindow()
        {
        
            InitializeComponent();

            //заполняем списки содержащие Работников и Департаменты
            DepartmentList.AddRange(new[]
            {
                new Department("First"),
                new Department("Second"),
                new Department("Techno"),
            });
            EmployeeList.AddRange(new[]
            {
                new Employee ("Andry", new DateTime(2001, 11,9), Gender.male, DepartmentList[0]),
                new Employee ("Dan", new DateTime(2002, 10,9),Gender.male, DepartmentList[1]),
                new Employee ("Set", new DateTime(2004, 10,3),Gender.male, DepartmentList[2]),
                new Employee ("Ted", new DateTime(2021, 10,2), Gender.female, DepartmentList[0]),
                new Employee ("Cet", new DateTime(2011, 9,1), Gender.male, DepartmentList[1]),
                new Employee ("Text", new DateTime(2000, 10,1), Gender.female, DepartmentList[2]),
                new Employee ("Dexter", new DateTime(2002, 8,9), Gender.female, DepartmentList[0]),
            });
            //На всякий случай обнуляем ItemsSourse перед использованием, чтобы не было ошибки "перед ItemsSource использованием дб пустым"
            EmployeeListView.ItemsSource = null;
            // Передаем в ListView "EmployeeListView" лист EmployeeList на отображение
            EmployeeListView.ItemsSource = EmployeeList;

        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            var changeWind = new ChangeWindow(this, transitEmployee, DepartmentList, SelectedPersonID);
            this.Hide();
            changeWind.Show();
        }

        private void EmployeeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                transitEmployee = (Employee)e.AddedItems[0];
                SelectedPersonID = EmployeeList.IndexOf((Employee)e.AddedItems[0]);
            }
        }
    }
}
