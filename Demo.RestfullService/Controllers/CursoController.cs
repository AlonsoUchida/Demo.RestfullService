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
    public class CursoController : ApiController
    {
        #region Private variable.

        private readonly ICursoServices _cursoServices;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public CursoController(ICursoServices cursoServices)
        {
            _cursoServices = cursoServices;
        }

        #endregion

        // GET: api/Curso
        public IEnumerable<CursoEntity> Get()
        {
            return _cursoServices.GetCursos();
        }

        // GET: api/Curso/5
        public CursoEntity Get(int id)
        {
            return _cursoServices.GetCurso(id);
        }

        // POST: api/Curso
        public void Post([FromBody]CursoEntity value)
        {
            int isInserted = _cursoServices.Agregar(value);
            if (isInserted == 0)
            {
                Console.Write("");
            }
        }

        // PUT: api/Curso/5
        public void Put([FromBody]CursoEntity value)
        {
            int isUpdated = _cursoServices.Actualizar(value);
            if (isUpdated == 0)
            {
                Console.Write("");
            }
        }

        // DELETE: api/Curso/5
        public void Delete(int id)
        {
            int isDeleted = _cursoServices.Eliminar(id);
            if (isDeleted == 0)
            {
                Console.Write("");
            }
        }
    }
}
