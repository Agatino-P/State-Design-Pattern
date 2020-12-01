 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace State_Design_Pattern.Logic
{
    public class PendingState : BookingState
    {
        CancellationTokenSource cancelToken;
        public override void Cancel(BookingContext booking)
        {
            cancelToken.Cancel();
        }

        public override void DatePassed(BookingContext booking)
        {
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticket)
        {
        }

        public override void EnterState(BookingContext booking)
        {
            cancelToken = new CancellationTokenSource();
            booking.ShowState("Pending");
            booking.View.ShowStatusPage("Processing booking");
            StaticFunctions.ProcessBooking(booking, Processingcomplete, cancelToken);
        }

        private void Processingcomplete(BookingContext booking, ProcessingResult result)
        {
            switch (result)
            {
                case ProcessingResult.Sucess:
                    booking.TransitionToState(new BookedState());
                    break;
                case ProcessingResult.Fail:
                    booking.View.ShowProcessingError();
                    booking.TransitionToState(new NewState());
                    break;
                case ProcessingResult.Cancel:
                    booking.TransitionToState(new ClosedState("Processing Cancelled"));
                    break;
                default:
                    break;
            }
        }
    }
}
