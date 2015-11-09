using UnityEngine;
using System.Collections;

public class ExplosionController : MonoBehaviour
{
    public float TimeTillInactive;

	void OnEnable()
    {
        Invoke("Destroy", TimeTillInactive);
    }

    private void Destroy()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }
}
