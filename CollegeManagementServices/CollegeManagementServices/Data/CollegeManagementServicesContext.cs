using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CollegeManagementServices.Models;

namespace CollegeManagementServices.Data
{
    public class CollegeManagementServicesContext : DbContext
    {
        public CollegeManagementServicesContext (DbContextOptions<CollegeManagementServicesContext> options)
            : base(options)
        {
        }

        public DbSet<CollegeManagementServices.Models.StaffTasksLogic> StaffTasksLogics { get; set; }

        public DbSet<CollegeManagementServices.Models.StudentTasksLogic> StudentTasksLogics { get; set; }
    }
}
