﻿using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit() //senkron olan
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync() //asenkron olan 
        {
            await _context.SaveChangesAsync();
        }
    }
}
