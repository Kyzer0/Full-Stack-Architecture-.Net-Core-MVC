namespace ProductsAPIProject.Helpers.BussineLogic
{
    public class BussinessLogicValidation
    {
        public static void CheckID(int id)
        {
            if (id == 0) throw new ArgumentOutOfRangeException(nameof(id) + "Cannot be less than or equal to zero");
        }
        public static void CheckNullObjects<T>(T models)
        {
            if(models == null) throw new ArgumentNullException(nameof(models) + "Cannot be null");
        } 
    }
}
