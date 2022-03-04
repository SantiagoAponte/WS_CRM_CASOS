using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion
{
    public class PostCasos
    {
        public class Execute : IRequest
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

        public class Manager : IRequestHandler<Execute>
        {
            private readonly DBSolucionesContext _context;
            public Manager(DBSolucionesContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var caso = await _context.Casos.FindAsync(request.id);
                if (
                    caso == null)
                {
                    throw new Exception("No se encontro el caso");
                }

                var casoBD = _context.Casos.Where(x => x.id == request.id);
                foreach (var relationDelete in casoBD)
                {
                    _context.Casos.Remove(relationDelete);
                }

                var NewCaso = new Casos
                {
                    id = request.id,
                    projectName = request.projectName,
                    trackerName = request.trackerName,
                    statusName = request.statusName,
                    priority = request.priority,
                    author = request.author,
                    assigned_to = request.assigned_to,
                    category = request.category,
                    subject = request.subject,
                    description = request.description,
                    start_date = request.start_date,
                    due_date = request.due_date,
                    custom_fields = request.custom_fields,
                    nameCreator = request.nameCreator,
                    codeFactura = request.codeFactura,
                    closeCase = request.closeCase,
                    channelRecepcion = request.channelRecepcion,
                    avances = request.avances,
                    cedulaAsesor = request.cedulaAsesor,
                    nombreAsesor = request.nombreAsesor,
                    Producto = request.Producto,
                    Tipologia = request.Tipologia,
                    created_on = request.created_on,
                    updated_on = request.updated_on,
                    closed_on = request.closed_on,

                };

                _context.Casos.Add(NewCaso);


                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("¡Error! " + "No se pudo guardar los casos en la base de datos");
            }

        }

    }
}
