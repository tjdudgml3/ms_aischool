/*ㅂ쥬얼 스튜디오 2022 에서 새프로젝트 시작 -> console 검색 후 오리지넝 .NET콘솔 선택 (C#,consle밖에 호환이 안됨) 
거기서 이 코드를 쓴뒤에 solution에서 add를 누르고 new프로젝트. 한뒤에 windows검색(windows form>?)해서 .NET호환이 잘안되는 프레임워크가있다. 그걸로
선택 후 디자인및 이벤트 코딩.
insert 부분
new form 프로젝트에서 add하고 new form 생성. 사실 new items 로 찾아서 가도되지만 어차피 form이 필요하기때문에 form선택
form2를 꾸미고 cs파일 만들고 form3 만들기 string connction 은 global 변수로 모든 cs파일에서 사용할수있게함.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace CRUD_Sample1
{
    internal class Program
    {
        private const string ConnectionString = "Server=tcp:labuser71sqlserver.database.windows.net,1433;Initial Catalog=labuser71sql;Persist Security Info=False;User ID=tjdudgml3;Password=tjdudgml123!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = con.CreateCommand();
            IDataReader reader = null;

            string query = "SELECT * FROM production.brands WHERE brand_id > @id";
            cmd.CommandText = query;
            cmd.Parameters.Add(new SqlParameter("@id",SqlDbType.Int)).Value = 5;


            con.Open();
            Console.WriteLine("DataBase Connected!");
            reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                Console.WriteLine("{0} - {1}", reader.GetInt32(0), reader.GetString(1));

            }
            
            con.Close();

            Console.ReadLine();
        }
    }
}
