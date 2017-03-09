using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    //迫击炮抛物线击中目标单位,需要的参数是:1.目标单位; 2.炮弹的水平速度.
    //按照初中的物理知识,抛物线运动在水平方向是匀速的,垂直方向上是v=a* t(v是速度, a是加速度, t是时间).
    //也就是说只要得到垂直方向初始化速度,让水平方向和垂直方向各自运行就可以了.
    //如果知道目标(距离)和水平速度,就能得到飞行的时间.time=distance/speed; 
    //在time这段时间内,炮弹用1/2的时间上升,1/2的时间下降.炮弹发出时在垂直方向上的速度是多少呢?
    //我们可以反过来看, 在最顶点时炮弹速度是0, 经过1/2的时间下落到平面,
    //根据v=a* t(也就是speed= 重力加速度 * 1 / 2 * 时间),这样就得到了垂直方向的初始化速度.
    //然后用逻辑控制垂直方向和水平方向各自运行就可以了.


    //从上面的逻辑中看出炮弹只有水平和垂直方向的位移,没有旋转:现实生活中炮弹发出时朝向天空,在最高点时炮弹旋转是水平的,在下落过程中炮弹朝向要轰炸的单位.下面为炮弹添加旋转逻辑:
    //首先根据上文水平方向速度和垂直方向的速度,能得到tan值,然后计算出调用系统math.atan的到弧度,然后弧度转换为角度.这个角度就是炮弹发出时与地面(水平方向)的夹角.然后在各角度在time/2的时间里变为0(最顶点角度为0)然后在下落的过程中角度在继续增大.最终逻辑如下:

    // Use this for initialization
    //重力加速度
    private readonly float g = 9.8f;
    //速度
    private float speed = 10;
    //目标
    public GameObject target;
    //速度
    private float verticalSpeed = 0;
    //
    private float angleSpeed = 0;
    //
    private float angle = 0;
    //
    private Vector3 moveDirection;
    //
    private float time;
    void Start()
    {
        float tempDistance = Vector3.Distance(transform.position, target.transform.position);
        float tempTime = tempDistance / speed;
        float riseTime, downTime;//上升下降时间
        riseTime = downTime = tempTime / 2;
        verticalSpeed = g * riseTime;
        transform.LookAt(target.transform.position);

        float tempTan = verticalSpeed / speed;
        double hu = Mathf.Atan(tempTan);
        angle = (float)(180 / Mathf.PI * hu);
        Debug.Log(angle);
        transform.eulerAngles = new Vector3(-angle, transform.eulerAngles.y, target.transform.eulerAngles.z);
        angleSpeed = angle / riseTime;
        moveDirection = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.y >= transform.transform.position.y)
            return;
        time += Time.deltaTime;
        float test = verticalSpeed - g * time;
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.up * test * Time.deltaTime, Space.World);
        float testAngle = -angle + angleSpeed * time;

        Debug.Log(testAngle);
        transform.eulerAngles = new Vector3(testAngle,transform.eulerAngles.y,transform.eulerAngles.z);
    }
}
