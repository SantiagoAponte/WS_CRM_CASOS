using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CasosDom
    {
        public int id { get; set; }
        public Project projectName { get; set; }
        public Tracker trackerName { get; set; }
        public Status statusName { get; set; }
        public Priority priority { get; set; }
        public Author author { get; set; }
        public AssignedTo assigned_to { get; set; }
        public Category category { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
         public string start_date { get; set; }
        public object due_date { get; set; }
        public List<CustomField> custom_fields { get; set; }
        public string nameCreator { get; set; }
        public string codeFactura { get; set; }
        public string closeCase { get; set; }
        public string channelRecepcion { get; set; }
        public string avances { get; set; }
        public string cedulaAsesor { get; set; }
        public string nombreAsesor { get; set; }
        public string Producto { get; set; }
        public string Tipologia { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }
        public object closed_on { get; set; }
    }
}
