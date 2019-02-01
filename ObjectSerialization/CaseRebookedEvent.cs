using System;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Tests")]


namespace ObjectSerialization
{
    public class CaseRebookedEvent
    {
        public CaseRebookedEvent(Case @case, Appointment previousAppointment)
        {
            this.Case = @case;
            this.PreviousAppointment = previousAppointment;
        }

        public Case Case { get; internal set; }

        public string SysRef => this.Case.SysRef;

        public Appointment PreviousAppointment { get; internal set; }

        public Appointment BookedAppointment => this.Case.Appointment;

        public bool IsSameDayRebooking => this.BookedAppointment.AppointmentDate == this.PreviousAppointment.AppointmentDate;
    }
}
