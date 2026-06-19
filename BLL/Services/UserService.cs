using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Text;

    namespace BLL.Services
    {
        public class UserService
        {
            UserRepo repo;
            Mapper mapper;
            public UserService(UserRepo repo)
            {
                this.repo = repo;
                mapper = Mapperconfig.GetMapper();
            }
            public UserDTO? Login(string email, string password)
            {
                var data = repo.Login(email, password);
                if (data == null) return null;
                return mapper.Map<UserDTO>(data);
            }
            public bool EmailExists(string email)
            {
                return repo.EmailExists(email);
            }
            public List<UserDTO> Get()
            {
                var data = repo.Get();
                return mapper.Map<List<UserDTO>>(data);
            }
            public UserDTO Get(int id)
            {
                var data = repo.Get(id);
                return mapper.Map<UserDTO>(data);
            }
            public bool Create(UserDTO dto)
            {
                var data = mapper.Map<User>(dto);
                return repo.Create(data);
            }
            public bool Update(UserDTO dto)
            {
                var data = mapper.Map<User>(dto);
                return repo.Update(data);
            }
            public bool Delete(int id)
            {
                return repo.Delete(id);
            }
        }
    }

