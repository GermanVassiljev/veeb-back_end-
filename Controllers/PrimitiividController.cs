using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace veeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrimitiividController : ControllerBase
    {

        // GET: primitiivid/hello-world
        [HttpGet("hello-world")]
        public string HelloWorld()
        {
            return "Hello world at " + DateTime.Now;
        }

        // GET: primitiivid/hello-variable/mari
        [HttpGet("hello-variable/{nimi}")]
        public string HelloVariable(string nimi)
        {
            return "Hello " + nimi;
        }

        // GET: primitiivid/add/5/6
        [HttpGet("add/{nr1}/{nr2}")]
        public int AddNumbers(int nr1, int nr2)
        {
            return nr1 + nr2;
        }

        // GET: primitiivid/multiply/5/6
        [HttpGet("multiply/{nr1}/{nr2}")]
        public int Multiply(int nr1, int nr2)
        {
            return nr1 * nr2;
        }

        // GET: primitiivid/do-logs/5
        [HttpGet("do-logs/{arv}")]
        public void DoLogs(int arv)
        {
            for (int i = 0; i < arv; i++)
            {
                Console.WriteLine("See on logi nr " + i);
            }
        }

        // GET: primitiivid/random/5/6
        [HttpGet("random/{nr1}/{nr2}")]
        public int Random(int nr1, int nr2)
        {
            Random rnd = new Random();
            int RND;
            if (nr1>nr2)
            {
                RND = rnd.Next(nr2, nr1);
            }
            else
            {
                RND = rnd.Next(nr1, nr2);
            }

            return RND;
        }

        // GET: primitiivid/multiply/5/6
        [HttpGet("vanus/{paev}/{kuu}/{aasta}")]
        public int Vanus(int paev,int kuu, int aasta)
        {
            int vanus;
            bool Y = false;
            if (kuu >= DateTime.Today.Month)
            {
                if (paev >= DateTime.Today.Day)
                {
                    Y = true;
                }
                else
                {
                    Y = false;
                }
            }
            else
            {
                Y = false;
            }
            if (Y)
            {
                vanus = DateTime.Today.Year+1-aasta;
            }
            else
            {
                vanus = DateTime.Today.Year - aasta;
            }
            return vanus;
        }
    }
}
