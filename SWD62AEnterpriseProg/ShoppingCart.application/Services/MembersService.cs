using ShoppingCart.application.Interfaces;
using ShoppingCart.application.ViewModels;
using ShoppingCart.domain.Interfaces;
using ShoppingCart.domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Services
{

    public class MembersSerivce : iMembersService
    {
        private iMembersRepository _membersRepo;
        public MembersSerivce(iMembersRepository memberRepo)
        {
            _membersRepo = memberRepo;
        }

        public void AddMember(MembersViewModel m)
        {
            Member newMember = new Member()
            {
                Email = m.Email,
                FirstName = m.FirstName,
                LastName = m.LastName
            };
            _membersRepo.AddMember(newMember);
        }


    }
}
