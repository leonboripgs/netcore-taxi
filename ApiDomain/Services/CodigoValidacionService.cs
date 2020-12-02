using ApiDomain.Entities;
using ApiDomain.Interfaces.Infraestructure.Services;
using ApiDomain.SearchCriterias;
using ApiDomain.Shared.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDomain.Services
{
    public class CodigoValidacionService : ICodigoValidacionDomainService
    {
        private readonly ICodigoValidacionInfraestructureService _service;
        public CodigoValidacionService(ICodigoValidacionInfraestructureService service)
        {
            _service = service;
        }
        public void Delete(CodigoValidacion codigoValidacion) => _service.Delete(codigoValidacion);

        public IList<CodigoValidacion> GetAll() => _service.GetAll();

        public CodigoValidacion GetByCriteria(ICriteria<CodigoValidacion> criteria) => _service.GetByCriteria(criteria);

        public CodigoValidacion GetById(int id) => _service.GetById(id);

        public CodigoValidacion GetById(string id) => _service.GetById(id);

        public IList<CodigoValidacion> GetCollectionByCriteria(ICriteria<CodigoValidacion> criteria) => _service.GetCollectionByCriteria(criteria);

        public CodigoValidacion Login(CodigoValidacion codigoValidacion)
        {            
            var result = _service.GetByCriteria(new CodigoValidacionCriteria(codigoValidacion.Telefono, codigoValidacion.Codigo));
            _service.Delete(result);

            var codigosEliminar = _service.GetCollectionByCriteria(new CodigoValidacionCriteria(DateTime.Now));
            foreach (var codigo in codigosEliminar)
                _service.Delete(codigo);

            return result;
        }

        public void Save(CodigoValidacion codigoValidacion)
        {
            CodigoValidacion codigo;
            try
            {
                codigo = GetByCriteria(new CodigoValidacionCriteria(codigoValidacion.Telefono));                
            }
            catch
            {
                codigo = codigoValidacion;
            }

            if (!codigo.Id.HasValue || codigo.Id == 0)
                _service.Create(codigo);
            else
            {
                codigo.Codigo = codigoValidacion.Codigo;
                codigo.FechaGeneracion = DateTime.Now;
                _service.Update(codigo);
            }
        }
    }
}
