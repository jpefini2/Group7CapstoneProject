using AdvisementManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AdvisementManagerWebApp.DAL
{
    public class AdvisementSessionDAL
    {
        public AdvisementSession ObtainSession(int? id, ApplicationDbContext context)
        {
            var session =  context.AdvisementSession.FromSqlRaw(
                              "SELECT sessionID, sessionDate, notes FROM AdvisementSession WHERE studentID = {0}", id).FirstOrDefault();

            return session;
        }
    }
}
