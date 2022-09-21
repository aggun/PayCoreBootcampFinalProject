using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PycApi.Data.Model;
using PycApi.Dto.Dto;
using PycApi.Service;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PycApi.Controller
{
    [Route("api/nhb/[controller]")]
    [ApiController]
    [Authorize]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly IMapper mapper;


        public CategoryController(ICategoryService categoryService, IProductService productService, IMapper mapper)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = categoryService.GetAll();
            var categoryDtos = mapper.Map<List<CategoryDto>>(categories.Response.ToList());
            return Ok(categoryDtos);
        }

        [HttpGet("GetCategoryWithProduct/{id}")]
        public IActionResult GetCategoryWithProduct(int id)
        {
            try
            {
            var response = productService.GetAll();
            var productsDto = mapper.Map<List<ProductDto>>(response.Response.Where(x => x.CategoryId == id).ToList());
            return Ok(productsDto);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            categoryService.Remove(id);
            return NoContent();
        }

        
        [HttpPost]
        public IActionResult Create([FromBody] CategoryDto dto)
        {
            var categoryDtos = categoryService.Insert(mapper.Map<Category>(dto));
            return Ok(categoryDtos);
        }
        

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CategoryDto dto)
        {
            try
            {
                var up = categoryService.GetById(id);
                up.Response.CategoryName = dto.CategoryName;
                up.Response.Id = id;
                var categoryDtos = categoryService.Update(up.Response);

                return Ok(categoryDtos);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

    }
}

