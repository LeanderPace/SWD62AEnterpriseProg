using ShoppingCart.data.Context;
using ShoppingCart.domain.Interfaces;
using ShoppingCart.domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.data.Repositories
{
    class MembersRepository : iMembersRepository
    {
        private ShoppingCarDBContext _context;

        public MembersRepository(ShoppingCarDBContext context)
        {
            _context = context;
        }

        public void AddMember(Member m)
        {
            _context.Members.Add(m);
            _context.SaveChanges();
        }
    }
}
