using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class icwSlitherBody : MonoBehaviour
{
    //public GameObject prtmp;
    public float lightspeed = 0.01f;

    [SerializeReference] public Parameters lightIntenseParam = new Parameters(0.5f, 1.2f, 0.5f, 2.0f);
    [SerializeReference] public Parameters lightRangeParam = new Parameters(0.5f, 3f, 0.5f, 2.0f);

    private Vector2 newlightposition;
    private Vector2 currlightposition;
    private Light insightlight;

    
    public class Parameters
    {
        public float minvalue;
        public float maxvalue;
        public float speedminvalue;
        public float speedmaxvalue;
        private float targetvalue;
        private float speed;

        public Parameters(float _aminvalue, float _amaxvalue, float _aspeedminvalue, float _aspeedmaxvalue)
        {
            minvalue = _aminvalue;
            maxvalue = _amaxvalue;
            speedminvalue = _aspeedminvalue;
            speedmaxvalue = _aspeedmaxvalue;
        }
        public void InitValue() 
        {
            targetvalue = Random.Range(minvalue, maxvalue);
            speed = Random.Range(speedminvalue, speedmaxvalue);
        }

        public float CalcNewValue(float _avalue, float time)
        {
            float res = _avalue;
            if (Mathf.Abs(_avalue - targetvalue) < 0.1f) InitValue();
            else res += Mathf.Sign(targetvalue - _avalue) * speed * time;
            return res;
        }

    }

    private void Start()
    {
        insightlight = GetComponentInChildren<Light>();
        currlightposition = new Vector2(0,0);
        newlightposition = currlightposition;
        
        lightIntenseParam.InitValue();
        lightRangeParam.InitValue();

    }
 
    private void FixedUpdate()
    {
        /*if ((currlightposition - newlightposition).magnitude < 0.05f)
            newlightposition = Random.insideUnitCircle.normalized * 0.25f;
        else
            currlightposition += (newlightposition - currlightposition).normalized * lightspeed * Time.fixedDeltaTime;
        Vector3 offset = new Vector3(currlightposition.x, currlightposition.y, 0);
        offset = Quaternion.Euler(60, 0, 45) * offset;
        insightlight.transform.position = transform.position + offset;
        */
        insightlight.intensity = lightIntenseParam.CalcNewValue(insightlight.intensity,Time.fixedDeltaTime);
        insightlight.range = lightRangeParam.CalcNewValue(insightlight.range, Time.fixedDeltaTime);
    }

}
