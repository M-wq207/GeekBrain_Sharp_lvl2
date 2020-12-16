using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

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

        //leson 7 elements
        public static SqlConnection connection;
        //for Employee
        public static SqlDataAdapter dataAdapeterEmp = new SqlDataAdapter();
        public static DataTable dtEmp;
        //for Department
        public static SqlDataAdapter dataAdapeterDep = new SqlDataAdapter();
        public static DataTable dtDep;
        //
        DataRowView editRow;
        public MainWindow()
        {

            //var a = new LockedConverter();
            InitializeComponent();
            //
            #region forEmployee
            //
            string connectionString = @"Data Source=localhost;Persist Security Info=True;User ID=Leson7user;Initial Catalog=gbLeson7;Password=123";
            //
            connection = new SqlConnection(connectionString);
            //select
            SqlCommand command = new SqlCommand("SELECT Id, Name, Birthday, Gender, Department, Locked FROM Employee", connection);
            dataAdapeterEmp.SelectCommand = command;
            //insert
            command = new SqlCommand(@"INSERT INTO Employee (Name, Birthday, Gender, Department, Locked) VALUES (@Name, @Birthday, @Gender, @Department, @Locked); SET @Id = @@IDENTITY;", connection);
            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            command.Parameters.Add("@Birthday", SqlDbType.DateTime, -1, "Birthday");
            command.Parameters.Add("@Gender", SqlDbType.NVarChar, -1, "Gender");
            command.Parameters.Add("@Department", SqlDbType.NVarChar, -1, "Department");
            command.Parameters.Add("@Locked", SqlDbType.Bit, -1, "Locked");
            SqlParameter param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.Direction = ParameterDirection.Output;
            dataAdapeterEmp.InsertCommand = command;
            //update
            command = new SqlCommand(@"UPDATE Employee SET Name = @Name, Birthday = @Birthday, Gender = @Gender, Department = @Department, Locked = @Locked WHERE Id = @Id", connection);
            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            command.Parameters.Add("@Birthday", SqlDbType.DateTime, -1, "Birthday");
            command.Parameters.Add("@Gender", SqlDbType.NVarChar, -1, "Gender");
            command.Parameters.Add("@Department", SqlDbType.NVarChar, -1, "Department");
            command.Parameters.Add("@Locked", SqlDbType.Bit, -1, "Locked");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            dataAdapeterEmp.UpdateCommand = command;            
            //delete
            command = new SqlCommand("DELETE FROM Employee WHERE Id = @Id", connection);
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            dataAdapeterEmp.DeleteCommand = command;
            //
            dataAdapeterEmp.Fill(dtEmp = new DataTable());
            //
            #endregion
            #region Dep
            //
            //select
            command = new SqlCommand("SELECT Id, Name FROM Department", connection);
            dataAdapeterDep.SelectCommand = command;
            //insert
            command = new SqlCommand(@"INSERT INTO Department (Name) VALUES (@Name); SET @Id = @@IDENTITY;", connection);
            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.Direction = ParameterDirection.Output;
            dataAdapeterDep.InsertCommand = command;
            //update
            command = new SqlCommand(@"UPDATE Department SET Name = @Name WHERE Id = @Id", connection);
            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            dataAdapeterDep.UpdateCommand = command;
            //delete
            command = new SqlCommand("DELETE FROM Department WHERE Id = @Id", connection);
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            dataAdapeterDep.DeleteCommand = command;
            //
            dataAdapeterDep.Fill(dtDep = new DataTable());
            #endregion
            //

            //this.DataContext = this;

            //
            #region oldList
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
            //
            #endregion
            if (dtEmp.Rows == null)
            {
                foreach (var a in PmployeeList)
                {
                    DataRow newRow = dtEmp.NewRow();
                    newRow["Name"] = a.Name;
                    newRow["Birthday"] = a.Birthday;
                    newRow["Gender"] = a.Gender;
                    newRow["Department"] = a.Department;
                    newRow["Locked"] = a.Locked;
                    dtEmp.Rows.Add(newRow);
                }
                SqlCommandBuilder commandBuilderEmp = new SqlCommandBuilder(dataAdapeterEmp);
                dataAdapeterEmp.Update(dtEmp);
            }
            if (dtDep.Rows == null)
            {
                foreach (var a in DepartmentList)
                {
                    DataRow newRow = dtDep.NewRow();
                    newRow["Name"] = a.Name;
                    dtDep.Rows.Add(newRow);
                }
                SqlCommandBuilder commandBuilderDep = new SqlCommandBuilder(dataAdapeterEmp);
                dataAdapeterDep.Update(dtDep);
            }
            EmployeeListView.DataContext = dtEmp.DefaultView;
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            //

            //
            //var changeWind = new ChangeWindow(this, transitEmployee, DepartmentList, SelectedPersonID);
            editRow = (DataRowView)EmployeeListView.SelectedItem;
            var changeWind = new ChangeWindow();
            if (editRow != null)
            {
                changeWind = new ChangeWindow(editRow.Row);
            }
            //this.Hide();
            if ((bool)changeWind.ShowDialog())
            {
                if (changeWind.NewDepButton)
                {
                    DepartmentList.Add(changeWind.Department); 
                    //
                    DataRow newDep = dtDep.NewRow();
                    newDep["Name"] = changeWind.Department;
                    dtDep.Rows.Add(newDep);
                    dataAdapeterDep.Update(dtDep);
                }
                if (changeWind.SaveButton)
                {
                    transitEmployee.Name = changeWind.Name;
                    transitEmployee.Birthday = changeWind.Birthday;
                    transitEmployee.Department = changeWind.Department;
                    transitEmployee.Gender = changeWind.Gender;
                    transitEmployee.Locked = changeWind.Locked;
                    //
                    if (editRow != null)
                    {
                        editRow.BeginEdit();
                        editRow["Name"] = changeWind.Name;
                        editRow["Birthday"] = changeWind.Birthday;
                        editRow["Department"] = changeWind.Department;
                        editRow["Gender"] = changeWind.Gender;
                        editRow["Locked"] = changeWind.Locked;
                        // dtEmp.Rows.Add(editRow);
                        editRow.EndEdit();
                        dataAdapeterEmp.Update(dtEmp);
                    }
                }
                if (changeWind.NewEmpButton)
                {
                    PmployeeList.Add(new EmployeeV2(changeWind.Name, changeWind.Birthday, changeWind.Gender, changeWind.Department, changeWind.Locked));

                    transitEmployee.Name = changeWind.Name;
                    transitEmployee.Birthday = changeWind.Birthday;
                    transitEmployee.Department = changeWind.Department;
                    transitEmployee.Gender = changeWind.Gender;
                    transitEmployee.Locked = changeWind.Locked;
                    //
                    try
                    {
                        DataRow newEmployee = dtEmp.NewRow();
                        newEmployee["Name"] = changeWind.Name;
                        newEmployee["Birthday"] = changeWind.Birthday;
                        newEmployee["Department"] = changeWind.Department;
                        newEmployee["Gender"] = changeWind.Gender;
                        newEmployee["Locked"] = changeWind.Locked;
                        dtEmp.Rows.Add(newEmployee);
                        dataAdapeterEmp.Update(dtEmp);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        Debug.WriteLine(ex.TargetSite);
                    }
                }
            }
        }
            

        private void EmployeeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                //transitEmployee = (EmployeeV2)e.AddedItems[0];
                //SelectedPersonID = PmployeeList.IndexOf((EmployeeV2)e.AddedItems[0]);
                //
                // editRow = (DataRowView)e.AddedItems[0];
                editRow = (DataRowView)EmployeeListView.SelectedItem;
            }
        }
    }
}
