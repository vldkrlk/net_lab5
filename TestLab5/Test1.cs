using Microsoft.VisualStudio.TestTools.UnitTesting;
using net_lab5.Classes;

namespace TestLab5;

[TestClass]
public sealed class EmployeeTests
{
    [TestMethod]
    public void DefaultConstructor_ShouldSetDefaultValues()
    {
        Employee employee = new Employee();

        Assert.AreEqual("John Doe", employee.FullName);
        Assert.AreEqual("Manager", employee.Position);
        Assert.AreEqual(50000, employee.Salary);
        Assert.AreEqual(5, employee.Experience);
    }

    [TestMethod]
    public void Constructor_ShouldSetProvidedValues()
    {
        Employee employee = new Employee("Alice Smith", "Developer", 3000, 4);

        Assert.AreEqual("Alice Smith", employee.FullName);
        Assert.AreEqual("Developer", employee.Position);
        Assert.AreEqual(3000, employee.Salary);
        Assert.AreEqual(4, employee.Experience);
    }

    [TestMethod]
    public void ShortConstructor_ShouldSetDefaultSalaryAndExperience()
    {
        Employee employee = new Employee("Alice Smith", "Developer");

        Assert.AreEqual("Alice Smith", employee.FullName);
        Assert.AreEqual("Developer", employee.Position);
        Assert.AreEqual(1000, employee.Salary);
        Assert.AreEqual(0, employee.Experience);
    }

    [TestMethod]
    public void Setters_ShouldUpdateValues()
    {
        Employee employee = new Employee();

        employee.FullName = "Bob Johnson";
        employee.Position = "Tester";
        employee.Salary = 2500;
        employee.Experience = 3;

        Assert.AreEqual("Bob Johnson", employee.FullName);
        Assert.AreEqual("Tester", employee.Position);
        Assert.AreEqual(2500, employee.Salary);
        Assert.AreEqual(3, employee.Experience);
    }

    [TestMethod]
    public void CompareTo_ShouldCompareEmployeesByFullName()
    {
        Employee firstEmployee = new Employee("Alice", "Developer", 3000, 4);
        Employee secondEmployee = new Employee("Bob", "Tester", 2500, 2);

        Assert.IsTrue(firstEmployee.CompareTo(secondEmployee) < 0);
        Assert.IsTrue(secondEmployee.CompareTo(firstEmployee) > 0);
    }

    [TestMethod]
    public void ToString_ShouldReturnEmployeeDescription()
    {
        Employee employee = new Employee("Alice Smith", "Developer", 3000, 4);

        Assert.AreEqual(
            "Employee: Alice Smith, Position: Developer, Salary: 3000, Experience: 4",
            employee.ToString());
    }
}
