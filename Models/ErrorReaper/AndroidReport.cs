using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorReaper.Models
{
    public class AndroidReport
    {
        protected AndroidReport()
        {

        }

        public AndroidReport(Guid id, string packageName){

            _id = id;
            _packageName = packageName;

            if (_id == null)
            {
                _id = Guid.NewGuid();
            }
            if (string.IsNullOrWhiteSpace(_packageName))
            {
                _packageName = "Unknown";
            }
        }
        
        private Guid _id;
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private string _packageName;
        public string PackageName
        {
            get
            {
                return _packageName;
            }
            set
            {
                _packageName = value;
            }
        }

        private string _stackTrace;
        public string StackTrace
        {
            get
            {
                return _stackTrace;
            }
            set
            {
                _stackTrace = value;
            }
        }

        private string _logCat;
        public string LogCat
        {
            get
            {
                return _logCat;
            }
            set
            {
                _logCat = value;
            }
        }

        private DateTime _crashDate;
        public DateTime CrashDate
        {
            get
            {
                return _crashDate;
            }
            set
            {
                _crashDate = value;
            }
        }
    }
}
