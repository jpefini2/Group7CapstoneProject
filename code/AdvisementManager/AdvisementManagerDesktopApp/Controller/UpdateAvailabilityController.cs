using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerDesktopApp.Model;

namespace AdvisementManagerDesktopApp.Controller
{
    public class UpdateAvailabilityController
    {
        public Dictionary<string, IList<string>> RetrieveAdvisorCurrentAvailability()
        { 
            var availability = new Dictionary<string, IList<string>>();

            //TODO fill dictionary with times slots from the database for each day in the format <"Monday", "2:00 PM-3:00 PM>

            return availability;
        }


        public void UpdateAvailability(Advisor advisor, Dictionary<string, List<string>> timeSlots)
        {
            //TODO update the advisors availability.
        }
    }
}
