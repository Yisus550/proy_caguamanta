using Microsoft.VisualStudio.TestTools.UnitTesting;
using proy_caguamanta.Models;
using System.ComponentModel.DataAnnotations;
namespace proy_caguamanta.Models.Test
{
    [TestClass]
    public class ClienteTests
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
        public void Cliente_Id_IsRequired()
        {
            // Arrange
            var cliente = new Cliente();

            // Act
            var isValid = ValidateModel(cliente, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("Id") && v.ErrorMessage.Contains("Este campo es obligatorio")));
        }

        [TestMethod]
        public void Cliente_Nombre_IsRequired()
        {
            // Arrange
            var cliente = new Cliente();

            // Act
            var isValid = ValidateModel(cliente, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("Nombre") && v.ErrorMessage.Contains("Este campo es obligatorio")));
        }

        [TestMethod]
        public void Cliente_Nombre_MaxLength()
        {
            // Arrange
            var cliente = new Cliente { Nombre = new string('a', 61) };

            // Act
            var isValid = ValidateModel(cliente, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("Nombre") && v.ErrorMessage.Contains("La cadena de texto no puede sobrepasar los 60 caracteres")));
        }

        [TestMethod]
        public void Cliente_Telefono_IsRequired()
        {
            // Arrange
            var cliente = new Cliente();

            // Act
            var isValid = ValidateModel(cliente, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("Telefono") && v.ErrorMessage.Contains("Este campo es requerido.")));
        }

        [TestMethod]
        public void Cliente_Telefono_IsPhoneNumber()
        {
            // Arrange
            var cliente = new Cliente { Telefono = "InvalidPhoneNumber" };

            // Act
            var isValid = ValidateModel(cliente, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("Telefono") && v.ErrorMessage.Contains("El formato debe de ser de un número de celular")));
        }
    }
}