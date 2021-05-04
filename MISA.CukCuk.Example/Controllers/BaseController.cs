﻿using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Example.Controllers
{
    public class BaseController<MISAEntity> :ControllerBase where MISAEntity : class
    {
        IBaseService<MISAEntity> _baseService;

        public BaseController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
        }


        /// <summary>
        /// Lấy toàn bộ dữ liệu đối tượng
        /// </summary>
        /// <returns>
        /// StatusCode: 200 - có dữ liệu trả về
        /// StatusCode: 204 - không có dữ liệu trả về
        /// </returns>
        /// CreatedBy: TDDUNG (27/4/2021)
        [HttpGet]
        public IActionResult GetAll()
        {
            var entities = _baseService.GetAll();

            if (entities.Count() > 0)
            {
                return Ok(entities);
            }
            else return NoContent();
        }


        /// <summary>
        /// Lấy dữ liệu đối tượng theo Id  
        /// </summary>
        /// <returns>
        /// StatusCode: 200 - có dữ liệu trả về
        /// StatusCode: 204 - không có dữ liệu trả về
        /// </returns>
        /// CreatedBy: TDDUNG (27/4/2021)
        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var customer = _baseService.GetById(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            else return NoContent();
        }


        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="entity">Thông tin đối lượng</param>
        /// <returns>
        /// StatusCode: 200 - Thêm mới thành công
        /// StatusCode: 204 - Không thêm mới được vào data base
        /// StatusCode: 400 - Dữ kiệu đầu vào không hợp lệ
        /// StatusCode: 500 - Có lỗi xảy ra phía server (exception,...)
        /// </returns>
        /// CreatedBy: TDDUNG (27/4/2021)
        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            var res = _baseService.Insert(entity);
            if (res > 0)
            {
                return StatusCode(200, res);
            }
            else
            {
                return NoContent();
            }
        }



        /// <summary>
        /// Sửa thông tin đối tượng
        /// </summary>
        /// <param name="entity">Thông tin đối lượng</param>
        /// <returns>
        /// StatusCode: 200 - Sửa thành công
        /// StatusCode: 204 - Không sửa được ở data base
        /// StatusCode: 400 - Dữ kiệu đầu vào không hợp lệ
        /// StatusCode: 500 - Có lỗi xảy ra phía server (exception,...)
        /// </returns>
        /// CreatedBy: TDDUNG (27/4/2021)
        [HttpPut]
        public ActionResult Put(MISAEntity entity)
        {
            var res = _baseService.Update(entity);
            if (res > 0)
            {
                return StatusCode(200, res);
            }
            else
            {
                return NoContent();
            }

        }


        /// <summary>
        /// Xoá đối tượng
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns>
        /// StatusCode: 200 - Thêm mới thành công
        /// StatusCode: 204 - Không thêm mới được vào data base
        /// StatusCode: 400 - Dữ kiệu đầu vào không hợp lệ
        /// StatusCode: 500 - Có lỗi xảy ra phía server (exception,...)
        /// </returns>
        /// CreatedBy: TDDUNG (27/4/2021)
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            var res = _baseService.Delete(id);
            if (res > 0)
                return Ok(res);
            else return NoContent();
        }
    }
}
