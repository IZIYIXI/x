using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using PathCreation;
using System.Data;
using System.Data.SqlClient;

public class TranlationMover : MonoBehaviour
{
    public PathCreator pathCreator;

    public GameObject turnPoint;
    public GameObject straightEndPoint;
    public GameObject curveEndPoint;

    Transform[] Points = new Transform[2];

    private int targetPointID = 0;
    public float speed = 10f;
    public float distanceTravelled = 0f;
    private float targetDistance;
    //public bool railsTurn = false;
    public RaillsRotation raillsRotation; //в самом Unity перетащил скрипт к которому (смотри в свойствах этого скрипта у направляющих рельсов)
    private bool shouldMove = true;
    private bool hasTurned = false;

    //private string connectionString;
    SqlCommand sqlCommand;
    SqlConnection sqlConnection;
    private string result;

    // Start is called before the first frame update
    void Start()
    {
        Points[0] = turnPoint.transform;
        Points[1] = straightEndPoint.transform;

    }

    void Update()
    {
        //if (targetPointID < 1)
        //{
        //    if (hasPassedTurnPoint != raillsRotation.railsTurn)
        //    {
        //        hasPassedTurnPoint = raillsRotation.railsTurn;
        //    }
        //}

        if (shouldMove)
        {
            if (!hasTurned)
            {
                Points[1] = straightEndPoint.transform;
                targetDistance = Vector3.Distance(transform.position, Points[targetPointID].position);
                transform.Translate(Vector3.Normalize(Points[targetPointID].position - transform.position) * Time.deltaTime * speed);
                if (targetDistance < 0.5f)
                {
                    if (targetPointID == 0)
                    {
                        if (raillsRotation.railsTurn)
                        {
                            hasTurned = true;
                            result = "turn";
                            SaveResult(result);
                        }
                        else
                        {
                            result = "not turn";
                            SaveResult(result);
                        }
                    }
                    if (targetPointID < Points.Length - 1)
                    {
                        targetPointID++;
                    }
                    else
                    {
                        shouldMove = false;
                    }
                }
            }
            else
            {
                Points[1] = curveEndPoint.transform;
                distanceTravelled += speed * Time.deltaTime;  //движение по кривой Безье
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
                targetDistance = Vector3.Distance(transform.position, Points[targetPointID].position);
                if (targetDistance < 0.5f)
                {
                    shouldMove = false;
                }
            }
        }



        //if (kostyl == false)
        //{
        //    float distance = Vector3.Distance(target_Pos, transform.position);
        //    target_Pos = Points[pointID].transform.position;
        //    transform.Translate(Vector3.Normalize(target_Pos - transform.position) * Time.deltaTime * speed);

        //    if (distance < 0.5f)
        //    {
        //        if (pointID < Points.Length - 1)
        //        {
        //            pointID++;
        //        }
        //        else
        //        {
        //            Destroy(gameObject);
        //        }
        //    }
        //}

        //if ((shouldTurn == true)&&(pointID==1))
        //{
        //    kostyl = true;
        //    distanceTravelled += speed * Time.deltaTime;  //движение по кривой Безье
        //    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        //    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        //}
        //else
        //{
        //    target_Pos = Points[pointID].transform.position;
        //    transform.Translate(Vector3.Normalize(target_Pos - transform.position) * Time.deltaTime * speed);
        //}
    }
    // Update is called once per frame
    /*void FixedUpdate() //поворот
    {
        Quaternion rotationY = Quaternion.AngleAxis(1, Vector3.up);
        transform.rotation *= rotationY;
    }*/

    private void SaveResult(string result)
    {
        
       
            /*SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "appserver01.main.tpu.ru\\sqlvt";
            builder.UserID = "TPU\\ars13";
            builder.Password = "MC03LkA3";
            builder.InitialCatalog = "trolley_problem";
            builder.IntegratedSecurity = true;

            SqlConnection connection = new SqlConnection(builder.ConnectionString);*/

            Debug.Log("Connection...");
            //connectionString = @"Data Source = .;user id = .;password = .; "
            sqlConnection = new SqlConnection("Data Source=GOD\\SQLEXPRESS (10.0 SP1);Initial Catalog=trolley_problem"); //(SQL Server 14.0.3356.20 - TPU\ars13) Integrated Security=True
        string userId = "1337";
            //bool isFirst = true;
            int isFirst = 0;
            sqlConnection.Open();
            //string connStr = "server=localhost;user=root;database=selection_problems;password=0000;"; // строка подключения к БД
            //MySqlConnection connection = new MySqlConnection(connStr); // создаём объект для подключения к БД
            //connection.Open(); // устанавливаем соединение с БД

            string query = string.Format("SELECT result FROM results WHERE user_id='{0}'", userId);
            sqlCommand = new SqlCommand(query, sqlConnection);

            
            SqlDataReader reader = sqlCommand.ExecuteReader();

            //isFirst = !reader.HasRows;
            if (reader.HasRows)
            {
                isFirst = 0;
            }
            else
            {
                isFirst = 1;
            }
            reader.Close();


            query = string.Format("INSERT INTO results (user_id, result, is_first) VALUES ({0}, {1}, {2})", userId, result, isFirst);
            sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close(); // закрываем соединение с БД

    }
}
