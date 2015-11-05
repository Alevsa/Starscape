using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour 
{
	public int AudioChannels;
	private AudioSource[] m_Sources;
	private int m_bestIndex;
	void Start () 
	{
		for (int i = 0; i < AudioChannels; i++)
			gameObject.AddComponent<AudioSource>();
		m_bestIndex = 0;
		m_Sources = gameObject.GetComponents<AudioSource>();
	}
	
	public void PlaySound(AudioClip clip)
	{
		m_Sources[m_bestIndex].clip = clip;
		m_Sources[m_bestIndex].Play();
		m_bestIndex++;
		if (m_bestIndex >= m_Sources.Length)
			m_bestIndex = 0;
	}
}
