using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> lstHangHoa = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(lstHangHoa);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hanghoa = lstHangHoa.SingleOrDefault( x => x.MaHangHoa == Guid.Parse(id));

                if (hanghoa == null) return NotFound();

                return Ok(hanghoa);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            HangHoa hangHoa = new HangHoa()
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            lstHangHoa.Add(hangHoa);

            return Ok(new
            {
                Success = true,
                Data = hangHoa
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hangHoaEdit)
        {
            try
            {
                var hanghoa = lstHangHoa.SingleOrDefault(x => x.MaHangHoa == Guid.Parse(id));

                if (hanghoa == null) return NotFound();

                if (id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }

                // Update
                hanghoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hanghoa.DonGia = hangHoaEdit.DonGia;

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
                var hanghoa = lstHangHoa.SingleOrDefault(x => x.MaHangHoa == Guid.Parse(id));

                if (hanghoa == null) return NotFound();

                lstHangHoa.Remove(hanghoa);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
