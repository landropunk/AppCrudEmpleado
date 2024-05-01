namespace AppCrud.Models
{
    /// <summary>
    /// Representa un empleado en la aplicación.
    /// </summary>
    public class Empleado
    {
        /// <summary>
        /// Obtiene o establece el identificador del empleado.
        /// </summary>
        public int IdEmpleado { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre completo del empleado.
        /// </summary>
        public string NombreCompleto { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del empleado.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de contrato del empleado.
        /// </summary>
        public DateOnly FechaContrato { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si el empleado está activo.
        /// </summary>
        public bool Activo { get; set; }
    }
}
