namespace veeb_back_end_.Models
{
    public class Kasutaja
    {
        public int Id { get; set; }
        public string Kasutajanimi { get; set; }
        public string Eesnimi { get; set; }
        public string Perenimi { get; set; }
        public string Parool { get; set; }

        public Kasutaja(int id, string kasutajanimi, string eesnimi, string perenimi, string parool)
        {
            Id = id;
            Kasutajanimi = kasutajanimi;
            Eesnimi = eesnimi;
            Perenimi= perenimi;
            Parool = parool;
        }
    }
}
