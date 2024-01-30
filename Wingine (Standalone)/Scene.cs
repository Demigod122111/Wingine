using System;
using System.Collections.Generic;

namespace Wingine
{
    [Serializable]
    public class Scene
    {
        public static event GameObjectHandler OnGameObjectAdded;
        public static event GameObjectHandler OnGameObjectRemoved;
        public static event GameObjectAncestorHandler OnGameObjectForceRemovedByAncestor;
        public delegate void GameObjectHandler(GameObject go);
        public delegate void GameObjectAncestorHandler(GameObject ancestor, GameObject go);

        static List<Scene> CreatedScenes = new List<Scene>();

        public List<GameObject> GameObjectsQueue = new List<GameObject>();

        public List<GameObject> GameObjects;

        public GameObject Get(string ID)
        {
            foreach (GameObject gameObject in GameObjects)
            {
                if (gameObject.ID == ID) return gameObject;
            }
            return null;
        }


        public string Name = "Wingine Scene";
        public int SceneIndex => Runner.CurrentProject.Item4.IndexOf(this);


        public Scene(List<GameObject> gameObjects = null)
        {
            if (Runner.CurrentProject != null)
            {
                Runner.CurrentProject?.Item4?.Add(this);
            }

            GameObjects = gameObjects != null ? gameObjects : new List<GameObject>();

            foreach (var go in GameObjectsQueue)
            {
                GameObjects.Add(go);
                GameObjectsQueue.Remove(go);
            }


        }

        public void AddGameObject(GameObject go)
        {
            if (GameObjects == null)
            {
                GameObjectsQueue.Add(go);
                return;
            }

            GameObjects.Add(go);
            if (OnGameObjectAdded != null) OnGameObjectAdded(go);
        }

        public void RemoveGameObject(GameObject go)
        {
            void RemoveChildrenRecursively(GameObject g)
            {
                if (GameObjects != null)
                {
                    lock (GameObjects)
                    {
                        foreach (var item in GameObjects)
                        {
                            if (item.Parent == g)
                            {
                                GameObjects.Remove(item);
                                if (OnGameObjectForceRemovedByAncestor != null) OnGameObjectForceRemovedByAncestor(go, item);
                                RemoveChildrenRecursively(item);
                            }
                        }
                    }
                }
            }

            if (GameObjects != null)
            {
                if (GameObjects.Contains(go))
                {
                    GameObjects.Remove(go);
                    if (OnGameObjectRemoved != null) OnGameObjectRemoved(go);

                    RemoveChildrenRecursively(go);
                }
            }
        }
    }
}
