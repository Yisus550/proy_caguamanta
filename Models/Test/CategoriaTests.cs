using Microsoft.VisualStudio.TestTools.UnitTesting;
using proy_caguamanta.Models;
using System.ComponentModel.DataAnnotations;

namespace proy_caguamanta.Models.Test
{
    [TestClass]
    public class CategoriaTests
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
        public void Categoria_Id_IsRequired()
        {
            // Arrange
            var categoria = new Categoria();

            // Act
            var isValid = ValidateModel(categoria, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("Id") && v.ErrorMessage.Contains("Este campo es obligatorio")));
        }

        [TestMethod]
        public void Categoria_Nombre_IsRequired()
        {
            // Arrange
            var categoria = new Categoria();

            // Act
            var isValid = ValidateModel(categoria, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("Nombre") && v.ErrorMessage.Contains("Este campo es obligatorio")));
        }

        [TestMethod]
        public void Categoria_Nombre_MaxLength()
        {
            // Arrange
            var categoria = new Categoria { Nombre = new string('a', 61) };

            // Act
            var isValid = ValidateModel(categoria, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("Nombre") && v.ErrorMessage.Contains("La cadena de texto no puede sobrepasar los 60 caracteres")));
        }

        [TestMethod]
        public void Categoria_Descripcion_IsRequired()
        {
            // Arrange
            var categoria = new Categoria();

            // Act
            var isValid = ValidateModel(categoria, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("Descripcion") && v.ErrorMessage.Contains("Este campo es obligatorio")));
        }

        [TestMethod]
        public void Categoria_Descripcion_MaxLength()
        {
            // Arrange
            var categoria = new Categoria { Descripcion = new string('a', 61) };

            // Act
            var isValid = ValidateModel(categoria, out var results);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsTrue(results.Any(v => v.MemberNames.Contains("Descripcion") && v.ErrorMessage.Contains("La cadena de texto no puede sobrepasar los 60 caracteres")));
        }
    }
}