using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDemo.DbContext;

namespace WebApiDemo.Controllers
{
    /* 
 COPY RIGHT @AUGMENTO LABS 2020
Created By Alam
*/
    [RoutePrefix("Api/Employee")]
    public class EmployeeInformationController : ApiController
    {
        DemotestEntities demotestEntities = new DemotestEntities();
        //Get Employee Data
        [HttpGet]
        [Route("GetEmployeeData")]
        public IQueryable<Employee> GetEmployee()
        {
            try
            {
                return demotestEntities.Employees;
            }
            catch (Exception ex)
            {
                throw ex ;
            }
        }
        //Get Employee Data By Id
        [HttpGet]
        [Route("GetEmployeeDataById/{Id}")]
        public IHttpActionResult GetUserById(string empId)
        {
            Employee employee = new Employee(); 
            int ID = Convert.ToInt32(empId);
            try
            {
                employee = demotestEntities.Employees.Find(ID);
                if (employee == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Ok(employee);
        }

        // Post Employee Data and Save to Data base
        [HttpPost]
        [Route("Insert")]
        public IHttpActionResult PostUser(Employee employee)
        {
            string message = "";
            if (employee != null)
            {

                try
                {
                    demotestEntities.Employees.Add(employee);
                    int result = demotestEntities.SaveChanges();
                    if (result > 0)
                    {
                        message = "Employee has been successfully added";
                    }
                    else
                    {
                        message = "faild";
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return Ok(message);
        }

    }
}
