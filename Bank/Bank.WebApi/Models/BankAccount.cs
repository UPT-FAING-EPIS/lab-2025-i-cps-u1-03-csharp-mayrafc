namespace Bank.WebApi.Models
{
    /// <summary>
    /// Representa una cuenta bancaria con un nombre de cliente y un balance.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        /// <summary>
        /// Constructor privado para evitar la creación de instancias sin parámetros.
        /// </summary>
        private BankAccount() { }

        /// <summary>
        /// Crea una nueva cuenta bancaria con un nombre de cliente y un balance inicial.
        /// </summary>
        /// <param name="customerName">El nombre del cliente asociado a la cuenta.</param>
        /// <param name="balance">El balance inicial de la cuenta.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Obtiene el nombre del cliente asociado a la cuenta.
        /// </summary>
        public string CustomerName { get { return m_customerName; } }

        /// <summary>
        /// Obtiene el balance actual de la cuenta.
        /// </summary>
        public double Balance { get { return m_balance; } }

        /// <summary>
        /// Realiza un débito en la cuenta, reduciendo el balance.
        /// </summary>
        /// <param name="amount">El monto a debitar de la cuenta.</param>
        /// <exception cref="ArgumentOutOfRangeException">Lanzado si el monto es negativo o si hay fondos insuficientes.</exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
                throw new ArgumentOutOfRangeException("amount");
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");
            m_balance -= amount;
        }

        /// <summary>
        /// Realiza un crédito en la cuenta, aumentando el balance.
        /// </summary>
        /// <param name="amount">El monto a acreditar a la cuenta.</param>
        /// <exception cref="ArgumentOutOfRangeException">Lanzado si el monto es negativo.</exception>
        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");
            m_balance += amount;
        }
    }
}
