using net_lab5.Classes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace net_lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        EmployeeList employeeList;
        public MainWindow()
        {
            InitializeComponent();
                
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = System.IO.Path.Combine(documentsPath, "employees.json");

            this.employeeList = new EmployeeList(new JSONFileReader(), new JSONFileWriter(), filePath);

            dataGridEmployees.ItemsSource = employeeList.Employees;
        }

        public void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string position = txtPosition.Text.Trim();
            string salary = txtSalary.Text.Trim();
            string experience = txtExperience.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(position) || string.IsNullOrEmpty(salary) || string.IsNullOrEmpty(experience))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(salary, out int salaryValue) || !int.TryParse(experience, out int experienceValue))
            {
                MessageBox.Show("Зарплата та стаж повинні бути числовими значеннями.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Employee newEmployee = new Employee(fullName, position, salaryValue, experienceValue);

            employeeList.addEmployee(newEmployee);

            txtFullName.Clear();
            txtPosition.Clear();
            txtSalary.Clear();
            txtExperience.Clear();
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridEmployees.SelectedItem is not Employee selectedEmployee)
            {
                MessageBox.Show(
                    "Будь ласка, виберіть працівника для видалення.",
                    "Працівника не вибрано",    
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show(
                $"Видалити працівника «{selectedEmployee.FullName}»?",
                "Підтвердження видалення",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            employeeList.removeEmployee(selectedEmployee);
            dataGridEmployees.SelectedItem = null;
        }

        public void FilterBySalary_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtFilterSalary.Text.Trim(), out int maxSalary))
            {
                MessageBox.Show("Будь ласка, введіть дійсне числове значення для фільтру зарплати.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            employeeList.FilterBySalary(maxSalary);
        }

        public void ResetFilters_Click(object sender, RoutedEventArgs e)
        {
            employeeList.ResetFilter();
        }
        public void SortByExp_Click(object sender, RoutedEventArgs e)
        {
            employeeList.SortByExp();
        }

        public void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            employeeList.LoadAsync();
            MessageBox.Show("Дані успішно завантажено.", "Завантаження", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            employeeList.SaveAsync();
            MessageBox.Show("Дані успішно збережено.", "Збереження", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}