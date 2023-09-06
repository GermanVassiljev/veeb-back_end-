﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using veeb_back_end_.models;

namespace veeb_back_end_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TootedController
    {
        private static List<Toode> _tooted = new List<Toode>{
        new Toode(1,"Koola", 1.5, true),
        new Toode(2,"Fanta", 1.0, false),
        new Toode(3,"Sprite", 1.7, true),
        new Toode(4,"Vichy", 2.0, true),
        new Toode(5,"Vitamin well", 2.5, true)
        };


        // https://localhost:7052/tooted
        [HttpGet]
        public List<Toode> Get()
        {
            return _tooted;
        }

        [HttpGet("kustuta/{index}")]
        public List<Toode> Delete(int index)
        {
            _tooted.RemoveAt(index);
            return _tooted;
        }

        [HttpGet("kustuta2/{index}")]
        public string Delete2(int index)
        {
            _tooted.RemoveAt(index);
            return "Kustutatud!";
        }

        [HttpGet("lisa/{id}/{nimi}/{hind}/{aktiivne}")]
        public List<Toode> Add(int id, string nimi, double hind, bool aktiivne)
        {
            Toode toode = new Toode(id, nimi, hind, aktiivne);
            _tooted.Add(toode);
            return _tooted;
        }

        [HttpGet("lisa")] // GET /tooted/lisa?id=1&nimi=Koola&hind=1.5&aktiivne=true
        public List<Toode> Add2([FromQuery] int id, [FromQuery] string nimi, [FromQuery] double hind, [FromQuery] bool aktiivne)
        {
            Toode toode = new Toode(id, nimi, hind, aktiivne);
            _tooted.Add(toode);
            return _tooted;
        }

        [HttpGet("hind-dollaritesse/{kurss}")] // GET /tooted/hind-dollaritesse/1.5
        public List<Toode> Dollaritesse(double kurss)
        {
            for (int i = 0; i < _tooted.Count; i++)
            {
                _tooted[i].Price = _tooted[i].Price * kurss;
            }
            return _tooted;
        }

        // või foreachina:

        [HttpGet("hind-dollaritesse2/{kurss}")] // GET /tooted/hind-dollaritesse2/1.5
        public List<Toode> Dollaritesse2(double kurss)
        {
            foreach (var t in _tooted)
            {
                t.Price = t.Price * kurss;
            }

            return _tooted;
        }

        [HttpGet("kustuta kõik")]
        public List<Toode> Kustuta_koik()
        {
            for (int i = 0; i < _tooted.Count; i++)
            {
                _tooted.RemoveAt(i);
            }
            //foreach(var item in _tooted)
            //{
            //    _tooted.RemoveAt(item.Id);
            //}
            return _tooted;
        }

        [HttpGet("muudamine aktiivsed")]
        public List<Toode> Muuda_aktiivsed()
        {
            foreach(var item in _tooted)
            {
                item.IsActive= false;
            }
            return _tooted;
        }

        [HttpGet("Id otsimine")]
        public string Id_otsi(int id)
        {
            foreach (var item in _tooted)
            {
                if (item.Id==id)
                {
                    return item.Name;
                }
            }
            return "Ei ole";
        }
        string andmeid;
        [HttpGet("kõrgeim hind")]
        public string Suur_hind()
        {
            double hind = 0;
            foreach(var item in _tooted)
            {
                if (item.Price>hind)
                {
                    andmeid = item.Id+"\n"+item.Name + "\n" +item.Price + "\n" +item.IsActive;
                    hind= item.Price;
                }
            }
            return andmeid;
        }
    }
}
