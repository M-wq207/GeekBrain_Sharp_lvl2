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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Leson5.LockedConverter;

namespace Leson5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //создаем списки содержащие Работников и Департаменты
        public static ObservableCollection<EmployeeV2> PmployeeList { get; set; } = new ObservableCollection<EmployeeV2>();
        public static ObservableCollection<Department> DepartmentList { get; set; } = new ObservableCollection<Department>();
        //
        public static EmployeeV2 transitEmployee = new EmployeeV2();
        public static int SelectedPersonID;
        public MainWindow()
        {

            //var a = new LockedConverter();
            InitializeComponent();
            this.DataContext = this;

            DepartmentList.Add(new Department("Первый"));
            DepartmentList.Add(new Department("Второй"));
            DepartmentList.Add(new Department("Технический"));

            PmployeeList.Add(new EmployeeV2("Andry", new DateTime(2001, 11, 9), Gender.male, DepartmentList[0], true));
            PmployeeList.Add(new EmployeeV2("Dan", new DateTime(2002, 10, 9), Gender.male, DepartmentList[1], true));
            PmployeeList.Add(new EmployeeV2("Set", new DateTime(2004, 10, 3), Gender.male, DepartmentList[2], false));
            PmployeeList.Add(new EmployeeV2("Ted", new DateTime(2021, 10, 2), Gender.female, DepartmentList[0], false));
            PmployeeList.Add(new EmployeeV2("Cet", new DateTime(2011, 9, 1), Gender.male, DepartmentList[1], true));
            PmployeeList.Add(new EmployeeV2("Text", new DateTime(2000, 10, 1), Gender.female, DepartmentList[2], false));
            PmployeeList.Add(new EmployeeV2("Dexter", new DateTime(2002, 8, 9), Gender.female, DepartmentList[0], true));
            //На всякий случай обнуляем ItemsSourse перед использованием, чтобы не было ошибки "перед ItemsSource использованием дб пустым"
            //EmployeeListView.ItemsSource = null;
            //// Передаем в ListView "EmployeeListView" лист EmployeeList на отображение
            //EmployeeListView.ItemsSource = PmployeeList;

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
                transitEmployee = (EmployeeV2)e.AddedItems[0];
                SelectedPersonID = PmployeeList.IndexOf((EmployeeV2)e.AddedItems[0]);
            }
        }
    }
}
