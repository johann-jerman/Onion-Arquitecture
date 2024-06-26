﻿using Application.DTO;
using Application.Service;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
//using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly OrderService orderService;
        private readonly OrderProductService orderProductService;

        public OrderController(OrderService orderService, OrderProductService orderProductService) 
        {
            this.orderService = orderService;
            this.orderProductService = orderProductService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return Ok(orderService.Get());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpGet("{id}")]
        public IActionResult ById(int id)
        {
            try
            {
                return Ok(orderService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderDTO order)
        {
            try
            {
                return Ok(orderService.Create(order));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] OrderDTO order ,int id)
        {
            try
            {
                return Ok(orderService.Update(order, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                orderService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpPost("add-product")]
        public IActionResult AddProduct([FromBody] OrderProductDTO orderProduct) 
        {
            try
            {
                Order order = orderProductService.AddProduct(orderProduct);

                return Ok(order);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-product/{orderid}/{productid}")]
        public IActionResult DeleteProduct(int orderid, int productid)
        {
            try
            { 
                orderProductService.DeleteProduct(orderid, productid);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
