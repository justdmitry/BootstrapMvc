using System;

namespace BootstrapMvc.Core
{
    public interface ILink<T> where T : Element
    {
        T Href(string value);
    }
}
