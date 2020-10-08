using Sample.Controllers.Widgets;
using Sample.Models.Widgets;
using Kentico.PageBuilder.Web.Mvc;
using System.Web.Mvc;


[assembly: RegisterWidget("Sample.Widgets.MyFirstWidgetWidget", typeof(MyFirstWidgetWidgetController), "My First Widget", IconClass = "icon-question-circle")]
namespace Sample.Controllers.Widgets
{
    public class MyFirstWidgetWidgetController : WidgetController<MyFirstWidgetWidgetProperties>
    {
        public ActionResult Index()
        {
            var properties = GetProperties();

            var viewModel = new MyFirstWidgetWidgetViewModel
            {
				Prop1 = properties.Prop1,
				Email = properties.Email,
				Description = properties.Description,
            };

            return PartialView("Widgets/MyFirstWidgetWidget/_MyFirstWidgetWidget", viewModel);
        }
    };
}