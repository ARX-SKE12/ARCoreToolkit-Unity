using UnityEngine;
using UnityEngine.UI;

namespace ARCoreToolkit.Example
{
    public class CameraPositionUpdator : MonoBehaviour
    {

        public GameObject text;

        // Update is called once per frame
        void Update()
        {
            text.GetComponent<Text>().text = "Pos: " + transform.position.ToString();
        }
    }

}
