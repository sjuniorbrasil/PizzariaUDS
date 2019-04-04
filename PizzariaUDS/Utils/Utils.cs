using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaUDS.Utils
{
    public class Utils
    {
        public static string Conexao()
        {
            var stringConnect = "Data Source=tcp:sergio,1433;Initial Catalog=PizzariaUDS;Integrated Security=True";
            return stringConnect;
        }
        

        public static int GetNewCode(string tabela, string chave1, string filtro)
        {
            int codigo = 1;
            string select = "select coalesce(max(" + chave1 + "),0) as cod " + " from " + tabela;
            if (!string.IsNullOrEmpty(filtro))
            {
                select += " where " + filtro;
            }
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Conexao();
            SqlCommand cmd = new SqlCommand(select, con);
            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();
                SqlDataReader dR = cmd.ExecuteReader();
                while (dR.Read())
                {
                    codigo = Convert.ToInt32(dR[0].ToString()) + 1;
                }
            }
            catch (Exception e)
            {
                e.ToString();
                throw;
            }
            finally
            {
                con.Close();
            }
            return codigo;
        }
    }
}
