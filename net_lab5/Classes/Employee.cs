using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace net_lab5.Classes
{
    public class Employee : IComparable<Employee>
    {
        private string _fullName;
        private string _position;
        private int _salary;
        private int _experience;

        public Employee(string fullName, string position, int salary, int experience)
        {
            this.FullName = fullName;
            this.Position = position;
            this.Salary = salary;
            this.Experience = experience;
        }

        public Employee()
        {
            this._fullName = "John Doe";
            this._position = "Manager";
            this._salary = 50000;
            this._experience = 5;
        }

        public Employee(string fullName, string position)
            : this(fullName, position, 1000, 0)
        {
        }

        public string FullName
        {
            get => this._fullName;
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                this._fullName = value;
            }
        }

        public string Position
        {
            get => this._position;
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                this._position = value;
            }
        }

        public int Salary
        {
            get => this._salary;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        value,
                        "Salary must be greater than zero.");
                }

                this._salary = value;
            }
        }

        public int Experience
        {
            get => this._experience;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        value,
                        "Experience cannot be negative.");
                }

                this._experience = value;
            }
        }


        public int CompareTo(Employee? other)
        {
            if (other == null)
                return 1;

            return Experience.CompareTo(other.Experience);
        }

        public override string ToString()
        {
            return $"Employee: {FullName}, Position: {Position}, Salary: {Salary}, Experience: {Experience}";
        }
    }
}
