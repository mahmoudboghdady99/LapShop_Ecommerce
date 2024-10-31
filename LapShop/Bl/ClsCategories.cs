using LapShop.Models;
using System.Reflection.Metadata.Ecma335;
using LapShop.Bl;

namespace LapShop.Bl
{
    public class ClsCategories
    {
        public List<TbCategory> GetAll()
        {
            try
            {
                LapShopContext context = new LapShopContext();
                var ListCategories = context.TbCategories.ToList();
                return ListCategories;
            }
            catch
            {
                return new List<TbCategory>();
            }
        }

        public TbCategory GetById(int id)
        {
            try
            {
                LapShopContext context = new LapShopContext();
                var category = context.TbCategories.FirstOrDefault(a => a.CategoryId == id);
                return category;
            }
            catch
            {
                // إعادة كائن TbCategory فارغ في حالة حدوث خطأ
                return new TbCategory();
            }
        }


        public bool Save(TbCategory category, List<IFormFile> files)
        {
            try
            {
                LapShopContext context = new LapShopContext();

                if (category.CategoryId == 0) // إذا كان CategoryId يساوي 0، فهذا يعني أنه إدخال جديد
                {
                    category.CreatedBy = "1";
                    category.CreatedDate = DateTime.Now;
                    context.TbCategories.Add(category); // إضافة العنصر إلى قاعدة البيانات
                }
                else // إذا كان CategoryId مختلفًا عن 0، فهذا يعني أنه تحديث للعنصر الموجود
                {
                    category.UpdatedBy = "1";
                    category.UpdatedDate = DateTime.Now;
                    context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified; // تحديث العنصر
                }

                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Delete(int id)
        {
            try
            {
                using (LapShopContext context = new LapShopContext())
                {
                    // جلب العنصر باستخدام GetById
                    var category = context.TbCategories.FirstOrDefault(a => a.CategoryId == id);

                    if (category != null)
                    {
                        // حذف العنصر من TbCategories
                        context.TbCategories.Remove(category);
                        context.SaveChanges();
                        return true;
                    }
                    return false; // إذا لم يجد العنصر
                }
            }
            catch
            {
                return false; // إعادة false إذا حدث خطأ
            }
        }

       
    }

}
    


