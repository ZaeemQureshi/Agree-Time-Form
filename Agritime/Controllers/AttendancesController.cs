using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agritime.Data;
using Agritime.Models;

namespace Agritime.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Attendances
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Attendance.Include(a => a.Department).Include(a => a.Designation).Include(a => a.Employee).Include(a => a.Shift);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Attendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance
                .Include(a => a.Department)
                .Include(a => a.Designation)
                .Include(a => a.Employee)
                .Include(a => a.Shift)
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendances/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            ViewData["DesignationId"] = new SelectList(_context.Designations, "Id", "Name");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "ID", "FullName");
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "Id", "Name");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttendanceId,EmployeeId,DesignationId,DepartmentId,ShiftId,TimeIn,TimeOut")] Attendance attendance)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", attendance.DepartmentId);
            ViewData["DesignationId"] = new SelectList(_context.Designations, "Id", "Id", attendance.DesignationId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "ID", "ID", attendance.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "Id", "Id", attendance.ShiftId);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", attendance.DepartmentId);
            ViewData["DesignationId"] = new SelectList(_context.Designations, "Id", "Id", attendance.DesignationId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "ID", "ID", attendance.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "Id", "Id", attendance.ShiftId);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttendanceId,EmployeeId,DesignationId,DepartmentId,ShiftId,TimeIn,TimeOut")] Attendance attendance)
        {
            if (id != attendance.AttendanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(attendance.AttendanceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", attendance.DepartmentId);
            ViewData["DesignationId"] = new SelectList(_context.Designations, "Id", "Id", attendance.DesignationId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "ID", "ID", attendance.EmployeeId);
            ViewData["ShiftId"] = new SelectList(_context.Shifts, "Id", "Id", attendance.ShiftId);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendance
                .Include(a => a.Department)
                .Include(a => a.Designation)
                .Include(a => a.Employee)
                .Include(a => a.Shift)
                .FirstOrDefaultAsync(m => m.AttendanceId == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendance = await _context.Attendance.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendance.Remove(attendance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(int id)
        {
            return _context.Attendance.Any(e => e.AttendanceId == id);
        }
    }
}
