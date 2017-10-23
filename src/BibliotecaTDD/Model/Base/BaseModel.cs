using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaTDD.Domain.Model.Base
{
    public class BaseModel
    {
        private Guid _id;

        public BaseModel()
        {
            _id = Guid.NewGuid();
        }

        public Guid Id { get { return _id; } }
    }
}
