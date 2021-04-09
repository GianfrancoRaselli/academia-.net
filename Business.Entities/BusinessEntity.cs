using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
    {
        public BusinessEntity()
        {
            this.State = States.New;
        }

        public enum States
        {
            Deleted,
            New,
            Modified,
            Unmodified,
        }

        private int _id;
        public int ID
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

        private States _state;
        public States State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }
    }
}
