using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectory.DAL.ORM.Enum;
using TelephoneDirectory.DAL.ORM.Interface;

namespace TelephoneDirectory.DAL.ORM.Entity
{
    public class BaseEntity : IBase
    {
        public int ID { get; set; }

        private DateTime _addDate = DateTime.Now;
        public DateTime AddDate { get { return _addDate; } set { _addDate = value; } }

        private DateTime _updateDate = DateTime.Now;
        public DateTime UpdateDate { get { return _updateDate; } set { _updateDate = value; } }

        private DateTime _deleteDate = DateTime.Now;
        public DateTime DeleteDate { get { return _deleteDate; } set { _deleteDate = value; } }

        private Status _status = TelephoneDirectory.DAL.ORM.Enum.Status.Active;
        public Status Status { get { return _status; } set { _status = value; } }
    }
}
