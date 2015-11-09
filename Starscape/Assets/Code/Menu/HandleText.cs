using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HandleText : MonoBehaviour
{
    public void HidePlaceholder(GameObject placeholder)
    {
        placeholder.GetComponent<Text>().text = "";
    }
}
