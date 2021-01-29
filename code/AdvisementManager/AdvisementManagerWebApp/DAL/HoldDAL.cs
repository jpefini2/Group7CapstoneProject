using AdvisementManagerWebApp.Data;
using AdvisementManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdvisementManagerWebApp.DAL
{
    public class HoldDAL
    {
        public Hold ObtainHold(int? id, ApplicationDbContext context)
        {
            var hold = context.Hold.FromSqlRaw(
                "SELECT holdID, reason, dateAdded, isActive FROM Hold  WHERE studentID = {0}", id).FirstOrDefault();


            return hold;
        }
    }
}
