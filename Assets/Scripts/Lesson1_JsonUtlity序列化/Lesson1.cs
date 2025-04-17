using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Student
{
    public string name;
    public int age;
    public Student(string name, int age)
    {
        this.name = name;
        this.age = age; 
    }
}
public class Test 
{
    public string name ;
    public int age ;
    public double height;
    public bool sex;
    public int[] ids;
    public List<int> ids2;

    public Dictionary<string, int> dic = new Dictionary<string, int>();
    public Dictionary<string, string> dic2 = new Dictionary<string, string>();
    public Student student;
    public List<Student> students = new List<Student>();
    [SerializeField]
    private int privateI;
    [SerializeField]
    protected int protectedI;
    
    public Test(string name,int age, double height, bool sex, int[] ids, List<int> ids2, Dictionary<string, int> dic, Dictionary<string, string> dic2, Student student, List<Student> students, int privateI, int protectedI)
    {
        this.name = name;
        this.age = age;
        this.height = height;
        this.sex = sex;
        this.ids = ids;
        this.ids2 = ids2;
        this.dic = dic;
        this.dic2 = dic2;
        this.student = student;
        this.students = students;
        this.privateI = privateI;
        this.protectedI = protectedI;
    }
}

public class Lesson1 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        #region 知识点一 JsonUtlity是什么?
        //Jsonutlity 是Unity自带的用于解析Json的公共类
        //它可以
        //1.将内存中对象序列化为Json格式的字符串
        //2.将Json字符串反序列化为类对象
        #endregion

        #region 知识点二 必备知识点————在文件中存读字符串
        //1.存储字符串到指定路径文件中
        //第一个参数 填写的是 存储的路径   确定使用的文件夹是存在的 否者报错
        //第二个参数 填写的是 存储的字符串内容
        File.WriteAllText(Application.persistentDataPath + "/Test.txt", "Hello World");
        print(Application.persistentDataPath);
        
        //2.在指定路径文件中读取字符串
        print(File.ReadAllText(Application.persistentDataPath + "/Test.txt"));
        #endregion

        #region 知识点三 使用JsonUtlity进行序列化
        //方法:
        // JsonUtility.ToJson(需要序列化的对象)
        Test test = new Test
        ("张三", 18, 1.8, true, 
        new int[] { 1, 2, 3 }, new List<int>() { 1, 2, 3 }, 
        new Dictionary<string, int>() { { "a", 1 }, { "b", 2 } }, 
        new Dictionary<string, string>() { { "a", "1" }, { "b", "2" } }, 
        new Student("张三",18), 
        new List<Student>{new Student("ss",4)}, 0, 0);

        //JsonUtility提供了现成的方法 可以把类对象 序列化为 json字符串
        string str = JsonUtility.ToJson(test);
        
        File.WriteAllText(Application.persistentDataPath + "/Test.json", str);

        //注意:
        //1.float序列化时看起来会有一些误差
        //2.自定义类需要加上序列化特性[system.serializable]
        //3.想要序列化私有变量 需要加上特性[serializeField]
        //4.JsonUtility不支持字曲
        //5.Jsonutlity存储null对象不会是nu11 而是默认值的数据
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
