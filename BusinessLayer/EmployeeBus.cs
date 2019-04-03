namespace BusinessLayer
{
    using CommonLibrary.Enumerator;
    using DataAccessLayer;
    using DataAccessLayer.Enum;
    using Entity;
    using Entity.DTO;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="EmployeeBus" />
    /// </summary>
    public class EmployeeBus
    {
        /// <summary>
        /// Defines the employeeDao
        /// </summary>
        private readonly EmployeeDao employeeDao = new EmployeeDao();

        /// <summary>
        /// Defines the departmentBus
        /// </summary>
        private readonly DepartmentBUS departmentBus = new DepartmentBUS();

        /// <summary>
        /// Defines the departmentDal
        /// </summary>
        private readonly DepartmentDAL departmentDal = new DepartmentDAL();

        /// <summary>
        /// Defines the myEmployeeDao
        /// </summary>
        private readonly EmployeeDao myEmployeeDao = new EmployeeDao();

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="List{EmployeeDTO}"/></returns>
        public List<EmployeeDTO> GetAll()
        {
            return MapperEmployeeDtos(employeeDao.GetAll());
        }

        /// <summary>
        /// The Insert
        /// </summary>
        /// <param name="employee">The employee<see cref="Employee"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Insert(Employee employee)
        {
            return employeeDao.Add(employee);
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="employee">The employee<see cref="Employee"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(Employee employee)
        {
            return employeeDao.Update(employee);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="employeeId">The employeeId<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Delete(int employeeId)
        {
            return employeeDao.Delete(employeeId);
        }

        /// <summary>
        /// The GetBId
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Employee"/></returns>
        public Employee GetBId(int id)
        {
            return employeeDao.GetByEmployeeId(id);
        }

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="employee">The employee<see cref="Employee"/></param>
        /// <returns>The <see cref="List{EmployeeDTO}"/></returns>
        public List<EmployeeDTO> Search(Employee employee)
        {
            return MapperEmployeeDtos(employeeDao.Search(employee));
        }

        /// <summary>
        /// The GetByEmployeeId
        /// </summary>
        /// <param name="employeeId">The employeeId<see cref="int"/></param>
        /// <returns>The <see cref="Employee"/></returns>
        public Employee GetByEmployeeId(int employeeId)
        {
            return employeeDao.GetByEmployeeId(employeeId);
        }

        /// <summary>
        /// The MapperEmployeeDtos
        /// </summary>
        /// <param name="employeeDtos">The employeeDtos<see cref="List{EmployeeDTO}"/></param>
        /// <returns>The <see cref="List{EmployeeDTO}"/></returns>
        public List<EmployeeDTO> MapperEmployeeDtos(List<EmployeeDTO> employeeDtos)
        {
            foreach (var employeeDto in employeeDtos)
            {
                employeeDto.RankName = Enumerator.GetDescription((Enumeration.Rank)employeeDto.RANK);
                employeeDto.DepartmentName =
                    departmentDal.TranferDataTableToDepartmentList(
                        departmentBus.GetById(Convert.ToInt32(employeeDto.DEPARTMENTID)))[0].DepartmentName;
            }

            return employeeDtos;
        }

        /// <summary>
        /// The Login
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int Login(string userName, string password)
        {
            return myEmployeeDao.Login(userName, password);
        }

        /// <summary>
        /// The GetByUsername
        /// </summary>
        /// <param name="username">The username<see cref="string"/></param>
        /// <returns>The <see cref="Employee"/></returns>
        public Employee GetByUsername(string username)
        {
            return myEmployeeDao.GetByUsername(username);
        }

        /// <summary>
        /// The GetByIdentity
        /// </summary>
        /// <param name="identity">The identity<see cref="string"/></param>
        /// <returns>The <see cref="Employee"/></returns>
        public Employee GetByIdentity(string identity)
        {
            return myEmployeeDao.GetByIdentity(identity);
        }

        /// <summary>
        /// The UpdateProfile
        /// </summary>
        /// <param name="employee">The employee<see cref="Employee"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int UpdateProfile(Employee employee)
        {
            return myEmployeeDao.UpdateProfile(employee);
        }
    }
}
