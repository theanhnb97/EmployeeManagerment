using System;
using System.Data;
using System.Threading.Tasks;
using DataAccessLayer.Helpers;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer
{
    interface ITaskDao
    {

        DataTable GetAll();
        DataTable Filter(string taskName, int department, DateTime dueDate);
        DataTable LoadDepartment();
        DataTable LoadEmployeeByDpt(int departmentId);

    }
    public class TaskDao : ITaskDao
    {
        SqlHelpers<Task> objSqlHelpers = new SqlHelpers<Task>();
        public DataTable GetAll()
        {
            try
            {

                OracleParameter[] listParameters = new OracleParameter[]
                {
                    new OracleParameter("cursorParam", OracleDbType.RefCursor, ParameterDirection.Output)
                };
                
                return objSqlHelpers.ExcuteQuery("TASK_GETALL", CommandType.StoredProcedure, Connection.GetConnection, listParameters);
            }
            catch (OracleException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Connection.GetConnection.Close();
            }
        }

        public DataTable Filter(string taskName, int department, DateTime dueDate)
        {
            OracleCommand objCommand = new OracleCommand();
            OracleParameter[] listParameters = new OracleParameter[]
            {
                new OracleParameter("IDs", OracleDbType.Int32, ParameterDirection.Output),
                //new OracleParameter("taskNames", OracleDbType.Int32,ParameterDirection.InputOutput),
                (OracleParameter) (objCommand.Parameters.Add("taskNames",OracleDbType.NVarchar2,ParameterDirection.InputOutput).Value = taskName),
                //new OracleParameter("dueDates", OracleDbType.Int32, ParameterDirection.InputOutput),
                (OracleParameter) (objCommand.Parameters.Add("dueDates",OracleDbType.Date,ParameterDirection.InputOutput).Value = dueDate),
                new OracleParameter("Priorities", OracleDbType.Int32, ParameterDirection.Output),
                new OracleParameter("files", OracleDbType.Int32, ParameterDirection.Output),
                new OracleParameter("status", OracleDbType.Int32, ParameterDirection.Output),
                new OracleParameter("description", OracleDbType.Int32, ParameterDirection.Output),
                //new OracleParameter("departmentName", OracleDbType.Int32, ParameterDirection.InputOutput),
                (OracleParameter) (objCommand.Parameters.Add("departmentName",OracleDbType.Int32,ParameterDirection.InputOutput).Value = department),
                new OracleParameter("employeeName", OracleDbType.Int32, ParameterDirection.Output)
            };
            return objSqlHelpers.ExcuteQuery("TASK_FILTER", CommandType.StoredProcedure, Connection.GetConnection, listParameters);
        }

        public DataTable LoadDepartment()
        {
            throw new NotImplementedException();
        }

        public DataTable LoadEmployeeByDpt(int departmentId)
        {
            OracleParameter[] listParameters = new OracleParameter[]
            {
                new OracleParameter("IDS", OracleDbType.Int32,departmentId,ParameterDirection.Input),
                new OracleParameter("CURSORPARAM", OracleDbType.RefCursor,ParameterDirection.Output),
            };
            return objSqlHelpers.ExcuteQuery("DEPARTMENT_GETEMPLOYEEBYDEPARTMENT", CommandType.StoredProcedure, Connection.GetConnection, listParameters);

        }
    }
}
