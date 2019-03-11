using EntityComponent.Renderers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityComponent
{
    public interface IDrawable
    {
        void Render(IRenderer renderer);
    }
}
