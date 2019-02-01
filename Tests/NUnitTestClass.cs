using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
            var tomorrow = DateTime.Now.AddDays(1).Date;

            var newAppointment = new Appointment() { AppointmentDate = tomorrow };
            var prevAppointment = new Appointment() { AppointmentDate = today };

            var @case = new Case() { SysRef = "QU123456", Appointment = newAppointment };
            var crbEvent = new CaseRebookedEvent(@case, prevAppointment);

            var serializedEvent = JsonConvert.SerializeObject(crbEvent);

            Console.WriteLine(serializedEvent);

            var deserializedEvent = JsonConvert.DeserializeObject<CaseRebookedEvent>(serializedEvent, new JsonSerializerSettings { ContractResolver = new PrivateSetterContractResolver() });

            deserializedEvent.Case.Should().NotBeNull();
            deserializedEvent.Case.SysRef.Should().Be(@case.SysRef);
            deserializedEvent.Case.Appointment.Should().NotBeNull();
            deserializedEvent.Case.Appointment.AppointmentDate.Should().Be(tomorrow);

            deserializedEvent.BookedAppointment.Should().Be(deserializedEvent.Case.Appointment);
            deserializedEvent.PreviousAppointment.Should().NotBeNull();
            deserializedEvent.PreviousAppointment.AppointmentDate.Should().Be(today);

        }
    }
}
