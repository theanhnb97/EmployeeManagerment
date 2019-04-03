namespace BusinessLayer
{
    using DataAccessLayer;
    using Entity;
    using Entity.DTO;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="ISalaryBUS" />
    /// </summary>
    public interface ISalaryBUS
    {
        /// <summary>
        /// The GetData
        /// </summary>
        /// <returns>The <see cref="List{SalaryView}"/></returns>
        List<SalaryView> GetData();

        /// <summary>
        /// The SearchSalary
        /// </summary>
        /// <param name="name">The name<see cref="string"/></param>
        /// <param name="dept">The dept<see cref="string"/></param>
        /// <param name="fDate">The fDate<see cref="DateTime"/></param>
        /// <param name="tDate">The tDate<see cref="DateTime"/></param>
        /// <returns>The <see cref="List{SalaryView}"/></returns>
        List<SalaryView> SearchSalary(string name, string dept, DateTime? fDate, DateTime? tDate, int size,int currPage);

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="obj">The obj<see cref="Salary"/></param>
        /// <returns>The <see cref="int"/></returns>
        int Add(Salary obj);

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        int Delete(int id);

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="obj">The obj<see cref="Salary"/></param>
        /// <returns>The <see cref="int"/></returns>
        int Update(Salary obj);

        /// <summary>
        /// The GetById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Salary"/></returns>
        Salary GetById(int id);

        /// <summary>
        /// The GetByDeptIdAndRank
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="rank">The rank<see cref="int"/></param>
        /// <returns>The <see cref="List{Employee}"/></returns>
        List<Employee> GetByDeptIdAndRank(int id, int rank);

        /// <summary>
        /// The Paging
        /// </summary>
        /// <param name="size">The size<see cref="int"/></param>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="List{SalaryView}"/></returns>
        List<SalaryView> Paging(int size, int index);

        List<SalaryView> SearchRecords(string nameSearch,string deptSearch,DateTime fDate,DateTime tDate);
    }

    /// <summary>
    /// Defines the <see cref="SalaryBUS" />
    /// </summary>
    public class SalaryBUS : ISalaryBUS
    {
        /// <summary>
        /// Defines the SalaryDAO
        /// </summary>
        internal SalaryDAO SalaryDAO = new SalaryDAO();

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="obj">The obj<see cref="Salary"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Add(Salary obj)
        {
            return SalaryDAO.Add(obj);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Delete(int id)
        {
            return SalaryDAO.Delete(id);
        }

        /// <summary>
        /// The GetByDeptIdAndRank
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="rank">The rank<see cref="int"/></param>
        /// <returns>The <see cref="List{Employee}"/></returns>
        public List<Employee> GetByDeptIdAndRank(int id, int rank)
        {
            return SalaryDAO.GetByIdDeptAndRank(id, rank);
        }

        /// <summary>
        /// The GetById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Salary"/></returns>
        public Salary GetById(int id)
        {
            return SalaryDAO.GetById(id);
        }

        /// <summary>
        /// The GetData
        /// </summary>
        /// <returns>The <see cref="List{SalaryView}"/></returns>
        public List<SalaryView> GetData()
        {
            return SalaryDAO.GetData();
        }

        /// <summary>
        /// The Paging
        /// </summary>
        /// <param name="size">The size<see cref="int"/></param>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="List{SalaryView}"/></returns>
        public List<SalaryView> Paging(int size, int index)
        {
            return SalaryDAO.Paging(size, index);
        }

        public List<SalaryView> SearchRecords(string nameSearch, string deptSearch, DateTime fDate, DateTime tDate)
        {
            return SalaryDAO.SearchRecords(nameSearch, deptSearch, fDate, tDate);
        }

        /// <summary>
        /// The SearchSalary
        /// </summary>
        /// <param name="name">The name<see cref="string"/></param>
        /// <param name="dept">The dept<see cref="string"/></param>
        /// <param name="fDate">The fDate<see cref="DateTime"/></param>
        /// <param name="tDate">The tDate<see cref="DateTime"/></param>
        /// <returns>The <see cref="List{SalaryView}"/></returns>
        public List<SalaryView> SearchSalary(string name, string dept, DateTime? fDate, DateTime? tDate,int size,int currPage)
        {
            return SalaryDAO.SearchSalary(name, dept, fDate, tDate,size,currPage);
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="obj">The obj<see cref="Salary"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(Salary obj)
        {
            return SalaryDAO.Update(obj);
        }
    }
}
