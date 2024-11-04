using Microsoft.VisualStudio.TestTools.UnitTesting;
using proy_caguamanta.Models;
using System.ComponentModel.DataAnnotations;

namespace proy_caguamanta.Tests
{
    [TestClass]
    public class CompraTests
    {
        private ValidationContext GetValidationContext(object model)
        {
            return new ValidationContext(model, null, null);
        }

        private bool ValidateModel(object model, out ICollection<ValidationResult> results)
        {
            var context = GetValidationContext(model);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(model, context, results, true);
        }

        [TestMethod]
        public void Compra_Id_IsRequired()
        {
            // Arrange
            var compra = new Compra();

            // Act
            var isValid = ValidateModel(compra, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("Id") && v.ErrorMessage.Contains("Este campo es obligatorio")));
        }

        [TestMethod]
        public void Compra_FechaCompra_IsRequired()
        {
            // Arrange
            var compra = new Compra();

            // Act
            var isValid = ValidateModel(compra, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("FechaCompra") && v.ErrorMessage.Contains("Este campo es obligatorio")));
        }

        [TestMethod]
        public void Compra_IdEmpleado_IsRequired()
        {
            // Arrange
            var compra = new Compra();

            // Act
            var isValid = ValidateModel(compra, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("IdEmpleado") && v.ErrorMessage.Contains("Este campo es obligatorio")));
        }

        [TestMethod]
        public void Compra_IdProveedor_IsRequired()
        {
            // Arrange
            var compra = new Compra();

            // Act
            var isValid = ValidateModel(compra, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("IdProveedor") && v.ErrorMessage.Contains("Este campo es obligatorio")));
        }

        [TestMethod]
        public void Compra_Importe_IsRequired()
        {
            // Arrange
            var compra = new Compra();

            // Act
            var isValid = ValidateModel(compra, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("Importe") && v.ErrorMessage.Contains("Este campo es obligatorio")));
        }

        [TestMethod]
        public void Compra_Importe_Range()
        {
            // Arrange
            var compra = new Compra { Importe = 0 };

            // Act
            var isValid = ValidateModel(compra, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("Importe") && v.ErrorMessage.Contains("El importe no debe de ser menor a $1")));
        }
    }
}