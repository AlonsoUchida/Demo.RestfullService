using System;
using System.Collections.Generic;
using Demo.BusinessEntities.BusinessEntities;
using Demo.BusinessServices.Interfaces;
using Demo.DataModel.UnitOfWork;
using Demo.DataModel;

namespace Demo.BusinessServices.Providers
{
    public class CursoServices : ICursoServices
    {
        #region Private member variables.
        private readonly UnitOfWork _unitOfWork;
        #endregion

        #region Public constructor.
        /// <summary>
        /// Public constructor.
        /// </summary>
        public CursoServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public int Actualizar(CursoEntity curso)
        {
            try
            {
                TB_CURSO _curso = new TB_CURSO
                {
                    id = curso.Id,
                    nombre = curso.Nombre,
                    horasCredito = curso.HorasCredito
                };
                _unitOfWork.CursoRepository.Update(_curso);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int Agregar(CursoEntity curso)
        {
            try
            {
                TB_CURSO _curso = new TB_CURSO
                {
                    id = curso.Id,
                    nombre = curso.Nombre,
                    horasCredito = curso.HorasCredito
                };
                _unitOfWork.CursoRepository.Insert(_curso);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int Eliminar(int id)
        {
            try
            {
                _unitOfWork.CursoRepository.Delete(id);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public CursoEntity GetCurso(int id)
        {
            try
            {
                TB_CURSO curso =  _unitOfWork.CursoRepository.GetByID(id);
                CursoEntity _curso = new CursoEntity
                {
                    Id = curso.id,
                    Nombre = curso.nombre,
                    HorasCredito = curso.horasCredito
                };
                return _curso;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<CursoEntity> GetCursos()
        {
            try
            {
                IEnumerable<TB_CURSO> cursos = _unitOfWork.CursoRepository.Get();
                List<CursoEntity> _cursos = new List<CursoEntity>();
                foreach (var item in cursos)
                {
                    CursoEntity _curso = new CursoEntity
                    {
                        Id = item.id,
                        Nombre = item.nombre,
                        HorasCredito = item.horasCredito
                    };
                    _cursos.Add(_curso);
                }
              
                return _cursos;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
