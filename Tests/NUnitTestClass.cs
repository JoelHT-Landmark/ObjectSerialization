using Newtonsoft.Json;
using NUnit.Framework;
using ObjectSerialization;
using System;
namespace Tests
{
    [TestFixture()]
    public class NUnitTestClass
    {
        [Test()]
        public void TestCase()
        {
            var today = DateTime.Now.Date;

            var newAppointment = new Appointment() { AppointmentDate = today };
            var prevAppointment = new Appointment() { AppointmentDate = today };

            var @case = new Case() { SysRef = "QU123456}", Appointment = newAppointment };
            var crbEvent = new CaseRebookedEvent(@case, prevAppointment);

            var serializedEvent = JsonConvert.SerializeObject(crbEvent);

            Console.WriteLine(serializedEvent);

            var deserializedEvent = JsonConvert.DeserializeObject<CaseRebookedEvent>(serializedEvent);
        }
    }
}
