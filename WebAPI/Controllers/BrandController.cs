using DataLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace WebAPI.Controllers
{
	public class BrandController : ApiController
	{
		List<Brand> brands;

		public BrandController()
		{
			brands = new List<Brand>();
			//brands.Add (new Brand { Id= 1, Name= "visa"});
			//brands.Add(new Brand { Id = 2, Name = "tymesbank" });
			//brands.Add(new Brand { Id = 3, Name = "distell" });
			//brands.Add(new Brand { Id = 4, Name = "spotify" });
			//brands.Add(new Brand { Id = 5, Name = "microsoft" });
		}
		public IEnumerable<Brand> Get()
		{
			SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString);
			string query = "select * from Brand";
			cn.Open();
			SqlDataAdapter da = new SqlDataAdapter(query, cn);
			DataSet ds = new DataSet();
			da.Fill(ds);
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				brands.Add(new Brand
				{
					Id = (int)dr["Id"],
					Name = (string)dr["BrandName"]

				});
			}


			return brands;
		}



	}
}