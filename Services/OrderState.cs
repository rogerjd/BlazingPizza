using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza.Data;
using BlazingPizza.Models;

namespace BlazingPizza.Services
{
    // https://learn.microsoft.com/en-us/training/modules/interact-with-data-blazor-web-apps/7-exercise-share-data-in-blazor-applications
    public class OrderState
    {
        public bool ShowingConfigureDialog { get; private set; }
        public Pizza ConfiguringPizza { get; private set; }
        public Order Order { get; private set; } = new Order();

        public void ShowConfiguringPizzaDialog(PizzaSpecial special)
        {
            ConfiguringPizza = new Pizza()
            {
                Special = special,
                SpecialId = special.Id,
                Size = Pizza.DefaultSize,
                Toppings = new List<PizzaTopping>(),
            };

            ShowingConfigureDialog = true;
        }

        public void CancelConfigurePizzaDialog()
        {
            ConfiguringPizza = null;

            ShowingConfigureDialog = false;
        }

        public void ConfirmConfigurePizzaDialog()
        {
            Order.Pizzas.Add(ConfiguringPizza);
            ConfiguringPizza = null;

            ShowingConfigureDialog = false;
        }
    }
}