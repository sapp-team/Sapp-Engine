using System;
using System.Collections.Generic;
using System.Text;

namespace EntityComponent
{
    public interface IUpdatable
    {
        void Update(float deltaTime);
    }
}
