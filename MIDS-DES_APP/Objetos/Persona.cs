using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    /// <summary>
    /// Clase que representa a una persona
    /// </summary>
    public class Persona
    {
        #region Campos
        private DateTime fechaNacimiento;
        private String nombre;
        private Byte edad;
        #endregion

        #region Propiedades
        public DateTime FechaNacimiento { get => fechaNacimiento; }

        /// <summary>
        /// Propiedad de tipo <c>String</c> que hace referencia al nombre de la persona.
        /// Es de solo lectura
        /// </summary>
        public string Nombre { get => nombre; }

        /// <summary>
        /// Propiedad de tipo <c>String</c> que indica los pasatiempos de la persona.
        /// </summary>
        public String Pasatiempos { get; set; }

        public StringBuilder PasatiemposSB { get; set; }

        /// <summary>
        /// Propiedad de tipo <c>Byte</c> que indica la edad de la persona
        /// </summary>
        public Byte Edad { get => edad; set => edad = value; }
        #endregion

        #region Constructores
        public Persona(String nombre, DateTime fechaNacimiento)
        {
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
            this.ValidarFechaNacimiento();
            this.PasatiemposSB = new StringBuilder();

            if (DateTime.Now.Year - this.fechaNacimiento.Year < 255)
            {
                this.edad = (Byte)(DateTime.Now.Year - this.fechaNacimiento.Year);
            }
        }
        #endregion

        #region Métodos
        protected void CumplirAnios()
        {
            this.edad++;
        }

        private void ValidarFechaNacimiento()
        {
            if (this.fechaNacimiento.Date > DateTime.Now.Date)
            {
                this.fechaNacimiento = DateTime.Now;
            }
        }

        internal void MetodoPrueba()
        {
        }
        #endregion
    }
}