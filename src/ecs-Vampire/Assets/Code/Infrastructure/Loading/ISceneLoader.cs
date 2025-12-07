using System;

namespace Code.Infrastructure.Loading
{
    public interface ISceneLoader
    {
        void LoadScene(string Name, Action onloaded = null);
    }
}
