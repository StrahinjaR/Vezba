using DataLayer;
using DataLayer.Shared;
using System.Diagnostics;
namespace BusinessLayer

{
    public class MenuItemsBusiness
    {
        MenuItems menirepo;
        public MenuItemsBusiness()
        {
            this.menirepo = new MenuItems();
        }
        public List<Restorancic> GetRestorans()
        {
            Debug.WriteLine(menirepo.GetRestorans());
            return menirepo.GetRestorans();
        }
        public int SetRestorans(Restorancic restoran)
        {
            return menirepo.InsertMenuItems(restoran);
        }
        public List<Restorancic> GetRestorani(int min, int max)
        {
            List<Restorancic> allRestorans = menirepo.GetRestorans();
            List<Restorancic> filteredRestorans = 
                allRestorans.Where(resto => resto.Price >= min && resto.Price <= max)
        .ToList();

            return filteredRestorans;
        }
    }
}
