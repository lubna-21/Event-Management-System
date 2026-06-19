using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class EventCategoryService
    {
        EventCategoryRepo repo;
        Mapper mapper;
        public EventCategoryService(EventCategoryRepo repo)
        {
            this.repo = repo;
            mapper = Mapperconfig.GetMapper();
        }
        public List<EventCategoryDTO> Get()
        {
            var data = repo.Get();
            return mapper.Map<List<EventCategoryDTO>>(data);
        }
        public List<EventCategoryDTO> Search(string? name, double? minPrice, double? maxPrice)
        {
            var data = repo.Search(name, minPrice, maxPrice);
            return mapper.Map<List<EventCategoryDTO>>(data);
        }
        public EventCategoryDTO Get(int id)
        {
            var data = repo.Get(id);
            return mapper.Map<EventCategoryDTO>(data);
        }
        public bool Create(EventCategoryDTO dto)
        {
            var data = mapper.Map<EventCategory>(dto);
            return repo.Create(data);
        }
        public bool Update(EventCategoryDTO dto)
        {
            var data = mapper.Map<EventCategory>(dto);
            return repo.Update(data);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}