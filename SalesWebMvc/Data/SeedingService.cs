using System;
using System.Linq;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    // Class used to seed Database with minimum items to test.
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.SalesRecord.Any() ||
                _context.Seller.Any())
            {
                return; // DB already seeded.
            }

            // Instantiate base objects.
            Department d1 = new Department(1, "Departamento 1");
            Department d2 = new Department(2, "Departamento 2");

            Seller s1 = new Seller(1, "Lucas", "lucas@mps.com.br", new DateTime(1992, 11, 01), 1700.00, d1);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2021, 06, 08), 500.36, SaleStatus.Billed, s1);

            // Push to database.
            _context.Department.AddRange(d1, d2);
            _context.Seller.Add(s1);
            _context.SalesRecord.Add(sr1);

            _context.SaveChanges();
        }
    }
}
