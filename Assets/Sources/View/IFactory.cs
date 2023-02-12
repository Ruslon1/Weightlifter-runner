using System.Collections.Generic;

namespace Sources.View
{
    public interface IFactory
    {
        List<TransformableView> RandomSpawn();
    }
}