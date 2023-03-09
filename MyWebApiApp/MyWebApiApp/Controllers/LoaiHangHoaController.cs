using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiHangHoaController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public LoaiHangHoaController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var lstLoai = _dbContext.Loais.ToList();
            return Ok(lstLoai);
        }

        [HttpGet("{id}")]
        public IActionResult GetLoaiHHById(int id)
        {
            try
            {
                var loaiHH = _dbContext.Loais.SingleOrDefault( x => x.MaLoai == id);

                if (loaiHH == null) return NotFound();

                return Ok(loaiHH);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateLoai(LoaiHangHoaModel model)
        {
            try
            {
                var loai = new LoaiHoangHoaEntity()
                {
                    TenLoai = model.TenLoai
                };

                _dbContext.Add(loai);
                _dbContext.SaveChanges();

                return Ok(loai);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditLoaiById(int id, LoaiHangHoaModel loaiHHEdit)
        {
            try
            {
                var loaiHH = _dbContext.Loais.SingleOrDefault(x => x.MaLoai == id);

                if (loaiHH == null) return NotFound();

                if (id != loaiHH.MaLoai)
                {
                    return BadRequest();
                }

                // Update
                loaiHH.TenLoai = loaiHHEdit.TenLoai;
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLoaiHHById(int id)
        {
            try
            {
                var loaiHH = _dbContext.Loais.SingleOrDefault(x => x.MaLoai == id);

                if (loaiHH == null) return NotFound();

                _dbContext.Remove(loaiHH);
                _dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
