using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.ObjCommandServices
{
    public interface IObjCommandServices
    {
        int CreateObjCommand(ObjCommandEntity _objCommandEntity);
    }
}
