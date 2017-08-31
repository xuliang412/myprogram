using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeAndReflection
{
    class CustomizeORM
    {
        public void Insert(object table)
        {
            Type type = table.GetType();
            Dictionary<string, string> columnValueDict = new Dictionary<string, string>();
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.Append("insert into ");
            TableAttribute tableAttribute = (type.GetCustomAttributes(typeof(TableAttribute), false).First()) as TableAttribute;
            sqlStr.Append(tableAttribute.TableName);
            sqlStr.Append("('");

            foreach (var prop in type.GetProperties())
            {
                foreach (var attr in prop.GetCustomAttributes())
                {
                    string value = prop.GetValue(table).ToString();
                    ColumnAttribute columnAttribute = attr as ColumnAttribute;
                    if (columnAttribute != null)
                    {
                        columnValueDict.Add(columnAttribute.ColumnName, value);
                    }
                }
            }
            foreach (KeyValuePair<string, string> item in columnValueDict)
            {
                sqlStr.Append(item.Key);
                sqlStr.Append("','");
            }
            sqlStr.Remove(sqlStr.Length - 1, 1);
            sqlStr.Append(") values('");
            foreach (KeyValuePair<string,string> item in columnValueDict)
            {
                sqlStr.Append(item.Value);
                sqlStr.Append("','");
            }
            sqlStr.Remove(sqlStr.Length - 2, 2);
            sqlStr.Append(")");
            Console.WriteLine(sqlStr.ToString());

        }
    }
    [Table("Users")]
    public class User
    {
        [ColumnAttribute(ColumnName = "Id", DbType = DbType.Int32)]
        public int UserID { get; set; }
        [ColumnAttribute(ColumnName = "Name", DbType = DbType.String)]
        public string UserName { get; set; }
        [ColumnAttribute(ColumnName = "Age", DbType = DbType.Int32)]
        public int Age { get; set; }
    }
}
