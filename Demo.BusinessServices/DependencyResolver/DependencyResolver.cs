using Demo.BusinessServices.Interfaces;
using Demo.BusinessServices.Providers;
using System.ComponentModel.Composition;
using UnityResolver;

namespace Demo.BusinessServices.DependencyResolver
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<ICursoServices, CursoServices>();
            registerComponent.RegisterType<IEstudianteServices, EstudianteServices>();
        }
    }
}
