using Datos;
using Model;
using Proyecto_Dentalig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Control {
    public class Adm_Horario {

        private static Adm_Horario adm = null;
        List<Horario> horario1 = null;
        List<Horario> horarioOdont = null;
        List<Dias> diash = null;
        Datos_Horario datosHora = new Datos_Horario ();
        //Validacion v = null;
        Horario hora = null;

        public List<Horario> Horario1 { get => horario1; set => horario1 = value; }
        public Horario Hora { get => hora; set => hora = value; }
        public List<Dias> Diash { get => diash; set => diash = value; }
        public List<Horario> HorarioOdont { get => horarioOdont; set => horarioOdont = value; }

        //singleton, para guardar la informacion de las listas
        public static Adm_Horario GetAdm () {
            if (adm == null) {
                adm = new Adm_Horario ();
            }
            return adm;
        }
        
        private Adm_Horario () {
            horario1 = new List<Horario> ();
            horarioOdont = new List<Horario> ();
        }

        //1). llena el grid del inicio del formulario de Filtro de Horario :3
        public void LlenarGrid (DataGridView dgvBecas) {
            consultarBDD ();
            int i = 0;

            foreach (Horario x in Horario1) {
                dgvBecas.Rows.Add (x.Tipo, x.Dias [i].Dia, x.Dias [i].HoraEntrada.ToString ("HH:ss"), x.Dias [i].HoraSalida.ToString ("HH:ss"));
                i++;
            }
        }
        
        //consulta a la base de datos para el LlenarGrid    (1)
        private void consultarBDD () {
            horario1.Clear ();
            horario1 = datosHora.consultarTodoHorario ();


            if (horario1 == null) {
                MessageBox.Show ("Error: No se consultara los datos");
            }
        }
        
        //consulta a la base de datos para el LlenarGrid  al momento de filtrar los horarios  (2)
        private void consultarBDD1 (string diasH, string tipo) {
            horario1.Clear ();
            horario1 = datosHora.consultarHorario (diasH, tipo);


            if (horario1 == null) {
                MessageBox.Show ("Error: No se consultara los datos");
            }
        }

        private void consultarBDD2 (string tipo) {
            horario1.Clear ();
            horario1 = datosHora.consultarHorarioACt (tipo);
            if (horario1 == null) {
                MessageBox.Show ("Error: No se consultara los datos");
            }
        }
        
        //2). llena el grid del ala momento de filtar del formulario de Filtro de Horario :3
        public void LlenarGridHorarioFiltrar (DataGridView dgvhorario, string diasH, string tipo) {
            consultarBDD1 (diasH, tipo);
            int i = 0;

            foreach (Horario x in Horario1) {
                dgvhorario.Rows.Add (x.Tipo, x.Dias [i].Dia, x.Dias [i].HoraEntrada.ToString ("HH:ss"), x.Dias [i].HoraSalida.ToString ("HH:ss"));
            }
            i++;
        }

        //3)llena el grid de odontologo, con los datos seleccionados de en la tabla de Horario inicial (2) 
        public void llenarGridOdo (DataGridView dgvHorarioOdontologo, DataGridView dgvHorario) {
            Horario horarioOdon = new Horario ();
            List<Horario> ho = new List<Horario> ();
            List<Dias> d = new List<Dias> ();
            //DiasEGGM di = new DiasEGGM();
            string matuI = Convert.ToString (dgvHorario [0, dgvHorario.CurrentRow.Index].Value);
            MessageBox.Show ("Solo puede escoger el horario por jornada completa o dia mientras sea de la misma jornada, si no es del mismo se borrara del horario");
            int o = dgvHorarioOdontologo.Rows.Count;
            int i = 1;
            if (o == 0) {
                horarioOdont.Clear ();
                foreach (DataGridViewRow row in dgvHorario.Rows) {

                    if (Convert.ToString (row.Cells [0].Value) == matuI) {
                        Dias di = new Dias ();
                        dgvHorarioOdontologo.Rows.Add (row.Cells [0].Value, row.Cells [1].Value, row.Cells [2].Value, row.Cells [3].Value);
                        horarioOdon.Tipo = Convert.ToString (row.Cells [0].Value);
                        di.Dia = Convert.ToString (row.Cells [1].Value);
                        di.HoraEntrada = Convert.ToDateTime (row.Cells [2].Value);
                        di.HoraSalida = Convert.ToDateTime (row.Cells [3].Value);
                        d.Add (di);
                        horarioOdon.Dias = d;
                        HorarioOdont.Add (horarioOdon);

                    }

                    i++;
                }

            } else if (o != 0 & o < 3) {
                if (Convert.ToString (dgvHorarioOdontologo.CurrentCell.Value) == matuI) {
                    horarioOdont.Clear ();
                    foreach (DataGridViewRow row in dgvHorario.Rows) {

                        if (Convert.ToString (row.Cells [0].Value) == matuI) {

                            dgvHorarioOdontologo.Rows.Add (row.Cells [0].Value,
                            row.Cells [1].Value, row.Cells [2].Value, row.Cells [3].Value);
                            horarioOdon.Tipo = Convert.ToString (row.Cells [0].Value);
                            horarioOdon.Dias [i].Dia = Convert.ToString (row.Cells [1].Value);
                            horarioOdon.Dias [i].HoraEntrada = Convert.ToDateTime (row.Cells [2].Value);
                            horarioOdon.Dias [i].HoraSalida = Convert.ToDateTime (row.Cells [3].Value);
                            HorarioOdont.Add (horarioOdon);

                        }
                        i++;
                        //x.Tipo, x.Dias[i].Dia, x.Dias[i].HoraEntrada.ToString("HH:ss"), x.Dias[i].HoraSalida.ToString("HH:ss")
                    }
                } else {
                    dgvHorarioOdontologo.Rows.Clear ();
                }
            } else {
                dgvHorarioOdontologo.Rows.Clear ();

            }


        }

        //llena el grid del Formulario de horario.
        public void LlenarGriDE (DataGridView dgvHorarioOdontologo) {

            int i = 0;
            //consultarBDD();
            dgvHorarioOdontologo.Rows.Clear ();

            foreach (Horario x in HorarioOdont) {
                dgvHorarioOdontologo.Rows.Add (x.Tipo, x.Dias [i].Dia, x.Dias [i].HoraEntrada.ToString ("HH:ss"), x.Dias [i].HoraSalida.ToString ("HH:ss"));
                i++;
            }


        }
        
        public void LlenarGridHorarioAc (DataGridView dgvhorario, string tipo) {
            consultarBDD2 (tipo);

            int i = 0;
            //Horario p = null;
            foreach (Horario x in Horario1) {
                dgvhorario.Rows.Add (x.Tipo, x.Dias [i].Dia, x.Dias [i].HoraEntrada.ToString ("HH:ss"), x.Dias [i].HoraSalida.ToString ("HH:ss"));
                i++;
            }

        }

        public Horario guardarHorario () {
            Horario e = null;

            e.Dias = horario1 [0].Dias;
            e.Tipo = horario1 [0].Tipo;


            return e;
        }
    
    }
}



