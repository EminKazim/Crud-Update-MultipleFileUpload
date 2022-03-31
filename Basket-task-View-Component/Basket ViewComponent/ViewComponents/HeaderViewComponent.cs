using Basket_ViewComponent.Data;
using Basket_ViewComponent.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket_ViewComponent.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly LayoutService _layoutService;
        public HeaderViewComponent(LayoutService layoutService)
        {
            _layoutService = layoutService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //dictionary<string, string> settings = _layoutservice.getsettings();
            return (await Task.FromResult(View()));
        }
    }
}
