using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    public List<string> Monologue;
    public TextMeshProUGUI text;
    private int i;
    void Start()
    {
        i = -1;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            i++;
            if(i < Monologue.Count)
            {
                text.text = Monologue[i];
            }
        }
    }
}
