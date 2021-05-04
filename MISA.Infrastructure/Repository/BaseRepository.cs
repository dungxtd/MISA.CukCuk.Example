using Dapper;
using MISA.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity> where MISAEntity: class 
    {
        protected String tableName = typeof(MISAEntity).Name;
        protected String connectionString = "" +
        "Host = 47.241.69.179;" +
        "Port = 3306;" +
        "Database = MF0_NVManh_CukCuk02;" +
        "User Id = dev;" +
        "Password = 12345678;" +
        "convert zero datetime=true";

        protected IDbConnection dbConnection;

        

        public IEnumerable<MISAEntity> GetAll()
        {
            {
                using (dbConnection = new MySqlConnection(connectionString))
                {
                    var entities = dbConnection.Query<MISAEntity>($"Proc_Get{tableName}s", commandType: CommandType.StoredProcedure);
                    return entities;
                }

            }
        }

        public MISAEntity GetById(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@{tableName}Id", entityId);
                var entitity = dbConnection.QueryFirstOrDefault<MISAEntity>($"Proc_Get{tableName}ById", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return entitity;
            }
        }
        public int Insert(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@{tableName}", entity);
                var rowsAffect = dbConnection.Execute($"Proc_Insert{tableName}", param: entity, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }
        public int Update(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@{tableName}", entity);
                var rowsAffect = dbConnection.Execute($"Proc_Update{tableName}", param: entity, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }

        public int Delete(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add($"@{tableName}Id", entityId.ToString());
                var rowsEffect = dbConnection.Execute($"Proc_Delete{tableName}", param: dynamicParameters, commandType: CommandType.StoredProcedure);
                return rowsEffect;
            }
        }

    }
}
