using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    class RentRequestConfiguration
    {
        public void Configure(EntityTypeBuilder<RentRequest> builder)
        {
            //builder.HasData(
            //    new RentRequest
            //    {
            //        id=1,
            //        userid = 0,
            //        bookid = 0,
            //        requestdate = new DateTime(2022,01,06),
            //        startdate = new DateTime(2022, 01, 07),
            //        enddate = new DateTime(2022, 01, 08),
            //        totalrent = 0,
            //        approval= "string",
            //        approvaldate= new DateTime(2022, 01, 08)
            //    },
            //    new RentRequest
            //    {
            //        id=2,
            //        userid = 0,
            //        bookid = 0,
            //        requestdate = new DateTime(2022, 01, 06),
            //        startdate = new DateTime(2022, 01, 07),
            //        enddate = new DateTime(2022, 01, 08),
            //        totalrent = 0,
            //        approval = "string",
            //        approvaldate = new DateTime(2022, 01, 08)
            //    },
            //    new RentRequest
            //    {
            //        id=3,
            //        userid = 0,
            //        bookid = 0,
            //        requestdate = new DateTime(2022, 01, 06),
            //        startdate = new DateTime(2022, 01, 07),
            //        enddate = new DateTime(2022, 01, 08),
            //        totalrent = 0,
            //        approval = "string",
            //        approvaldate = new DateTime(2022, 01, 08)
            //    }
            //    );
        }
    }
}
