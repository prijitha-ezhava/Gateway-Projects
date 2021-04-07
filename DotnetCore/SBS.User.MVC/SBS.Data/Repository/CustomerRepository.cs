using SBS.BusinessEntities.ViewModel;
using SBS.Data.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace SBS.Data.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		private DB_VMSEntities dbContext = new DB_VMSEntities();
		public bool AddCustomer(tbl_Customers model)
		{
			try
			{
				dbContext.tbl_Customers.Add(model);
				return dbContext.SaveChanges() > 0;
			}


			catch (DbEntityValidationException ex)
			{

				foreach (var eve in ex.EntityValidationErrors)
				{
					Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
							ve.PropertyName, ve.ErrorMessage);
					}
				}
				throw;
			}
		}


		/*public string CustomerLogin(tbl_Customers model)
		{
			try
			{
				bool isValid = dbContext.tbl_Customers.Any(x => x.EmailID == model.EmailID && x.Password == model.Password);

				if (isValid)
				{
					FormsAuthentication.SetAuthCookie(model.EmailID, false);
					return "Successfully Logged In!";
				}
				return "Invalid credentials!";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}*/

		public IQueryable<tbl_Customers> getCustomers()
		{
			return dbContext.tbl_Customers;
		}
	}

	
}
