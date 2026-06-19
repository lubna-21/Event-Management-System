using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Text;

    namespace BLL.Services
    {
        public class BookingService
        {
            BookingRepo repo;
            Mapper mapper;
            public BookingService(BookingRepo repo)
            {
                this.repo = repo;
                mapper = Mapperconfig.GetMapper();
            }
            public List<BookingDTO>Get()
        {
            var data = repo.Get();
            return mapper.Map<List<BookingDTO>>(data);
        }
        public List<BookingDTO> GetByUser(int userId)
        {
            var data = repo.GetByUser(userId);
            return mapper.Map<List<BookingDTO>>(data);
        }
        

        
            public BookingDTO Get(int id)
            {
                var data = repo.Get(id);
                return mapper.Map<BookingDTO>(data);
            }
        public bool Create(BookingDTO dto)
        {
            var data = new Booking
            {
                UserId = dto.UserId,
                EventCategoryId = dto.EventCategoryId,
                SeatCount = dto.SeatCount,
                TotalPrice = dto.TotalPrice,
                BookingDate = dto.BookingDate,
                Status = "Pending"
            };
            return repo.Create(data);
        }

        public bool UpdateStatus(int id, string status)
        {
            return repo.UpdateStatus(id, status);
        }
        public bool Delete(int id)
            {
                return repo.Delete(id);
            }
        }
    }