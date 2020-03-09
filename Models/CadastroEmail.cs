using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurriculoWeb.Models
{
    public class CadastroEmail
    {
        public int ID { get; set; }
        public string NM_DESTINATARIO { get; set; }
        public string EMAIL_DESTINATARIO { get; set; }
        public string MENSAGEM { get; set; }
        
        public DateTime DT_CONTATO { get; set; }

        public CadastroEmail()
        {
            DT_CONTATO = DateTime.Now;
        }
    }
}
