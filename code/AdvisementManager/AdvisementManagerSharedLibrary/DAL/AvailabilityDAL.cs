using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibrary.DAL
{
    public class AvailabilityDAL
    {
        /// <summary>Obtains the Advisor's Availability slots.</summary>
        /// <param name="advisorId">The advisor identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   The retrieved Availability slots.
        /// </returns>
        public List<Availability> GetAdvisorAvailability(int advisorId, ApplicationDbContext context)
        {
            List<Availability> timeSlots = (from availability in context.Availability
                                            where availability.AdvisorId == advisorId
                                            select availability).ToList();

            return timeSlots;
        }

        /// <summary>Sets the Advisor's Availability.</summary>
        /// <param name="advisorId">The advisor identifier.</param>
        /// <param name="timeSlots">The availability timeslots.</param>
        /// <param name="context">The context.</param>
        public void SetAdvisorAvailability(int advisorId, List<Availability> timeSlots, ApplicationDbContext context)
        {
            this.clearAdvisorAvailability(advisorId, context);

            foreach (var timeSlot in timeSlots)
                context.Entry(timeSlot).State = EntityState.Added;

            context.SaveChanges();
        }

        /// <summary>Removes the Advisor's availability from the db</summary>
        /// <param name="advisorId">The advisor identifier.</param>
        /// <param name="context">The context.</param>
        private void clearAdvisorAvailability(int advisorId, ApplicationDbContext context)
        {
            List<Availability> timeSlots = this.GetAdvisorAvailability(advisorId, context);

            foreach (var timeSlot in timeSlots)
                context.Entry(timeSlot).State = EntityState.Deleted;

            context.SaveChanges();
        }
    }
}
