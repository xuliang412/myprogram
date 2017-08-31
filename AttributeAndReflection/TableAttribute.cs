using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeAndReflection
{
    [AttributeUsage(AttributeTargets.Class,Inherited =false,AllowMultiple =false)]
    class TableAttribute:Attribute
    {
        public TableAttribute()
        {

        }
        public TableAttribute(string tableName)
        {
            this.TableName = tableName;
        }
        public string TableName { get;set; }
    }

    [AttributeUsage(AttributeTargets.Property,Inherited =false,AllowMultiple =true)]
    public class ColumnAttribute:Attribute
    {
        public ColumnAttribute()
        {

        }
        public ColumnAttribute(string columnName)
        {
            this.ColumnName = columnName;
        }
        public string ColumnName { get;set; }
        public DbType DbType { get; set; }

    }
}
