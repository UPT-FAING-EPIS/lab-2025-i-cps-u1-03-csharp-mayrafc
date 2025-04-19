using Bank.WebApi.Models;
using NUnit.Framework;

namespace Bank.Domain.Tests
{
    /// <summary>
    /// Clase de pruebas unitarias para la clase <see cref="BankAccount"/>.
    /// </summary>
    public class BankAccountTests
    {
        /// <summary>
        /// Verifica que al debitar una cantidad válida,
        /// el saldo de la cuenta se actualice correctamente.
        /// </summary>
        [Test]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange: se configura una cuenta con un saldo inicial.
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act: se debita un monto válido de la cuenta.
            account.Debit(debitAmount);

            // Assert: se verifica que el nuevo saldo sea el esperado.
            double actual = account.Balance;
            NUnit.Framework.Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
    }
}
