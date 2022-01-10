using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    class RentRequestConfiguration : IEntityTypeConfiguration<RentRequest>
    {
        public void Configure(EntityTypeBuilder<RentRequest> builder)
        {
            builder.HasData(
                new RentRequest
                {
                    rid = 1,
                    username = "gvddns",
                    BookId = 2,
                    requestdate = new DateTime(2022, 01, 06),
                    startdate = new DateTime(2022, 01, 07),
                    enddate = new DateTime(2022, 01, 08),
                    totalrent = 20,
                    approval = "Pending",
                    approvaldate = new DateTime(2022, 01, 08),
                    Id= "35b6005d-76e9-4658-a2b1-a60123d56308"
                },
                new RentRequest
                {
                    rid = 2,
                    username = "gvddns",
                    BookId = 3,
                    requestdate = new DateTime(2022, 01, 06),
                    startdate = new DateTime(2022, 01, 07),
                    enddate = new DateTime(2022, 01, 08),
                    totalrent = 30,
                    approval = "Pending",
                    approvaldate = new DateTime(2022, 01, 08),
                    Id = "35b6005d-76e9-4658-a2b1-a60123d56308"
                },
                new RentRequest
                {
                    rid = 3,
                    username = "gvddns",
                    BookId = 1,
                    requestdate = new DateTime(2022, 01, 06),
                    startdate = new DateTime(2022, 01, 07),
                    enddate = new DateTime(2022, 01, 08),
                    totalrent = 40,
                    approval = "Pending",
                    approvaldate = new DateTime(2022, 01, 08),
                    Id = "35b6005d-76e9-4658-a2b1-a60123d56308"
                }
                );
        }
    }
}
