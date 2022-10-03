namespace ElImportador.Dominio
{
    public class Marca
    {
        public int Id { get; set; }
        public string NombreMarca { get; set; }
       
        public override string ToString()
        {
            return NombreMarca;
        }

        
    }
}