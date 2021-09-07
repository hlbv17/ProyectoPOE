using Model;
using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model {
    public class Paciente : Persona, IPaciente {

		// Variables
		private long id_paciente;
		private string discapacidad;
		private long id_etapaEdad;
		private string etapa;


		// Constructor: default
		public Paciente() : base()
		{
			this.discapacidad = "";
		}



		//Constructor: parameterized
		public Paciente(string discapacidad, string cedula, char sexo, string nombre, DateTime fechaNacimiento, string telefono, string correo) : base(cedula, sexo, nombre, fechaNacimiento, telefono, correo)
		{
			this.discapacidad = discapacidad;
		}



		public string Discapacidad { get => discapacidad; set => discapacidad = value; }    // Getter & Setter: discapacidad
		public long Id_paciente { get => id_paciente; set => id_paciente = value; }
		public long Id_etapaEdad { get => id_etapaEdad; set => id_etapaEdad = value; }
		public string Etapa { get => etapa; set => etapa = value; }

		public string CategoriaEdad()
		{
			string categoria_edad = "";
			int edad = base.LeerEdad();
			if (edad >= 0 && edad <= 1)
			{
				categoria_edad = "Bebe";
			}
			else if (edad > 1 && edad <= 12)
			{
				categoria_edad = "Niño";
			}
			else if (edad > 12 && edad <= 18)
			{
				categoria_edad = "Adolescente";
			}
			else if (edad > 18 && edad <= 25)
			{
				categoria_edad = "Adulto Joven";
			}
			else if (edad > 25 && edad <= 65)
			{
				categoria_edad = "Adulto";
			}
			else if (edad > 65 && edad <= 80)
			{
				categoria_edad = "Adulto Mayor";
			}
			else if (edad > 80 && edad <= 130)
			{
				categoria_edad = "Anciano";
			}
			return categoria_edad;
		}

		public long Id_EtapaEdad()
		{
			string c_Edad = this.CategoriaEdad();
			if (c_Edad == "Bebe")
			{
				id_etapaEdad = 1;
			}
			else if (c_Edad == "Niño")
			{
				id_etapaEdad = 2;
			}
			else if (c_Edad == "Adolescente")
			{
				id_etapaEdad = 3;
			}
			else if (c_Edad == "Adulto Joven")
			{
				id_etapaEdad = 4;
			}
			else if (c_Edad == "Adulto")
			{
				id_etapaEdad = 5;
			}
			else if (c_Edad == "Adulto Mayor")
			{
				id_etapaEdad = 6;
			}
			else if (c_Edad == "Anciano")
			{
				id_etapaEdad = 7;
			}

			return id_etapaEdad;
		}

		// Method: ToString
		public override string ToString()
		{
			return base.ToString() +
				"\r\nDiscapacidad: " + discapacidad +
				"\r\nCategoria Edad: " + CategoriaEdad();
		}
	}
}
