using LaptopDiscount;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopDiscountTest
{
    public class DiscountTest
    {
        private EmployeeDiscount _employeeDiscount;

        // Test whether EmployeeType is passed in the correct type
        [TestCase(EmployeeType.PartTime)]
        public void EmployeeType_Test(EmployeeType employeeType)
        {
            // Arrange

            // Act
            _employeeDiscount.EmployeeType = employeeType;

            // Assert
            Assert.That(_employeeDiscount.EmployeeType, Is.EqualTo(employeeType));
        }

        // Test whether price is passed in the correct value
        [TestCase(100)]
        public void Price_Test(decimal price)
        {
            // Arrange

            // Act
            _employeeDiscount.Price = price;

            // Assert
            Assert.That(_employeeDiscount.Price, Is.EqualTo(price));

        }

        // Test whether different types of EmployeeType can calculate the correct final price
        [TestCase(EmployeeType.PartTime, 100, 100)]
        [TestCase(EmployeeType.PartialLoad, 100, 95)]
        [TestCase(EmployeeType.FullTime, 100, 90)]
        [TestCase(EmployeeType.CompanyPurchasing, 100, 80)]
        public void CalculateDiscountedPrice_Test(EmployeeType employeeType,decimal price, decimal expected)
        {
            // Arrange
            _employeeDiscount.Price = price;


            // Act
            _employeeDiscount.EmployeeType = employeeType;

            // Assert
            Assert.That(_employeeDiscount.CalculateDiscountedPrice(), Is.EqualTo(expected));

        }
    }
}
