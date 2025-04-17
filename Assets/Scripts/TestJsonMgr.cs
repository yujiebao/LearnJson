using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJsonMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Test2 test = new Test2
        ("张三", 18, 1.8, true, 
        new int[] { 1, 2, 3 }, new List<int>() { 1, 2, 3 }, 
        new Dictionary<string, string>() { { "a", "1" }, { "b", "2" } }, 
        null, 
        new Student2("张三",18), 
        new List<Student2>{new Student2("ss",4)}, 5, 0);
        JsonMgr.SaveDate<Test2>(test, "Lesson3.json", JsonType.LitJson);

        Test2 t = JsonMgr.LoadData<Test2>("Lesson3", JsonType.LitJson);
        t.show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
