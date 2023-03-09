using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {

        private readonly MyDbContext _dbContext;

        public HangHoaController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var lstHangHoa = _dbContext.HangHoas.ToList();
            return Ok(lstHangHoa);
        }

        [HttpGet("{id}")]
        public IActionResult GetHangHoaById(string id)
        {
            try
            {
                var hanghoa = _dbContext.HangHoas.SingleOrDefault( x => x.MaHangHoa == Guid.Parse(id));

                if (hanghoa == null) return NotFound();

                return Ok(hanghoa);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateNewHangHoa(HangHoaModel model)
        {
            try
            {
                HangHoaEntity newHangHoa = new HangHoaEntity()
                {
                    MaHangHoa = Guid.NewGuid(),
                    TenHangHoa = model.TenHangHoa,
                    DonGia = model.DonGia
                };
                _dbContext.Add(newHangHoa);
                _dbContext.SaveChanges();

                return Ok(new
                {
                    Success = true,
                    Data = newHangHoa
                });
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }

        [HttpPut("{id}")]
        public IActionResult EditHangHoa(string id, HangHoaModel model)
        {
            try
            {
                var hanghoa = _dbContext.HangHoas.SingleOrDefault(x => x.MaHangHoa == Guid.Parse(id));

                if (hanghoa == null) return NotFound();

                if (id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }

                // Update
                hanghoa.TenHangHoa = model.TenHangHoa;
                hanghoa.DonGia = model.DonGia;
                _dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(string id)
        {
            try
            {
                var hanghoa = _dbContext.HangHoas.SingleOrDefault(x => x.MaHangHoa == Guid.Parse(id));

                if (hanghoa == null) return NotFound();

                _dbContext.Remove(hanghoa);
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
