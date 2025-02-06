using System.Data.SqlClient;
using TDDTestingMVC1.Models;

namespace TDDTestingMVC1.Data
{
	public class ClienteDataAccessLayer
	{
		string connectionString = "Data Source=PERSONAL\\SQL; Initial Catalog=productos; User iD=sa; Password=admin";

		public List<Cliente> GetClientes()
		{
			List<Cliente> lst = new List<Cliente>();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("cliente_SelectAll", con);
				con.Open();
				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					Cliente cliente = new Cliente();
					cliente.Codigo = Convert.ToInt32(reader["codigo"]);
					cliente.Cedula = reader["cedula"].ToString();
					cliente.Apellidos = reader["apellidos"].ToString();
					cliente.Nombres = reader["nombres"].ToString();
					cliente.FechaNacimiento =Convert.ToDateTime(reader["fechaNacimientto"]);
					cliente.Mail = reader["mail"].ToString();
					cliente.Telefono = reader["telefono"].ToString();
					cliente.Direccion = reader["direccion"].ToString();
					cliente.Estado = Convert.ToBoolean(reader["estado"]);
					lst.Add(cliente);

				}
				con.Close();
			}
			return lst;

		}

		//implementar el metodo de agregar cliente
		public void AddCliente(Cliente cliente)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("cliente_Insert", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@cedula", cliente.Cedula);
				cmd.Parameters.AddWithValue("@apellidos", cliente.Apellidos);
				cmd.Parameters.AddWithValue("@nombres", cliente.Nombres);
				cmd.Parameters.AddWithValue("@fechaNacimiento", cliente.FechaNacimiento);
				cmd.Parameters.AddWithValue("@mail", cliente.Mail);
				cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
				cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
				cmd.Parameters.AddWithValue("@estado", cliente.Estado);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}
	}
}
