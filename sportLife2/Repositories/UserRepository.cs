using sportLife2.DbModel;
using sportLife2.Properties.Models;
using sportLife2.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using sportLife2.DTOs;
using AutoMapper;
using System;
using Microsoft.AspNetCore.Mvc;

namespace sportLife2.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        private readonly IMapper _mapper;
      

        public UserRepository(DataBaseContext context) : base(context)
        {

        }

        public bool UserControl(string email)
        {
            return _context.Users.Any(x => x.Email == email);
        }
        public override bool Create(UserEntity entity)
        {
            try
            {
                if (!UserControl(entity.Email))
                {
                    base.Create(entity);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Başarılı değil", ex.Message);
                return false;
            }
        }


        public async Task<List<RolDTO>> GetTypeUser(GetUserRequest request)
        {
            if (_context.Users.Any(x => x.Email == request.Email && x.Password == request.Password))
             {


                var data = await (from Users in _context.Users
                                  where Users.Email == request.Email && Users.Password == request.Password
                                  select new RolDTO()
                                  {
                                      Id=Users.Id,
                                      Rol = Users.Rol,
                                      Email = Users.Email,
                                      Password = Users.Password,
                                      PhoneNumber= Users.PhoneNumber,
                                      Name= Users.Name,
                                      Surname =Users.Surname,
                                      

                                  }

                             ).ToListAsync();
                return data;

            }
            else if( _context.Users.Any(x => x.Email == request.Email))
            {
                var data = new List<RolDTO>();
                var rol = new RolDTO { Rol = "a" };
                data.Add(rol);
                return data;

            } 
            else {
                var data = new List<RolDTO>();
                var rol = new RolDTO { Rol = "b" };
                data.Add(rol);
                return data;
            }

          
        }
    }
}

