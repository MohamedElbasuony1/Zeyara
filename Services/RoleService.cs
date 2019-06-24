using Contracts;
using Microsoft.AspNetCore.Authorization;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class RoleService
    {
        IRoleReposatory _roleReposatory;
        public RoleService(IRoleReposatory roleReposatory)
        {
            _roleReposatory = roleReposatory;
        }

        public List<Role> GetRoles()
        {
          return  _roleReposatory.Query().ToList();
        }
        public void AddRole(string role)
        {
            _roleReposatory.Add(new Role{ Role_Name=role});
        }

    }
}
