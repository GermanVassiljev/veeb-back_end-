using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using veeb_back_end_.models;

namespace veeb_back_end_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToodeController : ControllerBase
    {
        private static Toode _toode = new Toode(1, "Koola", 1.5, true);

        // GET: toode
        [HttpGet]
        public Toode GetToode()
        {
            return _toode;
        }

        // GET: toode/suurenda-hinda
        [HttpGet("suurenda-hinda")]
        public Toode SuurendaHinda()
        {
            _toode.Price = _toode.Price + 1;
            return _toode;
        }

        [HttpGet("toode-aktiiv")]
        public Toode Toode_Aktiiv()
        {
            if (_toode.IsActive==true)
            {
                _toode.IsActive = false;
            }
            else
            {
                _toode.IsActive = true;
            }
            return _toode;
        }

        [HttpGet("toode-nimi")]
        public Toode Toode_nimi(string nimi)
        {
            _toode.Name = nimi;
            return _toode;
        }

        [HttpGet("toode-korrutamine")]
        public Toode Toode_korrutamine(double arv)
        {
            _toode.Price = _toode.Price * arv;
            return _toode;
        }
    }
}
