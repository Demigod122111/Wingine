using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wingine;
using Wingine.SceneManagement;
using Wingine.UI;

[Serializable]
public class Player : MonoBehaviour
{
    public float speed;
    int fps = 0;

    DateTime lst = DateTime.Now;

    int efps;
    bool logFPS = false;

    public override void Update()
    {
        DateTime now = DateTime.Now;

        if((now - lst).TotalSeconds >= 1)
        {
            lst = now;
            fps = efps;
            efps = 0;

            if(logFPS) Debug.Write($"FPS: {fps}");
            GameObject.FindByTag("FPS").GetComponent<Text>().text = $"FPS: {fps}";
        }
        else
        {
            efps++;
        }

        if (Input.GetKeyDown(System.Windows.Input.Key.C)) logFPS = !logFPS;

        if (Input.GetKeyDown(System.Windows.Input.Key.A))
        {
            Transform.Position += Vector2.Left * Time.DeltaTime * speed;
            
        }

        if (Input.GetKeyDown(System.Windows.Input.Key.D))
        {
            Transform.Position += Vector2.Right * Time.DeltaTime * speed;
        }

        if (Input.GetKeyDown(System.Windows.Input.Key.W))
        {
            Transform.Position += Vector2.Up * Time.DeltaTime * speed;
        }

        if (Input.GetKeyDown(System.Windows.Input.Key.S))
        {
            Transform.Position += Vector2.Down * Time.DeltaTime * speed;
        }
        
    }
}