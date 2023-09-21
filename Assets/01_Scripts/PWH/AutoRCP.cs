using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RcpEnum;

public class AutoRCP : MonoBehaviour
{
    RockScissorPaper rcp;

    private int randRcp;
    private int maxRcp = 3;
    private RCP ErcpState;
    public RCP rcpState;
    // Start is called before the first frame update
    void Awake()
    {
        rcp = GameObject.Find("GameObject").GetComponent<RockScissorPaper>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InitRcp()
    {
        randRcp = Random.Range(0, maxRcp);
        ErcpState = (RCP)randRcp;

        switch(ErcpState)
        {
            case RCP.rock:
                CheckRcp(0);
                break;
            case RCP.scissor:
                CheckRcp(1);
                break;
            case RCP.paper:
                CheckRcp(2);
                break;
        }
    }

    private void CheckRcp(int Ercp)
    {
        switch ((int)rcpState - Ercp)
        {
            case 0:
                Debug.Log("∫Ò∞Â¥Ÿ.");
                break;
            case 1:
                Debug.Log("¡≥¥Ÿ");
                break ;
            case -1:
                Debug.Log("¿Ã∞Â¥Ÿ");
                break;
            case 2:
                Debug.Log("¿Ã∞Â¥Ÿ");
                break ;
            case -2:
                Debug.Log("¡≥¥Ÿ");
                break;
        }
    }
}
