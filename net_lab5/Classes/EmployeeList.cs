using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using net_lab5.Interfaces;

namespace net_lab5.Classes
{
    public class EmployeeList
    {
        private readonly IFileLoader _fileReader;
        private readonly IFIleSaver _fileWriter;
        private readonly string _filePath;

        public ObservableCollection<Employee> Employees { get; }

        private List<Employee> _allEmployees;

        public EmployeeList(IFileLoader fileReader, IFIleSaver fileWriter, string filePath)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
            _filePath = filePath;
            Employees = new ObservableCollection<Employee>();
            _allEmployees = new List<Employee>();
        }

        public void addEmployee(Employee employee)
        {
            Employees.Add(employee);
            _allEmployees.Add(employee);
        }

        public void removeEmployee(Employee employee)
        {
            Employees.Remove(employee);
            _allEmployees.Remove(employee);
        }

        public void FilterBySalary(int minSalary)
        {
            var filtered = _allEmployees.Where(e => e.Salary <= minSalary).ToList();
            UpdateVisibleCollection(filtered);
        }

        public void ResetFilter()
        {
            UpdateVisibleCollection(_allEmployees);
        }

        private void UpdateVisibleCollection(List<Employee> newCollection)
        {
            Employees.Clear();
            foreach (var employee in newCollection)
            {
                Employees.Add(employee);
            }
        }

        public void SortByExp()
        {
            var sorted = new List<Employee>(Employees);
            sorted.Sort();
            UpdateVisibleCollection(sorted);
            
        }

        public async Task SaveAsync()
        {
            await _fileWriter.SaveAsync(_filePath, _allEmployees);
        }

        public async Task LoadAsync()
        {
            _allEmployees = await _fileReader.LoadAsync<Employee>(_filePath);
            UpdateVisibleCollection(_allEmployees);
        }
    }
}
