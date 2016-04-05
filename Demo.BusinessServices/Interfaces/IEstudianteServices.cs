using Demo.BusinessEntities.BusinessEntities;
using System.Collections.Generic;

namespace Demo.BusinessServices.Interfaces
{
    public interface IEstudianteServices
    {
        int Agregar(EstudianteEntity curso);
        int Eliminar(int id);
        int Actualizar(EstudianteEntity curso);
        EstudianteEntity GetEstudiante(int id);
        IEnumerable<EstudianteEntity> GetEstudiantes();
    }
}
