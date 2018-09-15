using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Service.Integration;
using Service.Integration.Table;
using Service.Integration.Schema;
using Service.Integration.Query.Expression;
using Service.Integration.Dto.Assembler;
namespace Service.BizLogic {
public sealed class TestBizLogic : BaseBizLogic {
    public TestBizLogic() {
        DataBase db = DataBase.GetInstance();
        Dao<TTestTable> dao = db.FindBy<TTestTable>();
        if (0 == dao.recordList.Count) {
            dao.Save();
        }
    }
    public int GetValue() {
        DataBase db = DataBase.GetInstance();
        Dao<TTestTable> dao = db.FindBy<TTestTable>();
        TTestTable table = dao.FindFirst();
        return table.value;
    }
    public void SetValue(int testValue) {
        DataBase db = DataBase.GetInstance();
        Dao<TTestTable> dao = db.FindBy<TTestTable>();
        TTestTable table = dao.FindFirst();
        table.value = testValue;
        dao.Update(table);
    }
}
}
