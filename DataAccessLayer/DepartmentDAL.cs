using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using log4net;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer
{
    public class DepartmentDAL : Connect, IObject<Department>
    {
        public int Add(Department department)
        {
            try
            {
                SqlHelp sqlHelp = new SqlHelp();
                using (OracleConnection connection = Connect.GetConnection)
                {

                    string queryProcInsert = "Department_Insert";
                    CommandType conCommandType = CommandType.StoredProcedure;
                    OracleParameter[] parameters = new OracleParameter[]
                    {
                        new OracleParameter("departmentName",department.DepartmentName),
                        new OracleParameter("status",department.Status),
                        new OracleParameter("isDelete",department.IsDelete),
                        new OracleParameter("description",department.Description),

                    };

                    return sqlHelp.ExcuteNonQuery(queryProcInsert, conCommandType, connection, parameters);

                }

            }
            catch (Exception e)
            {
                //ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                //logger.Debug(e.Message);
                return 0;
            }
        }

        public int Delete(int id)
        {
            try
            {
                SqlHelp sqlHelp = new SqlHelp();
                using (OracleConnection connection = Connect.GetConnection)
                {

                    string queryProcInsert = "Department_Delete";
                    CommandType conCommandType = CommandType.StoredProcedure;
                    OracleParameter[] parameters = new OracleParameter[]
                    {
                        new OracleParameter("p_departmentID",id),
                        

                    };

                    return sqlHelp.ExcuteNonQuery(queryProcInsert, conCommandType, connection, parameters);

                }

            }
            catch (Exception e)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
                return 0;
            }

        }

        public List<Department> Get()
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            try
            {
                SqlHelp sqlHelp = new SqlHelp();
                using (OracleConnection connection = Connect.GetConnection)
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = new OracleCommand();

                    cmd = new OracleCommand("Department_GetAll", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("cursorParam", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;











                }

            }
            catch (Exception e)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
                return null;

            }
        }

       

        public List<Department> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public int Update(Department obj)
        {
            throw new NotImplementedException();
        }

       

       
    }
}
