using Demo.BusinessEntities.BusinessEntities;
using Demo.BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.RestfullService.Controllers
{
    public class EstudianteController : ApiController
    {
        #region Private variable.

        private readonly IEstudianteServices _estudianteServices;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public EstudianteController(IEstudianteServices estudianteServices)
        {
            _estudianteServices = estudianteServices;
        }
        #endregion

        // GET: api/Estudiante
        public IEnumerable<EstudianteEntity> Get()
        {
            return _estudianteServices.GetEstudiantes();
        }

        // GET: api/Estudiante/5
        public EstudianteEntity Get(int id)
        {
            return _estudianteServices.GetEstudiante(id);
        }

        // POST: api/Estudiante
        public void Post([FromBody]EstudianteEntity value)
        {
            int isInserted = _estudianteServices.Agregar(value);
            if (isInserted == 0)
            {
                Console.Write("");
            }
        }

        // PUT: api/Estudiante/5
        public void Put([FromBody]EstudianteEntity value)
        {
            int isUpdated = _estudianteServices.Actualizar(value);
            if (isUpdated == 0)
            {
                Console.Write("");
            }
        }

        // DELETE: api/Estudiante/5
        public void Delete(int id)
        {
            int isDeleted = _estudianteServices.Eliminar(id);
            if (isDeleted == 0)
            {
                Console.Write("");
            }
        }
    }
}
