namespace DLL.ModeloInyeccion
{
    using System;
    using System.Collections.Generic;
    public static class Inyector
    {
        #region Propiedad
        public static Dictionary<Type, Type> mapeoClase = new Dictionary<Type, Type>();
        #endregion
        #region Metodos
        public static T Get<T>()
        {
            var type = typeof(T);
            return (T)Get(type);
        }
        public static void Map<T,V>() where V : T
        {
            mapeoClase.Add(typeof(T),typeof(V));
        }
        private static object Get(Type tipo)
        {
            var target = ResolverTipo(tipo);
            var constructor = target.GetConstructors()[0];
            var parametrosConstructor = constructor.GetParameters();
            List<Object> parametrosResueltos = new List<object>();
            foreach (var item in parametrosConstructor)
            {
                parametrosResueltos.Add(Get(item.ParameterType));
            }
            return constructor.Invoke(parametrosResueltos.ToArray());
        }
        private static Type ResolverTipo(Type tipo)
        {
            if (mapeoClase.ContainsKey(tipo))
            {
                return mapeoClase[tipo];
            }
            return tipo;
        }
        #endregion
    }
}
