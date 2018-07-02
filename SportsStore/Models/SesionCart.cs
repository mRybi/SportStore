using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SportsStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class SesionCart:Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SesionCart cart = session?.GetJson<SesionCart>("Cart") ?? new SesionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
