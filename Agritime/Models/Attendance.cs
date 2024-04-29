namespace Agritime.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; } // Attendance ID

        // Foreign key to Employee table
        public int EmployeeId { get; set; }
        public Employees Employee { get; set; }

        // Foreign key to Designation table
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }

        // Foreign key to Department table
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        // Foreign key to Shift table
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }

        // Attendance timings
        public DateTime TimeIn { get; set; } // Time when employee clocked in
        public DateTime? TimeOut { get; set; } // Time when employee clocked out (nullable)

        // Additional properties if needed
    }
}
