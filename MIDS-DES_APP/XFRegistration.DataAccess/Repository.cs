using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFRegistration.DataAccess.DataContext;

namespace XFRegistration.DataAccess
{
    public class Repository
    {
        private Entities.Employee ConvertToEntitiesEmployee(Employee emp)
        {
            return new Entities.Employee()
            {
                Birthday = emp.Birthday,
                Department = emp.Department,
                Email = emp.Email,
                EmployeeNumber = emp.EmployeeID,
                JobEmail = emp.JobMail,
                JobPhoneNumber = emp.JobPhoneNumber,
                JobPosition = emp.JobPosition,
                LastName = emp.LastName,
                Name = emp.Name,
                Password = emp.Password,
                PhoneNumber = emp.PhoneNumber,
                Rfc = emp.RFC,
                SecondName = emp.SecondName
            };
        }

        private Employee ConvertFromEntitiesEmployee(Entities.Employee emp)
        {
            return new Employee()
            {
                Birthday = emp.Birthday,
                Department = emp.Department,
                Email = emp.Email,
                EmployeeID = emp.EmployeeNumber,
                JobMail = emp.JobEmail,
                JobPhoneNumber = emp.JobPhoneNumber,
                JobPosition = emp.JobPosition,
                LastName = emp.LastName,
                Name = emp.Name,
                Password = emp.Password,
                PhoneNumber = emp.PhoneNumber,
                RFC = emp.Rfc,
                SecondName = emp.SecondName
            };
        }

        private void ConvertFromEntitiesEmployee(Entities.Employee emp, ref Employee empDB)
        {
            empDB.Birthday = emp.Birthday;
            empDB.Department = emp.Department;
            empDB.Email = emp.Email;
            empDB.EmployeeID = emp.EmployeeNumber;
            empDB.JobMail = emp.JobEmail;
            empDB.JobPhoneNumber = emp.JobPhoneNumber;
            empDB.JobPosition = emp.JobPosition;
            empDB.LastName = emp.LastName;
            empDB.Name = emp.Name;
            empDB.Password = emp.Password;
            empDB.PhoneNumber = emp.PhoneNumber;
            empDB.RFC = emp.Rfc;
            empDB.SecondName = emp.SecondName;
        }

        public List<Entities.Employee> GetEmployees()
        {
            try
            {
                List<Entities.Employee> employees = new List<Entities.Employee>();

                using (CPDSEntities context = new CPDSEntities())
                {
                    context.Employee.ToList().ForEach((emp) =>
                    {
                        employees.Add(this.ConvertToEntitiesEmployee(emp));
                    });
                }

                return employees;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Entities.Employee GetEmployeeByID(Int32 employeeID)
        {
            try
            {
                using (CPDSEntities context = new CPDSEntities())
                {
                    if (context.Employee.Any(emp => emp.EmployeeID == employeeID) == true)
                    {
                        return this.ConvertToEntitiesEmployee(context.Employee.Where(emp => emp.EmployeeID == employeeID).First());
                    }

                    return new Entities.Employee();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Entities.Employee InsertEmployee(Entities.Employee emp)
        {
            try
            {
                using (CPDSEntities context = new CPDSEntities())
                {
                    Employee newEmp = ConvertFromEntitiesEmployee(emp);

                    context.Employee.Add(newEmp);
                    context.SaveChanges();

                    emp.EmployeeNumber = newEmp.EmployeeID;
                }

                return emp;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Entities.Employee UpdateEmployee(Entities.Employee emp)
        {
            try
            {
                using (CPDSEntities context = new CPDSEntities())
                {
                    if (context.Employee.Any(e => e.EmployeeID == emp.EmployeeNumber) == true)
                    {
                        Employee modEmp = context.Employee.Where(e => e.EmployeeID == emp.EmployeeNumber).First();
                        this.ConvertFromEntitiesEmployee(emp, ref modEmp);
                        context.SaveChanges();

                        return emp;
                    }

                    return new Entities.Employee();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Entities.Employee DeleteEmployee(Int32 employeeID)
        {
            try
            {
                using (CPDSEntities context = new CPDSEntities())
                {
                    if (context.Employee.Any(e => e.EmployeeID == employeeID) == true)
                    {
                        Employee modEmp = context.Employee.Where(e => e.EmployeeID == employeeID).First();
                        context.Employee.Remove(modEmp);
                        context.SaveChanges();
                    }

                    return new Entities.Employee();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}