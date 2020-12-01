 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Design_Pattern.Logic
{
    public class ClosedState : BookingState
    {
        private string _reasonClosed;

        public ClosedState(string reasonClosed)
        {
            _reasonClosed = reasonClosed;
        }

        public override void Cancel(BookingContext booking)
        {
            booking.View.ShowError("Invalid action fo this state","Closed Booking");
        }

        public override void DatePassed(BookingContext booking)
        {
            booking.View.ShowError("Invalid action fo this state", "Closed Booking");

        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticket)
        {
            booking.View.ShowError("Invalid action fo this state", "Closed Booking");

        }

        public override void EnterState(BookingContext booking)
        {
            booking.ShowState("Closed");
            booking.View.ShowStatusPage(_reasonClosed);
        }

    }
}
