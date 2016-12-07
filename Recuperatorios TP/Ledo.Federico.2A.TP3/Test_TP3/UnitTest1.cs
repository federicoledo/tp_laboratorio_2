using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace Test_TP3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDni()
        {
            try
            {
                Instructor instr = new Instructor(155, "Gonzalo", "Rodriguez", "TresCuatro751983", Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }
        [TestMethod]
        public void TestNulos()
        {
            Instructor instr = new Instructor(155, "Gonzalo", "Rodriguez", "34751983", Persona.ENacionalidad.Argentino);
            Assert.AreNotEqual(null, instr.ID);
            Assert.AreNotEqual(null, instr.Nombre);
            Assert.AreNotEqual(null, instr.Apellido);
            Assert.AreNotEqual(null, instr.DNI);
            Assert.AreNotEqual(null, instr.Nacionalidad);
        }
        [TestMethod]
        public void TestGimnasioInstancia()
        {
            Gimnasio gimnasio = new Gimnasio();

            Assert.AreNotEqual(null, gimnasio.LsAlumno);
            Assert.AreNotEqual(null, gimnasio.LsInstr);
            Assert.AreNotEqual(null, gimnasio.LsJorn);
        }
    }
}
