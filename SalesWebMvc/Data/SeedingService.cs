using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using System;
using System.Linq;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private readonly SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; // DB has been seeded
            }

            var d1 = new Department(new int(), "Computers");
            var d2 = new Department(new int(), "Electronics");
            var d3 = new Department(new int(), "Fashion");
            var d4 = new Department(new int(), "Books");

            var s1 = new Seller(new int(), "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            var s2 = new Seller(new int(), "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            var s3 = new Seller(new int(), "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            var s4 = new Seller(new int(), "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            var s5 = new Seller(new int(), "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            var s6 = new Seller(new int(), "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            var r1 = new SalesRecord(new int(), new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s1);
            var r2 = new SalesRecord(new int(), new DateTime(2018, 09, 4), 7000.0, SaleStatus.Billed, s5);
            var r3 = new SalesRecord(new int(), new DateTime(2018, 09, 13), 4000.0, SaleStatus.Canceled, s4);
            var r4 = new SalesRecord(new int(), new DateTime(2018, 09, 1), 8000.0, SaleStatus.Billed, s1);
            var r5 = new SalesRecord(new int(), new DateTime(2018, 09, 21), 3000.0, SaleStatus.Billed, s3);
            var r6 = new SalesRecord(new int(), new DateTime(2018, 09, 15), 2000.0, SaleStatus.Billed, s1);
            var r7 = new SalesRecord(new int(), new DateTime(2018, 09, 28), 13000.0, SaleStatus.Billed, s2);
            var r8 = new SalesRecord(new int(), new DateTime(2018, 09, 11), 4000.0, SaleStatus.Billed, s4);
            var r9 = new SalesRecord(new int(), new DateTime(2018, 09, 14), 11000.0, SaleStatus.Pending, s6);
            var r10 = new SalesRecord(new int(), new DateTime(2018, 09, 7), 9000.0, SaleStatus.Billed, s6);
            var r11 = new SalesRecord(new int(), new DateTime(2018, 09, 13), 6000.0, SaleStatus.Billed, s2);
            var r12 = new SalesRecord(new int(), new DateTime(2018, 09, 25), 7000.0, SaleStatus.Pending, s3);
            var r13 = new SalesRecord(new int(), new DateTime(2018, 09, 29), 10000.0, SaleStatus.Billed, s4);
            var r14 = new SalesRecord(new int(), new DateTime(2018, 09, 4), 3000.0, SaleStatus.Billed, s5);
            var r15 = new SalesRecord(new int(), new DateTime(2018, 09, 12), 4000.0, SaleStatus.Billed, s1);
            var r16 = new SalesRecord(new int(), new DateTime(2018, 10, 5), 2000.0, SaleStatus.Billed, s4);
            var r17 = new SalesRecord(new int(), new DateTime(2018, 10, 1), 12000.0, SaleStatus.Billed, s1);
            var r18 = new SalesRecord(new int(), new DateTime(2018, 10, 24), 6000.0, SaleStatus.Billed, s3);
            var r19 = new SalesRecord(new int(), new DateTime(2018, 10, 22), 8000.0, SaleStatus.Billed, s5);
            var r20 = new SalesRecord(new int(), new DateTime(2018, 10, 15), 8000.0, SaleStatus.Billed, s6);
            var r21 = new SalesRecord(new int(), new DateTime(2018, 10, 17), 9000.0, SaleStatus.Billed, s2);
            var r22 = new SalesRecord(new int(), new DateTime(2018, 10, 24), 4000.0, SaleStatus.Billed, s4);
            var r23 = new SalesRecord(new int(), new DateTime(2018, 10, 19), 11000.0, SaleStatus.Canceled, s2);
            var r24 = new SalesRecord(new int(), new DateTime(2018, 10, 12), 8000.0, SaleStatus.Billed, s5);
            var r25 = new SalesRecord(new int(), new DateTime(2018, 10, 31), 7000.0, SaleStatus.Billed, s3);
            var r26 = new SalesRecord(new int(), new DateTime(2018, 10, 6), 5000.0, SaleStatus.Billed, s4);
            var r27 = new SalesRecord(new int(), new DateTime(2018, 10, 13), 9000.0, SaleStatus.Pending, s1);
            var r28 = new SalesRecord(new int(), new DateTime(2018, 10, 7), 4000.0, SaleStatus.Billed, s3);
            var r29 = new SalesRecord(new int(), new DateTime(2018, 10, 23), 12000.0, SaleStatus.Billed, s5);
            var r30 = new SalesRecord(new int(), new DateTime(2018, 10, 12), 5000.0, SaleStatus.Billed, s2);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30);

            _context.SaveChanges();
        }
    }
}