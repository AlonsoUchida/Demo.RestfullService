using System;
using System.Collections.Generic;
using Demo.BusinessEntities.BusinessEntities;
using Demo.BusinessServices.Interfaces;
using Demo.DataModel.UnitOfWork;
using Demo.DataModel;

namespace Demo.BusinessServices.Providers
{
    public class EstudianteServices : IEstudianteServices
    {
        #region Private member variables.
        private readonly UnitOfWork _unitOfWork;
        #endregion

        #region Public constructor.
        /// <summary>
        /// Public constructor.
        /// </summary>
        public EstudianteServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public int Actualizar(EstudianteEntity estudiante)
        {
            try
            {
                TB_ESTUDIANTE _estudiante = new TB_ESTUDIANTE
                {
                    id = Convert.ToInt32(estudiante.Id),
                    nombre = estudiante.Nombre,
                    fechaNacimiento = estudiante.FechaNacimiento
                };
                _unitOfWork.EstudianteRepository.Update(_estudiante);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int Agregar(EstudianteEntity estudiante)
        {
            try
            {
                TB_ESTUDIANTE _estudiante = new TB_ESTUDIANTE
                {
                    id = Convert.ToInt32(estudiante.Id),
                    nombre = estudiante.Nombre,
                    fechaNacimiento = estudiante.FechaNacimiento
                };
                _unitOfWork.EstudianteRepository.Insert(_estudiante);
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
                _unitOfWork.EstudianteRepository.Delete(id);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public EstudianteEntity GetEstudiante(int id)
        {
            try
            {
                TB_ESTUDIANTE estudiante = _unitOfWork.EstudianteRepository.GetByID(id);
                EstudianteEntity _estudiante = new EstudianteEntity
                {
                    Id = estudiante.id,
                    Nombre = estudiante.nombre,
                    FechaNacimiento = estudiante.fechaNacimiento
                };
                return _estudiante;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<EstudianteEntity> GetEstudiantes()
        {
            try
            {
                IEnumerable<TB_ESTUDIANTE> estudiantes = _unitOfWork.EstudianteRepository.Get();
                List<EstudianteEntity> _estudiantes = new List<EstudianteEntity>();
                foreach (var item in estudiantes)
                {
                    EstudianteEntity _estudiante = new EstudianteEntity
                    {
                        Id = item.id,
                        Nombre = item.nombre,
                        FechaNacimiento = item.fechaNacimiento
                    };
                    _estudiantes.Add(_estudiante);
                }

                return _estudiantes;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
