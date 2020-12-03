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
    /// Логика взаимодействия для GenderControl.xaml
    /// </summary>
    public partial class GenderControl : UserControl
    {
        private Gender _gender = Gender.male;

        public Gender Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                switch(value)
                {
                    case Gender.male:
                        MaleRadioButton.IsChecked = true;
                        break;
                    case Gender.female:
                        FealeRadioButton.IsChecked = true;
                        break;
                }
            }
        }
        public GenderControl()
        {
            InitializeComponent();
        }
        private void MaleRadioButton_Checked(object sender, RoutedEventArgs e) => _gender = Gender.male;

        private void FealeRadioButton_Checked(object sender, RoutedEventArgs e) =>_gender = Gender.female;
    }
}
