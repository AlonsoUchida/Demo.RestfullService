using Demo.BusinessEntities.BusinessEntities;
using System.Collections.Generic;

namespace Demo.BusinessServices.Interfaces
{
    public interface ICursoServices
    {
        int Agregar(CursoEntity curso);
        int Eliminar(int id);
        int Actualizar(CursoEntity curso);
        CursoEntity GetCurso(int id);
        IEnumerable<CursoEntity> GetCursos();
    }
}
