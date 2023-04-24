using Assets.Scripts.Utility;
using UnityEngine;

namespace GameCore.Factories
{
    public class GenericObjectFactory : BaseGameObjectFactory
    {
        public GenericObjectFactory(EventBus eventBus)
        {
            
        }
        
        public override GameObject Create()
        {
            throw new System.NotImplementedException();
        }
    }
}