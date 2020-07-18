using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Alumno
    {
        public void ConsultarAlumno(ref Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarAlumno(ref Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarAlumno(ref Alumno ObjAlumno, ref List<Alumno> List)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
              //  CDAlumno.ConsultarAlumno(ref ObjAlumno, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConsultarAlumnoSel(ref Alumno ObjAlumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.ConsultarAlumnoSel(ref ObjAlumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AlumnoEditar(ref Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.AlumnoEditar(ref Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AlumnoInsertar(Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.AlumnoInsertar(Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AlumnoInsertarPonente(Alumno Alumno, Participante ObjParticipante, string Evento, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.AlumnoInsertarPonente(Alumno, ObjParticipante, Evento, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlumnoEditarPonente(Alumno Alumno, Participante ObjParticipante, string Evento, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.AlumnoEditarPonente(Alumno, ObjParticipante, Evento, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlumnoClienteActivar(Alumno Alumno, ref string Verificador)
        {
            try
            {
                CD_Alumno CDAlumno = new CD_Alumno();
                CDAlumno.AlumnoClienteActivar(Alumno, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
