﻿using Microsoft.EntityFrameworkCore;
using Sina_Store.Application.Interfaces.Contexts;
using Sina_Store.Common.Dto;

namespace Sina_Store.Application.Services.Products.Queries.GetAllCategories
{
    public interface IGetAllCategoriesService
    {
        ResultDto<List<AllCategoriesDto>> Execute();
    }


    public class GetAllCategoriesService : IGetAllCategoriesService
    {
        private readonly IDataBaseContext _context;

        public GetAllCategoriesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<AllCategoriesDto>> Execute()
        {
            var categories = _context
                .Categories
                .Include(p => p.ParentCategory)
                .Where(p => p.ParentCategoryId != null)
                .ToList()
                .Select(p => new AllCategoriesDto
                {
                    Id = p.Id,
                    Name = $"{p.ParentCategory.Name} - {p.Name}",
                }
                ).ToList();

            return new ResultDto<List<AllCategoriesDto>>
            {
                Data = categories,
                IsSuccess = false,
                Message = "",
            };
        }
    }

    public class AllCategoriesDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }



}
