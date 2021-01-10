using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Matei_Proiect.Data;

namespace Matei_Proiect.Models
{
    public class CourseCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Matei_ProiectContext context,
        Course course)
        {
            var allCategories = context.Category;
            var courseCategories = new HashSet<int>(
            course.CourseCategories.Select(c => c.CourseID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = courseCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateCourseCategories(Matei_ProiectContext context,
 string[] selectedCategories, Course courseToUpdate)
        {
            if (selectedCategories == null)
            {
                courseToUpdate.CourseCategories = new List<CourseCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var courseCategories = new HashSet<int>
            (courseToUpdate.CourseCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!courseCategories.Contains(cat.ID))
                    {
                        courseToUpdate.CourseCategories.Add(
                        new CourseCategory
                        {
                            CourseID = courseToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (courseCategories.Contains(cat.ID))
                    {
                        CourseCategory courseToRemove
                        = courseToUpdate
                        .CourseCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
