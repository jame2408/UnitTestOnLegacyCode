namespace ExtractAndOverride.Entity;

public class Inventory
{
    /// <summary>
    /// 判斷是否有足夠庫存，若有庫存就回傳 true，否則回傳 false。
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public virtual bool CheckInventory(OrderItems item)
    {
        throw new NotImplementedException();
    }
}