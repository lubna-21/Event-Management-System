using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
        public class AdminService
        {
            AdminRepo repo;
            Mapper mapper;
            public AdminService(AdminRepo repo)
            {
                this.repo = repo;
                mapper = Mapperconfig.GetMapper();
            }
            public AdminDTO? Login(string email, string password)
            {
                var data = repo.Login(email, password);
                if (data == null) return null;
                return mapper.Map<AdminDTO>(data);
            }
            public List<AdminDTO> Get()
            {
                var data = repo.Get();
                return mapper.Map<List<AdminDTO>>(data);
            }
            public AdminDTO Get(int id)
            {
                var data = repo.Get(id);
                return mapper.Map<AdminDTO>(data);
            }
            public bool Create(AdminDTO dto)
            {
                var data = mapper.Map<Admin>(dto);
                return repo.Create(data);
            }
            public bool Update(AdminDTO dto)
            {
                var data = mapper.Map<Admin>(dto);
                return repo.Update(data);
            }
            public bool Delete(int id)
            {
                return repo.Delete(id);
            }
        }
    }
