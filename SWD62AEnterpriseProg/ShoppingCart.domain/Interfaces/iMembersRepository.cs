using ShoppingCart.domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.domain.Interfaces
{
    public interface iMembersRepository
    {
        void AddMember(Member m);    
    }
}
