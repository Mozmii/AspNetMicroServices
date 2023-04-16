using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admins.Foundations.Mapper.Enum.Generic
{
    public static class GenericQueries
    {
        public static object Insert<T>(T Entity, GenericParams genericParams)
        {
            var Properties = typeof(T).GetProperties().Where(p => !p.Name.Equals(genericParams.PrimaryKeyColumn));

            string Columns = string.Join(",", Properties.Select(p => p.Name));
            string Values = string.Join(",", Properties.Select(p => "@" + p.Name));

            Dictionary<string, object> paramsDictionary = Columns.Split(',')
                .Zip(Values.Split(','), (key, value) => new { Key = key, Value = value.TrimStart('@') })
                .ToDictionary(x => x.Key, x => typeof(T).GetProperty(x.Key).GetValue(Entity));

            object o = new
            {
                SQL = $"DECLARE @RETVAL INT " +
                $"SELECT @RETVAL = COUNT({genericParams.PrimaryKeyColumn}) FROM {genericParams.Table_Name} WHERE " +
                $"{genericParams.IsExistColumnName} = @{genericParams.IsExistColumnName}; " +
                $"IF(@RETVAL > 0) " +
                    $"BEGIN " +
                        $"SET @RETVAL = 403 " +
                        $"SELECT @RETVAL AS STATUS " +
                    $"END " +
                $"ELSE " +
                    $"BEGIN " +
                        $"INSERT INTO {genericParams.Table_Name} ({Columns}) VALUES ({Values}); " +
                        $"SELECT CAST(SCOPE_IDENTITY() AS INT)" +
                    $" END",
                Params = paramsDictionary
            };

            return o;
        }

        public static object Update<T>(T Entity, GenericParams genericParams)
        {
            var Properties = typeof(T).GetProperties().Where(p => !p.Name.Equals(genericParams.PrimaryKeyColumn));

            string ColumnsAndValues = string.Join(",", Properties.Select(p => $"{p.Name}=@{p.Name}"));

            string Columns = string.Join(",", typeof(T).GetProperties().Select(p => p.Name));
            string Values = string.Join(",", typeof(T).GetProperties().Select(p => "@" + p.Name));

            Dictionary<string, object> paramsDictionary = Columns.Split(',')
                .Zip(Values.Split(','), (key, value) => new { Key = key, Value = value.TrimStart('@') })
                .ToDictionary(x => x.Key, x => typeof(T).GetProperty(x.Key).GetValue(Entity));

            object o = new
            {
                SQL = $"DECLARE @RETVAL INT SELECT @RETVAL = COUNT({genericParams.PrimaryKeyColumn}) " +
                $"FROM {genericParams.Table_Name} WHERE " +
                $"{genericParams.IsExistColumnName} = @{genericParams.IsExistColumnName} AND " +
                $"{genericParams.PrimaryKeyColumn} <> @{genericParams.PrimaryKeyColumn}; " +
                $"IF(@RETVAL > 0)" +
                    $" BEGIN " +
                        $"SET @RETVAL = 403 " +
                        $"SELECT @RETVAL AS STATUS " +
                    $"END " +
                $"ELSE " +
                $"BEGIN" +
                    $" UPDATE {genericParams.Table_Name} SET {ColumnsAndValues} WHERE " +
                    $"{genericParams.PrimaryKeyColumn} = @{genericParams.PrimaryKeyColumn}; " +
                    $"SELECT {genericParams.PrimaryKeyColumn} FROM {genericParams.Table_Name} WHERE " +
                    $"{genericParams.PrimaryKeyColumn} = @{genericParams.PrimaryKeyColumn} " +
                $"END",
                Params = paramsDictionary
            };

            return o;
        }

        public static string SelectAll<T>(GenericParams genericParams)
        {
            return $"WITH RECORDS " +
                $"AS (SELECT ROW_NUMBER() OVER(ORDER BY {genericParams.PrimaryKeyColumn}) AS SrNo,* " +
                $"FROM {genericParams.Table_Name} " +
                $"WHERE ISDELETED = 0) " +
                $"SELECT * FROM RECORDS WHERE SrNo BETWEEN " +
                $"COALESCE({genericParams.StartFrom}, 1) AND COALESCE({genericParams.EndTo}, 2147483647);";
        }

        public static string SoftDelete<T>(GenericParams genericParams)
        {
            return $"UPDATE {genericParams.Table_Name} SET ISDELETED = 1 WHERE {genericParams.PrimaryKeyColumn} = @ID";
        }

        public static string HardDelete<T>(GenericParams genericParams)
        {
            return $"DELETE FROM {genericParams.Table_Name} WHERE {genericParams.PrimaryKeyColumn} = @ID";
        }

        public static string GetByID<T>(GenericParams genericParams)
        {
            return $"SELECT * FROM {genericParams.Table_Name} WHERE {genericParams.PrimaryKeyColumn} = @ID AND ISDELETED <> 1";
        }
    }
}
