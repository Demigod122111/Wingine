using System.Linq;

namespace Wingine.SceneManagement
{
    public static class SceneManager
    {
        public static event SceneEvent SceneLoaded;
        public delegate void SceneEvent(Scene scene);
        public static int CurrentSceneIndex => Runner.App.CurrentScene != null ? Runner.App.CurrentScene.SceneIndex : -1;
        public static Scene CurrentScene => Runner.App.CurrentScene;

        public static void ReloadScene() => LoadScene(CurrentSceneIndex);

        public static void LoadScene(int index)
        {
            try
            {
                Runner.App.CurrentScene = Runner.CurrentProject?.Item4?[index];
                if (SceneLoaded != null) SceneLoaded(Runner.App.CurrentScene);
            }
            catch
            {
                Debug.Write($"Unable to load scene at index `{index}`.");
            }

            if (Runner.CurrentProject?.Item4?.Count == 0) Runner.App.CurrentScene = null;
        }

        public static void LoadLastScene()
        {
            try
            {
                Runner.App.CurrentScene = Runner.CurrentProject?.Item4?.Last();
                if (SceneLoaded != null) SceneLoaded(Runner.App.CurrentScene);
            }
            catch
            {
                Debug.Write($"Unable to load scene.");
            }

            if (Runner.CurrentProject?.Item4?.Count == 0) Runner.App.CurrentScene = null;
        }

        public static void LoadFirstScene()
        {
            try
            {
                Runner.App.CurrentScene = Runner.CurrentProject?.Item4?.First();
                if (SceneLoaded != null) SceneLoaded(Runner.App.CurrentScene);
            }
            catch
            {
                Debug.Write($"Unable to load scene.");
            }

            if (Runner.CurrentProject?.Item4?.Count == 0) Runner.App.CurrentScene = null;
        }
    }
}
